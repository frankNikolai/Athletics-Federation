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
    /// Логика взаимодействия для XamlMainPanelOfJudges.xaml
    /// </summary>
    public partial class XamlMainPanelOfJudges : Window
    {
        AthleticsFederationDatabaseEntities db;
        public XamlMainPanelOfJudges()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            db = new AthleticsFederationDatabaseEntities();
            DGridMainPanelOfJudges.ItemsSource = db.MainPanelOfJudges.ToList();
        }

        private void Insert_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder error = new StringBuilder();

            if (txtId.Text.Length < 0 || txtId.Text.Length == 0 || string.IsNullOrEmpty(txtId.Text))
            {
                error.AppendLine("Укажите номер");
            }
            if (txtNumberUser.Text.Length < 0 || txtNumberUser.Text.Length == 0 || string.IsNullOrEmpty(txtNumberUser.Text))
            {
                error.AppendLine("Укажите номер пользователя");
            }
            if (txtSuname.Text == "")
            {
                error.AppendLine("Укажите фамилию");
            }
            if (txtFirstName.Text == "")
            {
                error.AppendLine("Укажите имя");
            }
            if (txtMiddleName.Text == "")
            {
                error.AppendLine("Укажите отчество");
            }

            if (error.Length > 0)
            {
                MessageBox.Show(error.ToString());
            }
            else
            {
                try
                {
                    ViewModel.ViewMainPanelOfJudges viewMainPanelOfJudges = new ViewModel.ViewMainPanelOfJudges();
                    viewMainPanelOfJudges.AddJudge(Convert.ToInt32(txtNumberUser), txtSuname.Text, txtFirstName.Text, txtMiddleName.Text);
                    DGridMainPanelOfJudges.ItemsSource = db.MainPanelOfJudges.ToList();
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
                        var DRow = db.MainPanelOfJudges.Where(w => w.ID == num).FirstOrDefault();
                        db.MainPanelOfJudges.Remove(DRow);
                        db.SaveChanges();
                        DGridMainPanelOfJudges.ItemsSource = db.MainPanelOfJudges.ToList();
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
            if (txtNumberUser.Text.Length < 0 || txtNumberUser.Text.Length == 0 || string.IsNullOrEmpty(txtNumberUser.Text))
            {
                error.AppendLine("Укажите номер пользователя");
            }
            if (txtSuname.Text == "")
            {
                error.AppendLine("Укажите фамилию");
            }
            if (txtFirstName.Text == "")
            {
                error.AppendLine("Укажите имя");
            }
            if (txtMiddleName.Text == "")
            {
                error.AppendLine("Укажите отчество");
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
                    var URow = db.MainPanelOfJudges.Where(id => id.ID == num).FirstOrDefault();
                    URow.IdUser = Convert.ToInt32(txtNumberUser.Text);
                    URow.Suname = Convert.ToString(txtSuname.Text);
                    URow.FirstName = Convert.ToString(txtFirstName.Text);
                    URow.MiddleName = Convert.ToString(txtMiddleName.Text);
                    db.SaveChanges();
                    DGridMainPanelOfJudges.ItemsSource = db.MainPanelOfJudges.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
