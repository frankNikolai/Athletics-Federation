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
    /// Логика взаимодействия для XamlTeam.xaml
    /// </summary>
    public partial class XamlTeam : Window
    {
        AthleticsFederationDatabaseEntities db;
        public XamlTeam()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            db = new AthleticsFederationDatabaseEntities();
            DGridTeam.ItemsSource = db.Teams.ToList();
        }

        private void Insert_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder error = new StringBuilder();

            if (txtId.Text.Length < 0 || txtId.Text.Length == 0 || string.IsNullOrEmpty(txtId.Text))
            {
                error.AppendLine("Укажите номер");
            }
            if (string.IsNullOrEmpty(txtTeam.Text))
            {
                error.AppendLine("Укажите команду");
            }

            if (error.Length > 0)
            {
                MessageBox.Show(error.ToString());
            }
            else
            {
                try
                {
                    ViewModel.ViewTeam viewTeam = new ViewModel.ViewTeam();
                    viewTeam.AddTeam(txtTeam.Text);
                    DGridTeam.ItemsSource = db.Teams.ToList();
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
                        int num = Convert.ToInt32(txtId.Text);
                        var DRow = db.Teams.Where(w => w.ID == num).FirstOrDefault();
                        db.Teams.Remove(DRow);
                        db.SaveChanges();
                        DGridTeam.ItemsSource = db.Teams.ToList();
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
            if (txtTeam.Text == "")
            {
                error.AppendLine("Укажите название команды");
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
                    var URow = db.Teams.Where(id => id.ID == num).FirstOrDefault();
                    URow.NameTeam = Convert.ToString(txtTeam.Text);
                    db.SaveChanges();
                    DGridTeam.ItemsSource = db.Teams.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
