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

namespace Athletics_Federation.View.Administrator
{
    /// <summary>
    /// Логика взаимодействия для NavigationAdministrator.xaml
    /// </summary>
    public partial class NavigationAdministrator : Window
    {
        public NavigationAdministrator()
        {
            InitializeComponent();
        }

        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Hide();
        }

        private void ButtonRole_Click(object sender, RoutedEventArgs e)
        {
            View.Administrator.XamlRole xamlRole = new XamlRole();
            xamlRole.Show();
        }

        private void ButtonUsers_Click(object sender, RoutedEventArgs e)
        {
            View.Administrator.XamlUsers xamlUsers = new XamlUsers();
            xamlUsers.Show();
        }
    }
}
