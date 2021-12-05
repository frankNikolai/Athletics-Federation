using System.Linq;
using System.Windows;

namespace Athletics_Federation.View.UnregistredUser
{
    /// <summary>
    /// Логика взаимодействия для XamlResultOfTeamPrimacy.xaml
    /// </summary>
    public partial class XamlResultOfTeamPrimacy : Window
    {
        AthleticsFederationDatabaseEntities db;
        public XamlResultOfTeamPrimacy()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            db = new AthleticsFederationDatabaseEntities();
            DGridResultOfTeamPrimacy.ItemsSource = db.ResultOfTeamPrimacies.ToList();
        }
    }
}
