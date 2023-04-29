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
using System.Data.SqlClient;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data;

namespace MyProject
{
    /// <summary>
    /// Interaction logic for StudentPanel.xaml
    /// </summary>
    /// //ADDD//
    public partial class StudentPanel : Window
    {
        int a;
        public StudentPanel()
        {
            InitializeComponent();
        }
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow M = new MainWindow();
            M.Show();
            this.Hide();
        }
        //ADD STUDENT
        private void AddStudentBtn_Click(object sender, RoutedEventArgs e)
        {
            RetreivePanel.Visibility = Visibility.Collapsed;
            StudentLabel.Text = "CREATE";
            ComitBtn.Content = "ADD";
            ShowAddPanel();
        }
        //UPDATE STUDENT
        private void UpdateStudentBtn_Click(object sender, RoutedEventArgs e)
        {
            RetreivePanel.Visibility = Visibility.Collapsed;
            StudentLabel.Text = "UPDATE";
            ComitBtn.Content = "UPDATE";
            ShowAddPanel();
        }
        //REMOVE STUDENT
        private void DeleteStudentBtn_Click(object sender, RoutedEventArgs e)
        {
            RetreivePanel.Visibility = Visibility.Collapsed;
            StudentLabel.Text = "REMOVE";
            ComitBtn.Content = "REMOVE";
            ShowAddPanel();
        }
        //RETREIVE STUDENT
        private void RetreiveStudentBtn_Click(object sender, RoutedEventArgs e)
        {
            HideAddPanel();
            RetreivePanel.Visibility = Visibility.Visible;
        }
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            RetreivePanel.Visibility = Visibility.Collapsed;
        }

        private void PdfStudentBtn_Click(object sender, RoutedEventArgs e)
        {
            HideAddPanel();
        }
        private void CloseIcon_MouseDown(object sender, MouseButtonEventArgs e)
        {
            HideAddPanel();
        }
        private void ShowAddPanel()
        {
            StuPanel.Visibility = Visibility.Visible;
            StuPanel1.Visibility = Visibility.Visible;
        }
        private void HideAddPanel()
        {
            StuPanel.Visibility = Visibility.Collapsed;
            StuPanel1.Visibility = Visibility.Collapsed;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void studentsGridView_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            //  studentsGridView.ItemsSource = null;
            var selectedRow = studentsGridView.SelectedItem as DataRowView;

            // Get the value of the first cell in the selected row
            int id = (int)selectedRow.Row.ItemArray[0];
            RegNoNameBox.Text = (string)selectedRow.Row.ItemArray[1];
            FirstNameBox.Text = (string)selectedRow.Row.ItemArray[2];
            LastNameBox.Text = (string)selectedRow.Row.ItemArray[3];
            ContactNameBox.Text = (string)selectedRow.Row.ItemArray[5];
            EmailNameBox.Text = (string)selectedRow.Row.ItemArray[4];
            a = (int)(selectedRow.Row.ItemArray[6]);

            ResultBox.Text = a.ToString();

            /* if ("Male" == (string)selectedRow.Row.ItemArray[6])
               {
                   MaleButton.Content = (string)selectedRow.Row.ItemArray[6];

               }
               else
               {
                   FemaleButton.Content = (string)selectedRow.Row.ItemArray[6];

               }*/

            // RegNoNameBox = int.Parse(selectedRow.Row.ItemArray[0].ToString());

            /*  RegistrationNumber = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
              FirstName = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
              LastName = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
              Contact = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
              DOB = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
              Email = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
              if (dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString() == "Male")
              {
                  GEnder = 1;
              }
              else { GEnder = 2; }*/
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("select p.id,s.[Registration-no] ,p.Firstname ,p.Lastname,p.Email,p.contact,r.Cgpa from Person as p \r\njoin Student as s\r\n on s.Id=p.Id\r\n join Regular r\r\n on s.Id=r.sid \r\njoin NonRegular nr \r\non nr.sid=s.Id ");
            cmd.Connection = con;
            SqlDataReader sqlData = cmd.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(sqlData);

            studentsGridView.RowHeaderWidth = 15;
            studentsGridView.ItemsSource = dataTable.DefaultView;
        }
    }
}
