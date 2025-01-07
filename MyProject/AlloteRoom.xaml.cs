using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MyProject
{
    /// <summary>
    /// Interaction logic for AlloteRoom.xaml
    /// </summary>
    public partial class AlloteRoom : Window
    {
        string Clicked = "";
        public AlloteRoom()
        {
            InitializeComponent();
        }
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow M = new MainWindow();
            this.Hide();
            M.Show();
        }
        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            AllocateBtn.IsEnabled = false;
            //show all students
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("select p.Id,s.[Registration-no], p.Firstname,p.LastName from Person as p join Student as s on p.Id=s.Id ", con);
            SqlDataReader sqlData = cmd.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(sqlData);
            ViewGrid.RowHeaderWidth = 15;
            ViewGrid.ItemsSource = dataTable.DefaultView;
        }
        private void ViewHOstelBtn_Click(object sender, RoutedEventArgs e)
        {
            //show all hostels
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select * from hostal ", con);
            SqlDataReader sqlData = cmd.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(sqlData);
            ViewGrid.RowHeaderWidth = 15;
            ViewGrid.ItemsSource = dataTable.DefaultView;
        }
        private void AllocateBoysBtn_Click(object sender, RoutedEventArgs e)
        {
            AllocateBtn.IsEnabled = true;

            //show all boys
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("select p.Id,s.[Registration-no], p.Firstname,p.LastName from Person as p join Student as s on p.Id=s.Id where p.Gender = 'male' ", con);
            SqlDataReader sqlData = cmd.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(sqlData);
            ViewGrid.RowHeaderWidth = 15;
            ViewGrid.ItemsSource = dataTable.DefaultView;
            Clicked = "Boys";
        }
        private void AllocateGirlsBtn_Click(object sender, RoutedEventArgs e)
        {
            AllocateBtn.IsEnabled = true;
            //show all girls
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("select p.Id,s.[Registration-no], p.Firstname,p.LastName from Person as p join Student as s on p.Id=s.Id where p.Gender = 'female' ", con);
            SqlDataReader sqlData = cmd.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(sqlData);
            ViewGrid.RowHeaderWidth = 15;
            ViewGrid.ItemsSource = dataTable.DefaultView;
            Clicked = "Girls";
        }
        private void AllocateBtn_Click(object sender, RoutedEventArgs e)
        {
            AllocateBtn.IsEnabled = false;
            //allocate hosals
            if (Clicked == "Girls")
            {
                //assign girls hostel



                Clicked = "";
            }
            else if (Clicked == "Boys")
            {
                //assign boys hostel



                Clicked = "";
            }
        }
    }
}
