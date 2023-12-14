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
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        int selectedRoleID = 0;
        int selectedID = 0;
        public LoginPage()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {           
            var currentUser = GamesCollectionEntities.GetContext().Users.Where(x => x.Login == txbLogin.Text).ToList();
            if (currentUser.Count > 0)
            {
                selectedRoleID = currentUser[0].RoleID;
                selectedID = currentUser[0].ID;
            }

            MainWindow mainWindow = new MainWindow(selectedRoleID, selectedID);

            try
            {              
                var user0bj = AppConnect.model0db.Users.FirstOrDefault(x => x.Login == txbLogin.Text && x.Password == psbPassword.Password);  
                
                if (txbLogin.Text.Length < 5 || psbPassword.Password.Length < 5)
                {
                    MessageBox.Show("Количетсво символов в логине и пароле должно быть больше 5!");
                }
                else
                {
                    if (user0bj == null)
                    {
                        MessageBox.Show("Такого пользователя нет!", "Ошибка при авторизации!",
                            MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {
                        switch (user0bj.RoleID)
                        {
                            case 1:
                                MessageBox.Show("Здравствуйте, Администратор " + user0bj.Name + "!",
                                "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                                mainWindow.Show();
                                Window.GetWindow(this).Close();
                                break;
                            case 2:
                                MessageBox.Show("Здравствуйте, Пользователь " + user0bj.Name + "!",
                                "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                                mainWindow.Show();
                                Window.GetWindow(this).Close();
                                break;
                            default:
                                MessageBox.Show("Данные не обнаружены!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
                                break;
                        }
                    }
                }              
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка " + ex.Message.ToString() + "Критическая работа приложения!",
                    "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }      

        private void btnGuest_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Здравствуйте, Гость!",
                            "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            MainWindow mainWindow = new MainWindow(selectedRoleID, selectedID);
            mainWindow.Show();
            Window.GetWindow(this).Close();            
        }
    }
}
