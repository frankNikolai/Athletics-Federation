using System.Linq;
using System.Windows;

namespace Athletics_Federation.View.UnregistredUser
{
    /// <summary>
    /// Логика взаимодействия для XamlChampionship.xaml
    /// </summary>
    public partial class XamlChampionship : Window
    {
        AthleticsFederationDatabaseEntities db;
        public XamlChampionship()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            db = new AthleticsFederationDatabaseEntities();
            DGridChampionship.ItemsSource = db.Championships.ToList();
        }
    }
}
