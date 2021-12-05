using System.Linq;
using System.Windows;

namespace Athletics_Federation.View.UnregistredUser
{
    /// <summary>
    /// Логика взаимодействия для XamlCompetition.xaml
    /// </summary>
    public partial class XamlCompetition : Window
    {
        AthleticsFederationDatabaseEntities db;
        public XamlCompetition()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            db = new AthleticsFederationDatabaseEntities();
            DGridCompetition.ItemsSource = db.Competitions.ToList();
        }
    }
}
