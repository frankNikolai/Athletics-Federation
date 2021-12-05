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
    /// Логика взаимодействия для XamlChampionships.xaml
    /// </summary>
    public partial class XamlChampionships : Window
    {
        AthleticsFederationDatabaseEntities db;
        public XamlChampionships()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            db = new AthleticsFederationDatabaseEntities();
            DGridChampionship.ItemsSource = db.Championships.ToList();
        }

        private void Insert_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder error = new StringBuilder();

            if (txtId.Text.Length < 0 || txtId.Text.Length == 0 || string.IsNullOrEmpty(txtId.Text))
            {
                error.AppendLine("Укажите номер");
            }
            if (txtName.Text == "")
            {
                error.AppendLine("Укажите Название");
            }
            if (txtTheDateOfTheBeginning.Text == "" || txtTheDateOfTheBeginning.Text == null)
            {
                error.AppendLine("Укажите дату начала");
            }
            if (txtTheDateOfTheEnding.Text == "" || txtTheDateOfTheBeginning.Text == null)
            {
                error.AppendLine("Укажите дату окончания");
            }

            if (error.Length > 0)
            {
                MessageBox.Show(error.ToString());
            }
            else
            {
                try
                {
                    ViewModel.ViewChampionships viewChampionships = new ViewModel.ViewChampionships();
                    viewChampionships.AddChampionship(txtName.Text, Convert.ToDateTime(txtTheDateOfTheBeginning), Convert.ToDateTime(txtTheDateOfTheEnding));
                    DGridChampionship.ItemsSource = db.Championships.ToList();
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
                        var DRow = db.Championships.Where(w => w.ID == num).FirstOrDefault();
                        db.Championships.Remove(DRow);
                        db.SaveChanges();
                        DGridChampionship.ItemsSource = db.Championships.ToList();
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
            if (txtName.Text == "")
            {
                error.AppendLine("Укажите Название");
            }
            if (txtTheDateOfTheBeginning.Text == "" || txtTheDateOfTheBeginning.Text == null)
            {
                error.AppendLine("Укажите дату начала");
            }
            if (txtTheDateOfTheEnding.Text == "" || txtTheDateOfTheBeginning.Text == null)
            {
                error.AppendLine("Укажите дату окончания");
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
                    var URow = db.Championships.Where(id => id.ID == num).FirstOrDefault();
                    URow.NameChampionship = Convert.ToString(txtName.Text);
                    URow.TheDateOfTheBeginning = Convert.ToDateTime(txtTheDateOfTheBeginning.Text);
                    URow.TheDateOfTheEnding = Convert.ToDateTime(txtTheDateOfTheEnding.Text);
                    db.SaveChanges();
                    DGridChampionship.ItemsSource = db.Championships.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
