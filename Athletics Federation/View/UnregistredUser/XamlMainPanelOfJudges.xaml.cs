using System.Linq;
using System.Windows;

namespace Athletics_Federation.View.UnregistredUser
{
    /// <summary>
    /// Логика взаимодействия для XamlMainPanelOfJudges.xaml
    /// </summary>
    public partial class XamlMainPanelOfJudges : Window
    {
        AthleticsFederationDatabaseEntities db;
        public XamlMainPanelOfJudges()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            db = new AthleticsFederationDatabaseEntities();
            DGridMainPanelOfJudges.ItemsSource = db.MainPanelOfJudges.ToList();
        }
    }
}
