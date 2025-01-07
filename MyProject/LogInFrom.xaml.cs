using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Data.SqlClient;

using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Text.RegularExpressions;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MyProject
{
    /// <summary>
    /// Interaction logic for LogInFrom.xaml
    /// </summary>
    public partial class LogInFrom : Window
    {
        public LogInFrom()
        {
            InitializeComponent();
        }

        private void AddStudentBtn_Click(object sender, RoutedEventArgs e)
        {
            SignInPanel.Visibility = Visibility.Visible;
        }

        private void UpdateStudentBtn_Click(object sender, RoutedEventArgs e)
        {
            SignUpPanel.Visibility = Visibility.Visible;
        }

        private void CloseIcon_MouseDown(object sender, MouseButtonEventArgs e)
        {
            HidePanel();
        }
        private void HidePanel()
        {
            SignInPanel.Visibility = Visibility.Collapsed;
            SignUpPanel.Visibility = Visibility.Collapsed;
        }
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RetreiveStudentBtn_Click(object sender, RoutedEventArgs e)
        {


        }


        private void SignUpButton1_Click_1(object sender, RoutedEventArgs e)
        {
            string passwordLength = PasswordBoxUp.Password;
            string studentPattren = "@student.uet.edu.pk$";
            string AdminPattren = "@admin.uet.edu.pk$";
            Regex regex = new Regex(studentPattren);
            Regex regex2 = new Regex(AdminPattren);
            Regex pLength = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$");
            // for password
            //  bool isMatch = regex.IsMatch(PasswordBoxUp.Text);

           // MessageBox.Show(passwordLength);
            if (regex.IsMatch(EmailBoxUp.Text))
            {
                if (pLength.IsMatch(passwordLength))
                {
                    if (PasswordBoxUp.Password == ConfirmPasswordBoxUp.Password)
                    {
                        var con = Configuration.getInstance().getConnection();
                        SqlCommand cmd = new SqlCommand("INSERT INTO [dbo].[login](Username,password) VALUES (@Username,@password)", con);
                        cmd.Parameters.AddWithValue("@Username", EmailBoxUp.Text);
                        cmd.Parameters.AddWithValue("@password", PasswordBoxUp.Password);
                        cmd.ExecuteNonQuery();
                        //  cmd1.ExecuteNonQuery();
                        //cmd.Parameters.AddWithValue("@confirmpassword", ConfirmPasswordBoxUp.Password);
                        MessageBox.Show("succesfully");


                    }
                  //  MessageBox.Show("atleast length");

                    //  Console.WriteLine($"The input string '{PasswordBoxUp.Password}' is at least {passwordLength} characters long.");

                }
                else
                {
                    MessageBox.Show("At least one small and one capital and one digit and one special character with atleast length of 8 character");
                    //Console.WriteLine($"The input string '{PasswordBoxUp.Password}' is less than {passwordLength} characters long.");
                }
            }
            else
            {
                {
                    MessageBox.Show("Please write email in given pattern");
                    // Console.WriteLine("String does not end with 's'.");
                }
            }
            //end password

            // Console.Write("Enter a string: ");
            // string input = Console.ReadLine();

            /* if (regex.IsMatch(EmailBoxUp.Text))
             {
                 MessageBox.Show("successfully student signup");
             }*/
            /*    else
                { 
                    MessageBox.Show("Please write email in given pattern");
                    // Console.WriteLine("String does not end with 's'.");
                }*/

            /*if (regex2.IsMatch(EmailBoxUp.Text))
            {
                MessageBox.Show("successfully Admin signup");
            }
            else
            {
                MessageBox.Show("Please write email in given pattern");
                // Console.WriteLine("String does not end with 's'.");
            }*/
        }

        private void SignInButton_Click_1(object sender, RoutedEventArgs e)
        {
            /* var con = Configuration.getInstance().getConnection();
             SqlCommand cmd = new SqlCommand("select l.Username,l.password from Login as l where l.Username = '" + EmailBox.Text + "'  and l.password ='"+PasswordBox.Password+"'",con);


            SqlDataReader sqlData = cmd.ExecuteReader();
             if (sqlData["Username"].ToString() == EmailBox.Text)
             {
                 MessageBox.Show("safddf");
             }*/


            ApplyPanel A = new ApplyPanel(EmailBox.Text, PasswordBox.Password);
            A.Show();
            this.Hide();
            MessageBox.Show("fredsf");
        }
    }
}

