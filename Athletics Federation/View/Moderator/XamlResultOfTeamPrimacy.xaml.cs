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
    /// Логика взаимодействия для XamlResultOfTeamPrimacy.xaml
    /// </summary>
    public partial class XamlResultOfTeamPrimacy : Window
    {
        AthleticsFederationDatabaseEntities db;
        public XamlResultOfTeamPrimacy()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            db = new AthleticsFederationDatabaseEntities();
            DGridResultOfTeamPrimacy.ItemsSource = db.ResultOfTeamPrimacies.ToList();
        }

        private void Insert_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder error = new StringBuilder();

            if (txtId.Text.Length < 0 || txtId.Text.Length == 0 || string.IsNullOrEmpty(txtId.Text))
            {
                error.AppendLine("Укажите номер");
            }
            if (txtChampionship.Text == "")
            {
                error.AppendLine("Укажите название чемпионата");
            }
            if (txtPlace.Text == "")
            {
                error.AppendLine("Укажите Место");
            }
            if (txtTeam.Text == "")
            {
                error.AppendLine("Укажите название команду");
            }
            if (txtPoints.Text == "")
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
                    ViewModel.ViewResultOfTeamPrimacy viewResultOfTeamPrimacy = new ViewModel.ViewResultOfTeamPrimacy();
                    viewResultOfTeamPrimacy.AddChampionship(Convert.ToInt32(txtChampionship.Text), Convert.ToInt32(txtPlace.Text),
                        Convert.ToInt32(txtTeam.Text), Convert.ToInt32(txtPoints));
                    DGridResultOfTeamPrimacy.ItemsSource = db.ResultOfTeamPrimacies.ToList();
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
                        var DRow = db.ResultOfTeamPrimacies.Where(w => w.ID == num).FirstOrDefault();
                        db.ResultOfTeamPrimacies.Remove(DRow);
                        db.SaveChanges();
                        DGridResultOfTeamPrimacy.ItemsSource = db.ResultOfTeamPrimacies.ToList();
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
            if (txtChampionship.Text == "")
            {
                error.AppendLine("Укажите название чемпионата");
            }
            if (txtPlace.Text == "")
            {
                error.AppendLine("Укажите Место");
            }
            if (txtTeam.Text == "")
            {
                error.AppendLine("Укажите название команду");
            }
            if (txtPoints.Text == "")
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
                    var URow = db.ResultOfTeamPrimacies.Where(id => id.ID == num).FirstOrDefault();
                    URow.Championship.NameChampionship = Convert.ToString(txtChampionship.Text);
                    URow.Place = Convert.ToInt32(txtPlace.Text);
                    URow.Team.NameTeam = Convert.ToString(txtTeam.Text);
                    URow.Points = Convert.ToInt32(txtPoints.Text);
                    db.SaveChanges();
                    DGridResultOfTeamPrimacy.ItemsSource = db.ResultOfTeamPrimacies.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
