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
    /// Логика взаимодействия для XamlUsers.xaml
    /// </summary>
    public partial class XamlUsers : Window
    {
        AthleticsFederationDatabaseEntities db;
        public XamlUsers()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            db = new AthleticsFederationDatabaseEntities();
            DGridUsers.ItemsSource = db.Users.ToList();
        }

        private void Insert_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder error = new StringBuilder();
            if (txtLogin.Text == "")
            {
                error.AppendLine("Укажите Логин");
            }
            if (txtPassword.Text == "")
            {
                error.AppendLine("Укажите Пароль");
            }
            if (txtNameRole.Text == "")
            {
                error.AppendLine("Укажите Роль");
            }

            if (error.Length > 0)
            {
                MessageBox.Show(error.ToString());
            }
            else
            {
                try
                {
                    ViewModel.ViewUsers viewUsers = new ViewModel.ViewUsers();
                    viewUsers.AddUsers(txtLogin.Text, txtPassword.Text, Convert.ToInt32(txtNameRole.Text));
                    DGridUsers.ItemsSource = db.Users.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder error = new StringBuilder();
            if (txtId.Text.Length < 0 || txtId.Text.Length == 0 || string.IsNullOrEmpty(txtId.Text))
            {
                error.AppendLine("Укажите номер");
            }
            if (error.Length > 0)
            {
                MessageBox.Show(error.ToString());
            }
            else
            {
                {
                    try
                    {
                        ViewModel.ViewUsers viewUsers = new ViewModel.ViewUsers();
                        viewUsers.DeleteUsers(Convert.ToInt32(txtId.Text));
                        DGridUsers.ItemsSource = db.Users.ToList();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder error = new StringBuilder();
            if (txtId.Text.Length < 0 || txtId.Text.Length == 0 || string.IsNullOrEmpty(txtId.Text))
            {
                error.AppendLine("Укажите номер");
            }
            if (txtLogin.Text == "")
            {
                error.AppendLine("Укажите Логин");
            }
            if (txtPassword.Text == "")
            {
                error.AppendLine("Укажите Пароль");
            }
            if (txtNameRole.Text == "")
            {
                error.AppendLine("Укажите Роль");
            }


            if (error.Length > 0)
            {
                MessageBox.Show(error.ToString());
            }
            else
            {
                try
                {
                    ViewModel.ViewUsers viewUsers = new ViewModel.ViewUsers();
                    viewUsers.UpdateUsers(Convert.ToInt32(txtId.Text), txtLogin.Text, txtPassword.Text, Convert.ToInt32(txtNameRole.Text));
                    DGridUsers.ItemsSource = db.Users.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
