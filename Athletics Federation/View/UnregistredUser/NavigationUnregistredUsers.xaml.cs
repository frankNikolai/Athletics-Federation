using System.Windows;

namespace Athletics_Federation.View.UnregistredUser
{
    /// <summary>
    /// Логика взаимодействия для NavigationUnregistredUsers.xaml
    /// </summary>
    public partial class NavigationUnregistredUsers : Window
    {
        public NavigationUnregistredUsers()
        {
            InitializeComponent();
        }
        private void ButtonMainPanelOfJudges_Click(object sender, RoutedEventArgs e)
        {
            View.UnregistredUser.XamlMainPanelOfJudges xamlMainPanelOfJudges = new XamlMainPanelOfJudges();
            xamlMainPanelOfJudges.Show();
        }

        private void ButtonTeam_Click(object sender, RoutedEventArgs e)
        {
            View.UnregistredUser.XamlTeam xamlTeam = new XamlTeam();
            xamlTeam.Show();
        }

        private void ButtonResultOfTeamPrimacy_Click(object sender, RoutedEventArgs e)
        {
            View.UnregistredUser.XamlResultOfTeamPrimacy xamlResultOfTeamPrimacy = new XamlResultOfTeamPrimacy();
            xamlResultOfTeamPrimacy.Show();
        }

        private void ButtonCompetition_Click(object sender, RoutedEventArgs e)
        {
            View.UnregistredUser.XamlCompetition xamlCompetition = new XamlCompetition();
            xamlCompetition.Show();
        }

        private void ButtonChampionship_Click(object sender, RoutedEventArgs e)
        {
            View.UnregistredUser.XamlChampionship xamlChampionship = new XamlChampionship();
            xamlChampionship.Show();
        }

        private void ButtonParticipant_Click(object sender, RoutedEventArgs e)
        {
            View.UnregistredUser.XamlParticipant xamlParticipant = new XamlParticipant();
            xamlParticipant.Show();
        }

        private void ButtonPersonParticipant_Click(object sender, RoutedEventArgs e)
        {
            View.UnregistredUser.XamlPersonCompetitions xamlPersonCompetitions = new XamlPersonCompetitions();
            xamlPersonCompetitions.Show();
        }

        private void ButtonActivity_Click(object sender, RoutedEventArgs e)
        {
            View.UnregistredUser.XamlActivity xamlActivity = new XamlActivity();
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
            View.UnregistredUser.XamlMainPanelOfJudges_Championship xamlMainPanelOfJudges_Championship = new XamlMainPanelOfJudges_Championship();
            xamlMainPanelOfJudges_Championship.Show();
        }
    }
}
