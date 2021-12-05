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

namespace Athletics_Federation.View.Moderator
{
    /// <summary>
    /// Логика взаимодействия для NavigationJudge.xaml
    /// </summary>
    public partial class NavigationModerator : Window
    {
        public NavigationModerator()
        {
            InitializeComponent();
        }

        private void ButtonMainPanelOfJudges_Click(object sender, RoutedEventArgs e)
        {
            View.Moderator.XamlMainPanelOfJudges xamlMainPanelOfJudges = new XamlMainPanelOfJudges();
            xamlMainPanelOfJudges.Show();
        }

        private void ButtonTeam_Click(object sender, RoutedEventArgs e)
        {
            View.Moderator.XamlTeam xamlTeam = new XamlTeam();
            xamlTeam.Show();
        }

        private void ButtonCompetition_Click(object sender, RoutedEventArgs e)
        {
            View.Moderator.XamlCompetition xamlCompetition = new XamlCompetition();
            xamlCompetition.Show();
        }

        private void ButtonChampionship_Click(object sender, RoutedEventArgs e)
        {
            View.Moderator.XamlChampionships xamlChampionships = new XamlChampionships();
            xamlChampionships.Show();
        }

        private void ButtonParticipant_Click(object sender, RoutedEventArgs e)
        {
            View.Moderator.XamlParticipant xamlParticipant = new XamlParticipant();
            xamlParticipant.Show();
        }

        private void ButtonPersonParticipant_Click(object sender, RoutedEventArgs e)
        {
            View.Moderator.XamlPersonCompetitions xamlPersonCompetitions = new XamlPersonCompetitions();
            xamlPersonCompetitions.Show();
        }

        private void ButtonResultOfTeamPrimacy_Click(object sender, RoutedEventArgs e)
        {
            View.Moderator.XamlResultOfTeamPrimacy xamlResultOfTeamPrimacy = new XamlResultOfTeamPrimacy();
            xamlResultOfTeamPrimacy.Show();
        }

        private void ButtonActivity_Click(object sender, RoutedEventArgs e)
        {
            View.Moderator.XamlActivity xamlActivity = new XamlActivity();
            xamlActivity.Show();
        }

        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Hide();
        }

        private void ButtonMainPanelOfJudges_Championship_Click(object sender, RoutedEventArgs e)
        {
            View.Moderator.XamlMainPanelOfJudges_Championships xamlMainPanelOfJudges_Championships = new XamlMainPanelOfJudges_Championships();
            xamlMainPanelOfJudges_Championships.Show();
        }
    }
}
