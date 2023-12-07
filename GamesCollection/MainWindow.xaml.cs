using GamesCollection.Classes;
using GamesCollection.Pages;
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

namespace GamesCollection
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int selectedRoleID1;
        int selectedID1;
        public MainWindow(int selectedRoleID, int selectedID)
        {
            InitializeComponent();
            selectedRoleID1 = selectedRoleID;
            selectedID1 = selectedID;
            MainFrame.Navigate(new GamesCollectionPage(selectedRoleID1, selectedID1));
            Manager.MainFrame = MainFrame;            
        }

        private void MainFrame_ContentRendered(object sender, EventArgs e)
        {
            if (MainFrame.CanGoBack)
            {
                btnBack.Visibility = Visibility.Visible;
                btnExit.Visibility = Visibility.Hidden;
            }
            else
            {
                btnBack.Visibility = Visibility.Hidden;
                btnExit.Visibility = Visibility.Visible;
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.GoBack();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close();
        }
    }
}
