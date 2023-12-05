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
        public GamesCollectionPage()
        {
            InitializeComponent();
            GamesCollectionListView.ItemsSource = GamesCollectionEntities.GetContext().Games.ToList();
        }
    }
}
