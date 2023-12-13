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

        private void UpdateGame()
        {
            var gamesPlatforms = GamesCollectionEntities.GetContext().GamesPlatforms.Where(p => p.GameID == _currentGame.ID).ToList();
            foreach (var platform in gamesPlatforms)
            {              
                if (platform.PlatformID == 1)
                    cbMac.IsChecked = true;                    
                if (platform.PlatformID == 2)
                    cbPC.IsChecked = true;                
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
                errors.AppendLine("Введите корректно рейтинг!");

            if (cbMac.IsChecked == true)
            {
                _currentGamePlatform.GameID = _currentGame.ID;
                _currentGamePlatform.PlatformID = 1;
                var games = AppConnect.model0db.GamesPlatforms.Where(ug => ug.GameID == _currentGame.ID && ug.PlatformID == 1).ToList();
                if (games.Count > 0)
                {
                }
                else
                {
                    if (_currentGamePlatform.ID == 0)
                        GamesCollectionEntities.GetContext().GamesPlatforms.Add(_currentGamePlatform);
                }
            }
            else
            {
                var games = AppConnect.model0db.GamesPlatforms.Where(ug => ug.GameID == _currentGame.ID && ug.PlatformID == 1).ToList();
                if (games.Count > 0)
                {
                    var removeGamesPlatform = GamesCollectionEntities.GetContext().GamesPlatforms.Where(i => i.GameID == _currentGame.ID && i.PlatformID == 1).First();
                    _currentGamePlatform = removeGamesPlatform;
                    GamesCollectionEntities.GetContext().GamesPlatforms.Remove(_currentGamePlatform);
                }
                else
                {

                }
            }

            if (cbPC.IsChecked == true)
            {
                _currentGamePlatform.GameID = _currentGame.ID;
                _currentGamePlatform.PlatformID = 2;
                var games = AppConnect.model0db.GamesPlatforms.Where(ug => ug.GameID == _currentGame.ID && ug.PlatformID == 2).ToList();
                if (games.Count > 0)
                {
                }
                else
                {
                    if (_currentGamePlatform.ID == 0)
                        GamesCollectionEntities.GetContext().GamesPlatforms.Add(_currentGamePlatform);
                }
            }
            else
            {
                var games = AppConnect.model0db.GamesPlatforms.Where(ug => ug.GameID == _currentGame.ID && ug.PlatformID == 2).ToList();
                if (games.Count > 0)
                {
                    var removeGamesPlatform = GamesCollectionEntities.GetContext().GamesPlatforms.Where(i => i.GameID == _currentGame.ID && i.PlatformID == 2).First();
                    _currentGamePlatform = removeGamesPlatform;
                    GamesCollectionEntities.GetContext().GamesPlatforms.Remove(_currentGamePlatform);
                }
                else
                {

                }
            }

            if (cbPS3.IsChecked == true)
            {
                _currentGamePlatform.GameID = _currentGame.ID;
                _currentGamePlatform.PlatformID = 3;
                var games = AppConnect.model0db.GamesPlatforms.Where(ug => ug.GameID == _currentGame.ID && ug.PlatformID == 3).ToList();
                if (games.Count > 0)
                {
                }
                else
                {
                    if (_currentGamePlatform.ID == 0)
                        GamesCollectionEntities.GetContext().GamesPlatforms.Add(_currentGamePlatform);
                }
            }
            else
            {
                var games = AppConnect.model0db.GamesPlatforms.Where(ug => ug.GameID == _currentGame.ID && ug.PlatformID == 3).ToList();
                if (games.Count > 0)
                {
                    var removeGamesPlatform = GamesCollectionEntities.GetContext().GamesPlatforms.Where(i => i.GameID == _currentGame.ID && i.PlatformID == 3).First();
                    _currentGamePlatform = removeGamesPlatform;
                    GamesCollectionEntities.GetContext().GamesPlatforms.Remove(_currentGamePlatform);
                }
                else
                {

                }
            }

            if (cbPS4.IsChecked == true)
            {
                _currentGamePlatform.GameID = _currentGame.ID;
                _currentGamePlatform.PlatformID = 4;
                var games = AppConnect.model0db.GamesPlatforms.Where(ug => ug.GameID == _currentGame.ID && ug.PlatformID == 4).ToList();
                if (games.Count > 0)
                {
                }
                else
                {
                    if (_currentGamePlatform.ID == 0)
                        GamesCollectionEntities.GetContext().GamesPlatforms.Add(_currentGamePlatform);
                }
            }
            else
            {
                var games = AppConnect.model0db.GamesPlatforms.Where(ug => ug.GameID == _currentGame.ID && ug.PlatformID == 4).ToList();
                if (games.Count > 0)
                {
                    var removeGamesPlatform = GamesCollectionEntities.GetContext().GamesPlatforms.Where(i => i.GameID == _currentGame.ID && i.PlatformID == 4).First();
                    _currentGamePlatform = removeGamesPlatform;
                    GamesCollectionEntities.GetContext().GamesPlatforms.Remove(_currentGamePlatform);
                }
                else
                {

                }

            }

            if (cbXboxOne.IsChecked == true)
            {
                _currentGamePlatform.GameID = _currentGame.ID;
                _currentGamePlatform.PlatformID = 5;
                var games = AppConnect.model0db.GamesPlatforms.Where(ug => ug.GameID == _currentGame.ID && ug.PlatformID == 5).ToList();
                if (games.Count > 0)
                {
                }
                else
                {
                    if (_currentGamePlatform.ID == 0)
                        GamesCollectionEntities.GetContext().GamesPlatforms.Add(_currentGamePlatform);
                }
            }
            else
            {
                var games = AppConnect.model0db.GamesPlatforms.Where(ug => ug.GameID == _currentGame.ID && ug.PlatformID == 5).ToList();
                if (games.Count > 0)
                {
                    var removeGamesPlatform = GamesCollectionEntities.GetContext().GamesPlatforms.Where(i => i.GameID == _currentGame.ID && i.PlatformID == 5).First();
                    _currentGamePlatform = removeGamesPlatform;
                    GamesCollectionEntities.GetContext().GamesPlatforms.Remove(_currentGamePlatform);
                }
                else
                {

                }
            }

            if (cbXbox360.IsChecked == true)
            {
                _currentGamePlatform.GameID = _currentGame.ID;
                _currentGamePlatform.PlatformID = 6;
                var games = AppConnect.model0db.GamesPlatforms.Where(ug => ug.GameID == _currentGame.ID && ug.PlatformID == 6).ToList();
                if (games.Count > 0)
                {
                }
                else
                {
                    if (_currentGamePlatform.ID == 0)
                        GamesCollectionEntities.GetContext().GamesPlatforms.Add(_currentGamePlatform);
                }
            }
            else
            {
                var games = AppConnect.model0db.GamesPlatforms.Where(ug => ug.GameID == _currentGame.ID && ug.PlatformID == 6).ToList();
                if (games.Count > 0)
                {
                    var removeGamesPlatform = GamesCollectionEntities.GetContext().GamesPlatforms.Where(i => i.GameID == _currentGame.ID && i.PlatformID == 6).First();
                    _currentGamePlatform = removeGamesPlatform;
                    GamesCollectionEntities.GetContext().GamesPlatforms.Remove(_currentGamePlatform);
                }
                else
                {

                }
            }

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentGame.ID == 0)
                GamesCollectionEntities.GetContext().Games.Add(_currentGame);           

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
