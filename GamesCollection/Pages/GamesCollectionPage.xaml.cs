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
        private int selectedID2;
        public GamesCollectionPage(int selectedID1)
        {
            InitializeComponent();
            selectedID2 = selectedID1;
            GamesCollectionListView.ItemsSource = GamesCollectionEntities.GetContext().Games.ToList();
            if (selectedID2 == 1)
            {
                btnAdd.Visibility = Visibility.Visible;
                btnDelete.Visibility = Visibility.Visible;
            }
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
    }
}
