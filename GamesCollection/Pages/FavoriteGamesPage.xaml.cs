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
using GamesCollection.Classes;
using GamesCollection.Models;

namespace GamesCollection.Pages
{
    /// <summary>
    /// Логика взаимодействия для FavoriteGamesPage.xaml
    /// </summary>
    public partial class FavoriteGamesPage : Page
    {
        int selectedID1;
        int selectedRoleID1;
        public FavoriteGamesPage(int selectedID, int selectedRoleID)
        {
            InitializeComponent();
            selectedID1 = selectedID;
            selectedRoleID1 = selectedRoleID;    

            UpdateFavoriteGames();
        }

        private void UpdateFavoriteGames()
        {
            var currentGames = GamesCollectionEntities.GetContext().UsersGames.ToList();

            if (selectedRoleID1 != 1)
            {
                currentGames = currentGames.Where(x => x.UserID == selectedID1).ToList();
            }
            else
            {
                currentGames = currentGames.ToList();             
            }
          
            GamesCollectionListView.ItemsSource = currentGames;
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var gamesForRemoving = GamesCollectionListView.SelectedItems.Cast<UsersGames>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить {gamesForRemoving.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    GamesCollectionEntities.GetContext().UsersGames.RemoveRange(gamesForRemoving);
                    GamesCollectionEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");

                    var currentGames = GamesCollectionEntities.GetContext().UsersGames.ToList();

                    if (selectedRoleID1 != 1)
                    {
                        currentGames = currentGames.Where(x => x.UserID == selectedID1).ToList();
                    }
                    else
                    {
                        currentGames = currentGames.ToList();
                    }

                    GamesCollectionListView.ItemsSource = currentGames;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
    }
}
