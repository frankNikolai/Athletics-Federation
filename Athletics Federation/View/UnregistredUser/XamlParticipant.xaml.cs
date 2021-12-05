using System.Linq;
using System.Windows;

namespace Athletics_Federation.View.UnregistredUser
{
    /// <summary>
    /// Логика взаимодействия для XamlParticipant.xaml
    /// </summary>
    public partial class XamlParticipant : Window
    {
        AthleticsFederationDatabaseEntities db;
        public XamlParticipant()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            db = new AthleticsFederationDatabaseEntities();
            DGridParticipant.ItemsSource = db.Participants.ToList();
        }
    }
}
