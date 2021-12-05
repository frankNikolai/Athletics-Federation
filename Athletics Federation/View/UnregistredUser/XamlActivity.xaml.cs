using System.Linq;
using System.Windows;

namespace Athletics_Federation.View.UnregistredUser
{
    /// <summary>
    /// Логика взаимодействия для XamlActivity.xaml
    /// </summary>
    public partial class XamlActivity : Window
    {
        AthleticsFederationDatabaseEntities db;
        public XamlActivity()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            db = new AthleticsFederationDatabaseEntities();
            DGridActivity.ItemsSource = db.Activities.ToList();
        }
    }
}
