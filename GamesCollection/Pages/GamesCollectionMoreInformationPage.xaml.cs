using GamesCollection.Classes;
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
    /// Логика взаимодействия для GamesCollectionMoreInformationPage.xaml
    /// </summary>
    public partial class GamesCollectionMoreInformationPage : Page
    {
        Games _currentGame = new Games();
        UsersGames _currentUsersGames = new UsersGames();
        int selectedRoleID1;
        int selectedID1;
        public GamesCollectionMoreInformationPage(Games selectedGame, int selectedRoleID, int selectedID)
        {
            InitializeComponent();

            selectedRoleID1 = selectedRoleID;
            selectedID1 = selectedID;

            if (selectedRoleID1 != 1)
                btnEdit.Visibility = Visibility.Hidden;

            if (selectedRoleID1 == 1)
            {
                btnFavorites.Visibility = Visibility.Hidden;
            }

            if (selectedGame != null)
                _currentGame = selectedGame;

            DataContext = _currentGame;
            
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditGamesCollectionPage((sender as Button).DataContext as Games));
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                GamesCollectionEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());                
            }
        }

        private void btnFavorites_Click(object sender, RoutedEventArgs e)
        {
            if(selectedRoleID1 != 1 && selectedRoleID1 != 2)
            {
                MessageBox.Show("Чтобы добавить игру в избранное, нужно зарегестрироваться!");
            }
            else
            {                
                _currentUsersGames.UserID = selectedID1;
                _currentUsersGames.GameID = _currentGame.ID;
                var games = AppConnect.model0db.UsersGames.Where(ug => ug.GameID == _currentGame.ID && ug.UserID == selectedID1).ToList();
                if (games.Count > 0)
                {
                    MessageBox.Show("Игра уже добавлена!");
                }
                else
                {
                    if (_currentUsersGames.ID == 0)
                        GamesCollectionEntities.GetContext().UsersGames.Add(_currentUsersGames);

                    try
                    {
                        GamesCollectionEntities.GetContext().SaveChanges();
                        MessageBox.Show("Игра добавлена");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                }               
            }
        }
    }
}
