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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Athletics_Federation
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        AthleticsFederationDatabaseEntities db;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Authorization_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.ViewAuthorization viewAuthorization = new ViewModel.ViewAuthorization();
            if (txtLogin.Text == "" || txtPassword.Password == "")
            {
                MessageBox.Show("Заполните пустые поля"); 
            }
            bool atempt = viewAuthorization.Authorization(txtLogin.Text, txtPassword.Password);
            if (atempt)
            {
                MessageBox.Show("Авторизация прошла успешно");
                db = new AthleticsFederationDatabaseEntities();
                try
                {
                    int RoleId = (from i in db.Users
                                  where i.Login == txtLogin.Text
                                  where i.Password == txtPassword.Password
                                  select i.IdRole).FirstOrDefault();
                    if (RoleId == 1)
                    {
                        View.Administrator.NavigationAdministrator navigationAdministrator = new View.Administrator.NavigationAdministrator();
                        navigationAdministrator.Show();
                    }
                    else if (RoleId == 2)
                    {
                        View.Moderator.NavigationModerator navigationModerator = new View.Moderator.NavigationModerator();
                        navigationModerator.Show();
                    }
                    else if (RoleId == 3)
                    {
                        View.Judge.NavigationJudge navigationJudge = new View.Judge.NavigationJudge();
                        navigationJudge.Show();
                    }
                    Hide();
                }
                catch
                {
                    MessageBox.Show("Ошибка связи с бд");
                }
            }

        }

        private void UnregistredUser_Click(object sender, RoutedEventArgs e)
        {
            View.UnregistredUser.NavigationUnregistredUsers navigation = new View.UnregistredUser.NavigationUnregistredUsers();
            navigation.Show();
            Hide();
        }
    }
}
