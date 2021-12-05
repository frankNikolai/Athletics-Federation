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

namespace Athletics_Federation.View.Judge
{
    /// <summary>
    /// Логика взаимодействия для NavigationJudge.xaml
    /// </summary>
    public partial class NavigationJudge : Window
    {
        public NavigationJudge()
        {
            InitializeComponent();
        }

        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Hide();
        }
        private void ButtonResultOfTeamPrimacy_Click(object sender, RoutedEventArgs e)
        {
            View.Judge.XamlResultOfTeamPrimacy xamlResultOfTeamPrimacy = new View.Judge.XamlResultOfTeamPrimacy();
            xamlResultOfTeamPrimacy.Show();
        }
        private void ButtonPersonParticipant_Click(object sender, RoutedEventArgs e)
        {
            View.Judge.XamlPersonCompetitions xamlPersonCompetitions = new View.Judge.XamlPersonCompetitions();
            xamlPersonCompetitions.Show();
        }
    }
}
