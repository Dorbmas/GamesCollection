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
    /// Логика взаимодействия для GamesCollectionPage.xaml
    /// </summary>
    public partial class GamesCollectionPage : Page
    {
        int selectedRoleID1;
        int selectedId1;
        public GamesCollectionPage(int selectedRoleID, int selectedId)
        {
            InitializeComponent();          
            cbSorting.SelectedIndex = 0;
            selectedRoleID1 = selectedRoleID;
            selectedId1 = selectedId;
            if (selectedRoleID1 == 1)
            {
                btnAdd.Visibility = Visibility.Visible;
                btnDelete.Visibility = Visibility.Visible;
            }
            UpdateGames();
        }

        private void UpdateGames()
        {
            var currentGames = GamesCollectionEntities.GetContext().Games.ToList();

            currentGames = currentGames.Where(x => x.Title.ToLower().Contains(tbSearch.Text.ToLower())).ToList();

            if (cbSorting.SelectedIndex == 1)
            {
                currentGames = currentGames.OrderBy(x => x.Rating).ToList();
            }
            else if (cbSorting.SelectedIndex == 2)
            {
                currentGames = currentGames.OrderByDescending(x => x.Rating).ToList();
            }
            else
            {
                currentGames = currentGames.ToList();
            }

            GamesCollectionListView.ItemsSource = currentGames;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditGamesCollectionPage(null));
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var gamesForRemoving = GamesCollectionListView.SelectedItems.Cast<Games>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить {gamesForRemoving.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    GamesCollectionEntities.GetContext().Games.RemoveRange(gamesForRemoving);
                    GamesCollectionEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");

                    GamesCollectionListView.ItemsSource = GamesCollectionEntities.GetContext().Games.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                GamesCollectionEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                GamesCollectionListView.ItemsSource = GamesCollectionEntities.GetContext().Games.ToList();
            }
        }

        private void btnDetails_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new GamesCollectionMoreInformationPage((sender as Button).DataContext as Games, selectedRoleID1, selectedId1));
        }

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateGames();
        }

        private void cbSorting_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateGames();
        }
    }
}
