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
using System.Windows.Shapes;

namespace Athletics_Federation.View.UnregistredUser
{
    /// <summary>
    /// Логика взаимодействия для XamlMainPanelOfJudges_Championship.xaml
    /// </summary>
    public partial class XamlMainPanelOfJudges_Championship : Window
    {
        AthleticsFederationDatabaseEntities db;
        public XamlMainPanelOfJudges_Championship()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            db = new AthleticsFederationDatabaseEntities();
            DGridXamlMainPanelOfJudges_Championships.ItemsSource = db.MainPanelOfJudges_Championships.ToList();
        }
    }
}
