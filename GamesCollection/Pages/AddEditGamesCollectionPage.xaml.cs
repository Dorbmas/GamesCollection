using GamesCollection.Models;
using System;
using System.Collections.Generic;
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
        private Games _currentGame = new Games();
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
                errors.AppendLine("Введите корректно рейтинг");
            
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
