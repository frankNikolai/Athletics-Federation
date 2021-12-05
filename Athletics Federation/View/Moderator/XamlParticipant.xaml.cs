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
    /// Логика взаимодействия для XamlParticipant.xaml
    /// </summary>
    public partial class XamlParticipant : Window
    {
        AthleticsFederationDatabaseEntities db;
        public XamlParticipant()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            db = new AthleticsFederationDatabaseEntities();
            DGridParticipant.ItemsSource = db.Participants.ToList();
        }

        private void Insert_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder error = new StringBuilder();

            if (txtId.Text.Length < 0 || txtId.Text.Length == 0 || string.IsNullOrEmpty(txtId.Text))
            {
                error.AppendLine("Укажите номер");
            }
            if (txtActivity.Text == "")
            {
                error.AppendLine("Укажите деятельность");
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
            if (txtBirthday.Text == "" || txtBirthday.Text != null)
            {
                error.AppendLine("Укажите день рождения");
            }
            if (ComboBoxGender.Text == "" || ComboBoxGender.Text != null)
            {
                error.AppendLine("Укажите пол");
            }
            if (txtTeam.Text == "" || txtTeam.Text != null)
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
                    ViewModel.ViewParticipant viewParticipant = new ViewModel.ViewParticipant();
                    viewParticipant.AddParticipant(Convert.ToInt32(txtActivity.Text), 
                        txtSuname.Text, txtFirstName.Text, txtMiddleName.Text, Convert.ToInt32(ComboBoxGender.Text), Convert.ToInt32(txtTeam.Text));
                    DGridParticipant.ItemsSource = db.Participants.ToList();
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
                        var DRow = db.Participants.Where(w => w.ID == num).FirstOrDefault();
                        db.Participants.Remove(DRow);
                        db.SaveChanges();
                        DGridParticipant.ItemsSource = db.Participants.ToList();
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
            if (txtActivity.Text == "")
            {
                error.AppendLine("Укажите деятельность");
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
            if (txtBirthday.Text == "" || txtBirthday.Text != null)
            {
                error.AppendLine("Укажите день рождения");
            }
            if (ComboBoxGender.Text == "" || ComboBoxGender.Text != null)
            {
                error.AppendLine("Укажите пол");
            }
            if (txtTeam.Text == "" || txtTeam.Text != null)
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
                    int num = Convert.ToInt32(txtId.Text);
                    var URow = db.Participants.Where(id => id.ID == num).FirstOrDefault();
                    URow.Activity.NameActivity = Convert.ToString(txtActivity.Text);
                    URow.Suname = Convert.ToString(txtSuname.Text);
                    URow.FirstName = Convert.ToString(txtFirstName.Text);
                    URow.MiddleName = Convert.ToString(txtMiddleName.Text);
                    URow.Birthday = Convert.ToDateTime(txtBirthday.Text);
                    URow.Gender.NameGender = Convert.ToString(ComboBoxGender.Text);
                    URow.Team.NameTeam = Convert.ToString(txtTeam.Text);
                    db.SaveChanges();
                    DGridParticipant.ItemsSource = db.Participants.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
