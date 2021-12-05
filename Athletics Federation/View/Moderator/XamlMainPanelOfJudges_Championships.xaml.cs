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
    /// Логика взаимодействия для XamlMainPanelOfJudges_Championships.xaml
    /// </summary>
    public partial class XamlMainPanelOfJudges_Championships : Window
    {
        AthleticsFederationDatabaseEntities db;
        public XamlMainPanelOfJudges_Championships()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            db = new AthleticsFederationDatabaseEntities();
            DGridXamlMainPanelOfJudges_Championships.ItemsSource = db.MainPanelOfJudges_Championships.ToList();
        }

        private void Insert_Click(object sender, RoutedEventArgs e)
        {
            MainPanelOfJudges_Championships MPOfJ_Ch = new MainPanelOfJudges_Championships();

            StringBuilder error = new StringBuilder();
            if (txtId.Text.Length < 0 || txtId.Text.Length == 0 || string.IsNullOrEmpty(txtId.Text))
            {
                error.AppendLine("Укажите номер");
            }
            if (txtIdChampionship.Text.Length < 0 || txtIdChampionship.Text.Length == 0 || string.IsNullOrEmpty(txtIdChampionship.Text))
            {
                error.AppendLine("Укажите номер");
            }
            if (txtIdJudge.Text.Length < 0 || txtIdJudge.Text.Length == 0 || string.IsNullOrEmpty(txtIdJudge.Text))
            {
                error.AppendLine("Укажите номер");
            }

            if (error.Length > 0)
            {
                MessageBox.Show(error.ToString());
            }
            else
            {
                try
                {
                    MPOfJ_Ch.ID = Convert.ToInt32(txtId.Text);
                    MPOfJ_Ch.IdChampionship = Convert.ToInt32(txtIdChampionship.Text);
                    MPOfJ_Ch.IdMainPanelOfJudges = Convert.ToInt32(txtIdJudge.Text);

                    db.MainPanelOfJudges_Championships.Add(MPOfJ_Ch);
                    db.SaveChanges();
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
                try
                {
                    int num = Convert.ToInt32(txtId.Text);
                    var DRow = db.MainPanelOfJudges_Championships.Where(w => w.ID == num).FirstOrDefault();
                    db.MainPanelOfJudges_Championships.Remove(DRow);
                    db.SaveChanges();
                    DGridXamlMainPanelOfJudges_Championships.ItemsSource = db.MainPanelOfJudges_Championships.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
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
            if (txtIdChampionship.Text.Length < 0 || txtIdChampionship.Text.Length == 0 || string.IsNullOrEmpty(txtIdChampionship.Text))
            {
                error.AppendLine("Укажите номер");
            }
            if (txtIdJudge.Text.Length < 0 || txtIdJudge.Text.Length == 0 || string.IsNullOrEmpty(txtIdJudge.Text))
            {
                error.AppendLine("Укажите номер");
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
                    var URow = db.MainPanelOfJudges_Championships.Where(id => id.ID == num).FirstOrDefault();
                    URow.IdChampionship = Convert.ToInt32(txtIdChampionship.Text);
                    URow.IdMainPanelOfJudges = Convert.ToInt32(txtIdJudge.Text);
                    db.SaveChanges();
                    DGridXamlMainPanelOfJudges_Championships.ItemsSource = db.MainPanelOfJudges_Championships.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
