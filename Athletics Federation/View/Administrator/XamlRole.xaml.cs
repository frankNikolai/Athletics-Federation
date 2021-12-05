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
    /// Логика взаимодействия для XamlRole.xaml
    /// </summary>
    public partial class XamlRole : Window
    {
        AthleticsFederationDatabaseEntities db;
        public XamlRole()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            db = new AthleticsFederationDatabaseEntities();
            DGridRole.ItemsSource = db.Roles.ToList();
        }

        private void Insert_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder error = new StringBuilder();

            if (string.IsNullOrEmpty(txtNameRole.Text) == true)
            {
                error.AppendLine("Укажите наименование");
            }

            if (error.Length > 0)
            {
                MessageBox.Show(error.ToString());
            }
            else
            {
                try
                {
                    ViewModel.ViewRole viewRole = new ViewModel.ViewRole();
                    viewRole.AddRole(txtNameRole.Text);
                    DGridRole.ItemsSource = db.Roles.ToList();
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
                        ViewModel.ViewRole viewRole = new ViewModel.ViewRole();
                        viewRole.DeleteRole(Convert.ToInt32(txtId.Text));
                        DGridRole.ItemsSource = db.Roles.ToList();
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
            if (txtNameRole.Text == "")
            {
                error.AppendLine("Укажите Название");
            }

            if (error.Length > 0)
            {
                MessageBox.Show(error.ToString());
            }
            else
            {
                try
                {
                    int num = Convert.ToInt32(txtId.Text);
                    var URow = db.Roles.Where(id => id.IdRole == num).FirstOrDefault();
                    URow.NameRole = Convert.ToString(txtNameRole.Text);
                    db.SaveChanges();
                    DGridRole.ItemsSource = db.Roles.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
