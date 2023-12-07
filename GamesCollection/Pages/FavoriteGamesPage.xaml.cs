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
        Games usersGames = new Games();
        int selectedID1;
        public FavoriteGamesPage(int selectedID)
        {
            InitializeComponent();
            selectedID1 = selectedID;
            UpdateFavoriteGames();
        }

        private void UpdateFavoriteGames()
        {
            var currentUsers = GamesCollectionEntities.GetContext().UsersGames.Where(x => x.UserID == selectedID1).ToList();

            var currentFavoriteGames = GamesCollectionEntities.GetContext().Games.ToList();
            
            GamesCollectionListView.ItemsSource = currentFavoriteGames;
        }
    }
}
