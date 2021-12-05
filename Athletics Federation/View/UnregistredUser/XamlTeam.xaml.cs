using System.Linq;
using System.Windows;

namespace Athletics_Federation.View.UnregistredUser
{
    /// <summary>
    /// Логика взаимодействия для XamlTeam.xaml
    /// </summary>
    public partial class XamlTeam : Window
    {
        AthleticsFederationDatabaseEntities db;
        public XamlTeam()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            db = new AthleticsFederationDatabaseEntities();
            DGridTeam.ItemsSource = db.Teams.ToList();
        }
    }
}
