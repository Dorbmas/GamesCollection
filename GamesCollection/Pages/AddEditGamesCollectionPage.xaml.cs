using GamesCollection.Classes;
using GamesCollection.Models;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GamesCollection.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddEditGamesCollectionPage.xaml
    /// </summary>
    public partial class AddEditGamesCollectionPage : Page
    {
        Games _currentGame = new Games();
        GamesPlatforms _currentGamePlatform = new GamesPlatforms();
        byte[] imageData;
        public AddEditGamesCollectionPage(Games selectedGame)
        {
            InitializeComponent();

            if (selectedGame != null)
                _currentGame = selectedGame;

            DataContext = _currentGame;

            UpdateGame();
        }

        public AddEditGamesCollectionPage(GamesPlatforms selectedGamePlatform, int a)
        {
            InitializeComponent();

            if (selectedGamePlatform != null)
                _currentGamePlatform = selectedGamePlatform;

            DataContext = _currentGamePlatform;

            _currentGamePlatform.ID = selectedGamePlatform.ID;

            UpdateGame();
        }

        private void UpdateGame()
        {
            var gamesPlatforms = GamesCollectionEntities.GetContext().GamesPlatforms.Where(p => p.GameID == _currentGame.ID).ToList();
            lbPlatform.ItemsSource = GamesCollectionEntities.GetContext().Platforms.ToList();
            foreach (var platform in gamesPlatforms)
            {              
                if (platform.PlatformID == 1)
                {
                    cbMac.IsChecked = true;
                    
                }
                    
                if (platform.PlatformID == 2)
                {
                    cbPC.IsChecked = true;
                    //lbPlatform.SelectedItem = Brushes.LightBlue;
                }
                    
                if (platform.PlatformID == 3)
                    cbPS3.IsChecked = true;
                if (platform.PlatformID == 4)
                    cbPS4.IsChecked = true;
                if (platform.PlatformID == 5)
                    cbXboxOne.IsChecked = true;
                if (platform.PlatformID == 6)
                    cbXbox360.IsChecked = true;
            }
        }  
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_currentGame.Title))
                errors.AppendLine("Введите название!");
            if (_currentGame.YearOfIssue < 1958)
                errors.AppendLine("Введите корректно год выхода!");
            if (_currentGame.Rating < 0 || _currentGame.Rating > 10)
                errors.AppendLine("Введите корректно рейтинг");

            if (cbMac.IsChecked == true)
            {
                _currentGamePlatform.GameID = _currentGame.ID;
                _currentGamePlatform.PlatformID = 1;
            }
            else
            {
                var removeGamesPlatform = GamesCollectionEntities.GetContext().GamesPlatforms.Where(i => i.GameID == _currentGame.ID && i.PlatformID == 1);
                GamesCollectionEntities.GetContext().GamesPlatforms.RemoveRange(removeGamesPlatform);
            }


            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentGame.ID == 0)
                GamesCollectionEntities.GetContext().Games.Add(_currentGame);

            if (_currentGamePlatform.ID == 0)
                GamesCollectionEntities.GetContext().GamesPlatforms.Add(_currentGamePlatform);

            

            try
            {
                GamesCollectionEntities.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена!");
                Manager.MainFrame.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image (*.png, *.jpg, *.jpeg) |*.png; *.jpg; *.jpeg";
            openFileDialog.Multiselect = false;

            if (openFileDialog.ShowDialog() == true)
            {
                imageData = File.ReadAllBytes(openFileDialog.FileName);
                imageService.Source = new ImageSourceConverter().ConvertFrom(imageData) as ImageSource;

                _currentGame.Image = imageData;
            }
        }
    }
}
