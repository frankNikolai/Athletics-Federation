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
    /// Логика взаимодействия для XamlPersonCompetitions.xaml
    /// </summary>
    public partial class XamlPersonCompetitions : Window
    {
        AthleticsFederationDatabaseEntities db;
        public XamlPersonCompetitions()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            db = new AthleticsFederationDatabaseEntities();
            DGridPersonCompetition.ItemsSource = db.PersonCompetitions.ToList();
        }

        private void Insert_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder error = new StringBuilder();

            if (txtId.Text.Length < 0 || txtId.Text.Length == 0 || string.IsNullOrEmpty(txtId.Text))
            {
                error.AppendLine("Укажите номер");
            }
            if (txtParticipant.Text == "")
            {
                error.AppendLine("Укажите участника");
            }
            if (txtPlace.Text.Length < 0 || txtPlace.Text.Length == 0 || string.IsNullOrEmpty(txtPlace.Text))
            {
                error.AppendLine("Укажите место");
            }
            if (ComboBoxIdGender.Text.Length < 0 || ComboBoxIdGender.Text.Length == 0 || string.IsNullOrEmpty(ComboBoxIdGender.Text))
            {
                error.AppendLine("Укажите пол");
            }
            if (txtCompetition.Text == "")
            {
                error.AppendLine("Укажите компетенцию");
            }
            if (txtChampionship.Text == "")
            {
                error.AppendLine("Укажите название чемпионата");
            }
            if (txtResult.Text == "")
            {
                error.AppendLine("Укажите результат");
            }
            if (txtPoints.Text.Length < 0 || txtPoints.Text.Length == 0 || string.IsNullOrEmpty(txtPoints.Text))
            {
                error.AppendLine("Укажите очки");
            }

            if (error.Length > 0)
            {
                MessageBox.Show(error.ToString());
            }
            else
            {
                try
                {
                    ViewModel.ViewPersonCompetitions viewPersonCompetitions = new ViewModel.ViewPersonCompetitions();
                    viewPersonCompetitions.AddPerson(Convert.ToInt32(txtParticipant.Text),
                        Convert.ToInt32(txtPlace), Convert.ToInt32(ComboBoxIdGender.Text), Convert.ToInt32(txtCompetition.Text),
                        Convert.ToInt32(txtChampionship.Text), txtResult.Text, Convert.ToInt32(txtPoints));

                    DGridPersonCompetition.ItemsSource = db.PersonCompetitions.ToList();
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
                        var DRow = db.PersonCompetitions.Where(w => w.ID == num).FirstOrDefault();
                        db.PersonCompetitions.Remove(DRow);
                        db.SaveChanges();
                        DGridPersonCompetition.ItemsSource = db.PersonCompetitions.ToList();
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
            if (txtParticipant.Text == "")
            {
                error.AppendLine("Укажите участника");
            }
            if (txtPlace.Text.Length < 0 || txtPlace.Text.Length == 0 || string.IsNullOrEmpty(txtPlace.Text))
            {
                error.AppendLine("Укажите место");
            }
            if (ComboBoxIdGender.Text == "")
            {
                error.AppendLine("Укажите пол");
            }
            if (txtCompetition.Text == "")
            {
                error.AppendLine("Укажите компетенцию");
            }
            if (txtChampionship.Text == "")
            {
                error.AppendLine("Укажите название чемпионата");
            }
            if (txtResult.Text == "")
            {
                error.AppendLine("Укажите результат");
            }
            if (txtPoints.Text.Length < 0 || txtPoints.Text.Length == 0 || string.IsNullOrEmpty(txtPoints.Text))
            {
                error.AppendLine("Укажите очки");
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
                    var URow = db.PersonCompetitions.Where(id => id.ID == num).FirstOrDefault();
                    URow.Participant.Suname = Convert.ToString(txtParticipant.Text);
                    URow.Place = Convert.ToInt32(txtPlace.Text);
                    URow.Gender.NameGender = Convert.ToString(ComboBoxIdGender.Text);
                    URow.Competition.NameCompetition = Convert.ToString(txtCompetition.Text);
                    URow.Championship.NameChampionship = Convert.ToString(txtChampionship.Text);
                    URow.Result = Convert.ToString(txtResult.Text);
                    URow.Points = Convert.ToInt32(txtPoints.Text);
                    db.SaveChanges();
                    DGridPersonCompetition.ItemsSource = db.PersonCompetitions.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
