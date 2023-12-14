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
        byte[] imageData;
        public AddEditGamesCollectionPage(Games selectedGame)
        {
            InitializeComponent();

            if (selectedGame != null)
                _currentGame = selectedGame;

            DataContext = _currentGame;
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
