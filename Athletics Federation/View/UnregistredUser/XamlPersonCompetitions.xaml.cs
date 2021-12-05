using System.Linq;
using System.Windows;

namespace Athletics_Federation.View.UnregistredUser
{
    /// <summary>
    /// Логика взаимодействия для XamlPersonCompetitions.xaml
    /// </summary>
    public partial class XamlPersonCompetitions : Window
    {
        AthleticsFederationDatabaseEntities db;
        public XamlPersonCompetitions()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            db = new AthleticsFederationDatabaseEntities();
            DGridPersonCompetition.ItemsSource = db.PersonCompetitions.ToList();
        }
    }
}
