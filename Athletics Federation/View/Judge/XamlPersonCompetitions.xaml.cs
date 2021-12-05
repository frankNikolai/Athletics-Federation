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

namespace Athletics_Federation.View.Judge
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

        private void Update_Click(object sender, RoutedEventArgs e)
        {
             StringBuilder error = new StringBuilder();
            if (txtId.Text.Length < 0 || txtId.Text.Length == 0 || string.IsNullOrEmpty(txtId.Text))
            {
                error.AppendLine("Укажите номер");
            }
            if (txtResult.Text == "")
            {
                error.AppendLine("Укажите Результат");
            }
            if (string.IsNullOrEmpty(txtPlace.Text))
            {
                error.AppendLine("Укажите Место");
            }
            if (string.IsNullOrEmpty(txtPoints.Text))
            {
                error.AppendLine("Укажите Очки");
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
                    URow.ID = Convert.ToInt32(txtId.Text);
                    URow.Place = Convert.ToInt32(txtPlace.Text);
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
