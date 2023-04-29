using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Data.SqlClient;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MyProject
{
    /// <summary>
    /// Interaction logic for ApplyPanel.xaml
    /// </summary>
    public partial class ApplyPanel : Window
    {
        string CHECKUsername, CHECKPassword;
        public ApplyPanel(string Username, string Password)
        {
            CHECKUsername = Username;
            CHECKPassword = Password;
            InitializeComponent();
        }
        private void BackNextPanelBtn_Click(object sender, RoutedEventArgs e)
        {
            NextPanel.Visibility = Visibility.Collapsed;
            ShowApplyPanel();
        }

        private void NextBtn_Click(object sender, RoutedEventArgs e)
        {
            HideApplyPanel();
            NextPanel.Visibility = Visibility.Visible;
        }
        private void ShowApplyPanel()
        {
            ApplyPanel1.Visibility = Visibility.Visible;
            ApplyPanel2.Visibility = Visibility.Visible;
        }
        private void HideApplyPanel()
        {
            ApplyPanel1.Visibility = Visibility.Collapsed;
            ApplyPanel2.Visibility = Visibility.Collapsed;
        }

        private void CloseApplyPanelBtn_Click(object sender, RoutedEventArgs e)
        {
            HideApplyPanel();
        }

        private void ApplyBtn1_Click(object sender, RoutedEventArgs e)
        {
            ShowApplyPanel();
        }

        private void CloseNextPanelBtn_Click(object sender, RoutedEventArgs e)
        {
            ApplyPanel2.Visibility = Visibility.Collapsed;
        }

        private void StatusBtn1_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ApplyBtn_Click_1(object sender, RoutedEventArgs e)
        {
           // MessageBox.Show(CHECKUsername);
          //  MessageBox.Show(CHECKPassword);
            int gender = 0;
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("INSERT INTO [dbo].[Person](FirstName,LastName,Contact,Email,Gender) VALUES (@FirstName,@LastName, @Contact,@Email, @Gender)", con);
            SqlCommand cmd1 = new SqlCommand("insert into [dbo].[Student](Id,Username,Password,[Registration-no]) VALUES ((SELECT Id FROM Person WHERE FirstName = @FirstName AND LastName=@LastName AND Contact=@Contact AND Email=@Email  AND Gender=@Gender) ,@Username,@Password,@RegistrationNo)", con);
            SqlCommand cmd2 = new SqlCommand("insert into [dbo].[Regular](SId,CGPA,semester) VALUES ((SELECT Id FROM Person WHERE FirstName = @FirstName AND LastName=@LastName AND Contact=@Contact AND Email=@Email  AND Gender=@Gender) ,@CGPA,@semester)", con);
            SqlCommand cmd3 = new SqlCommand("insert into [dbo].[NonRegular](SId,MatricMarks,FSCMarks,EcatMarks) VALUES ((SELECT Id FROM Person WHERE FirstName = @FirstName AND LastName=@LastName AND Contact=@Contact AND Email=@Email  AND Gender=@Gender) ,@MatricMarks,@FSCMarks,@EcatMarks)", con);


            cmd.Parameters.AddWithValue("@FirstName", FirstNameBox.Text);
            cmd.Parameters.AddWithValue("@LastName", LastNameBox.Text);
            cmd.Parameters.AddWithValue("@Contact", ContactNameBox.Text);
            cmd.Parameters.AddWithValue("@Email", EmailNameBox.Text);
            cmd.Parameters.AddWithValue("@RegistrationNo", RegNoNameBox.Text);
            /*    cmd.Parameters.AddWithValue("@Username", Username);
                cmd.Parameters.AddWithValue("@Password", Password);*/
            cmd1.Parameters.AddWithValue("@FirstName", FirstNameBox.Text);
            cmd1.Parameters.AddWithValue("@LastName", LastNameBox.Text);
            cmd1.Parameters.AddWithValue("@Contact", ContactNameBox.Text);
            cmd1.Parameters.AddWithValue("@Email", EmailNameBox.Text);
            cmd1.Parameters.AddWithValue("@RegistrationNo", RegNoNameBox.Text);
            cmd1.Parameters.AddWithValue("@Username", CHECKUsername);
            cmd1.Parameters.AddWithValue("@Password", CHECKPassword);
            cmd2.Parameters.AddWithValue("@FirstName", FirstNameBox.Text);
            cmd2.Parameters.AddWithValue("@LastName", LastNameBox.Text);
            cmd2.Parameters.AddWithValue("@Contact", ContactNameBox.Text);
            cmd2.Parameters.AddWithValue("@Email", EmailNameBox.Text);
            cmd2.Parameters.AddWithValue("@RegistrationNo", RegNoNameBox.Text);
            cmd2.Parameters.AddWithValue("@Username", CHECKUsername);
            cmd2.Parameters.AddWithValue("@Password", CHECKPassword);
            cmd3.Parameters.AddWithValue("@FirstName", FirstNameBox.Text);
            cmd3.Parameters.AddWithValue("@LastName", LastNameBox.Text);
            cmd3.Parameters.AddWithValue("@Contact", ContactNameBox.Text);
            cmd3.Parameters.AddWithValue("@Email", EmailNameBox.Text);
            cmd3.Parameters.AddWithValue("@Username", CHECKUsername);
            cmd3.Parameters.AddWithValue("@Password", CHECKPassword);
            cmd3.Parameters.AddWithValue("@RegistrationNo", RegNoNameBox.Text);
            if (MaleButton.Content == "Male")
            {
                cmd.Parameters.AddWithValue("@Gender", MaleButton.Content);
                cmd1.Parameters.AddWithValue("@Gender", MaleButton.Content);
                cmd2.Parameters.AddWithValue("@Gender", MaleButton.Content);
                cmd3.Parameters.AddWithValue("@Gender", MaleButton.Content);
            }
            else
            {
                cmd.Parameters.AddWithValue("@Gender", FemaleButton.Content);
                cmd1.Parameters.AddWithValue("@Gender", FemaleButton.Content);
                cmd2.Parameters.AddWithValue("@Gender", FemaleButton.Content);
                cmd3.Parameters.AddWithValue("@Gender", FemaleButton.Content);

            }
            /* BirthDatePicker.Format = BirthDatePicker.Custom;
             BirthDatePicker.CustomFormat = "yyyy-MM-dd";*/
            // cmd.Parameters.AddWithValue("@Gender", gender);
            //cmd1.Parameters.AddWithValue("@Gender", gender);
            /*  cmd.Parameters.AddWithValue("@DOB", BirthDatePicker.Text);
              cmd1.Parameters.AddWithValue("@DOB", BirthDatePicker.Text); 
              cmd2.Parameters.AddWithValue("@DOB", BirthDatePicker.Text);
              cmd3.Parameters.AddWithValue("@DOB", BirthDatePicker.Text);*/
            if (RegularBtn.Content == "Regular")
            {
                cmd.Parameters.AddWithValue("@CGPA", 3);
                cmd1.Parameters.AddWithValue("@CGPA", 3);
                cmd2.Parameters.AddWithValue("@CGPA", 3);
                cmd3.Parameters.AddWithValue("@CGPA", 3);
                cmd.Parameters.AddWithValue("@semester", 5);
                cmd1.Parameters.AddWithValue("@semester", 5);
                cmd2.Parameters.AddWithValue("@semester", 5);
                cmd3.Parameters.AddWithValue("@semester", 5);
            }
            else if (NonRegularBtn.Content == "Non_Regular")
            {
                cmd.Parameters.AddWithValue("@CGPA", 1);
                cmd1.Parameters.AddWithValue("@CGPA", 1);
                cmd2.Parameters.AddWithValue("@CGPA", 1);
                cmd3.Parameters.AddWithValue("@CGPA", 1);
                cmd.Parameters.AddWithValue("@semester", 1);
                cmd1.Parameters.AddWithValue("@semester", 1);
                cmd2.Parameters.AddWithValue("@semester", 1);
                cmd3.Parameters.AddWithValue("@semester", 1);

            }
            else
            {
                cmd.Parameters.AddWithValue("@CGPA", 1);
                cmd1.Parameters.AddWithValue("@CGPA", 1);
                cmd2.Parameters.AddWithValue("@CGPA", 1);
                cmd3.Parameters.AddWithValue("@CGPA", 1);
                cmd.Parameters.AddWithValue("@semester", 1);
                cmd1.Parameters.AddWithValue("@semester", 1);
                cmd2.Parameters.AddWithValue("@semester", 1);
                cmd3.Parameters.AddWithValue("@semester", 1);

            }
            cmd.Parameters.AddWithValue("@MatricMarks", int.Parse(Matrictxt.Text));
            cmd.Parameters.AddWithValue("@FSCMarks", int.Parse(FscTxtbox.Text));
            cmd.Parameters.AddWithValue("@EcatMarks", int.Parse(Ecattxtbox.Text));
            cmd1.Parameters.AddWithValue("@MatricMarks", int.Parse(Matrictxt.Text));
            cmd1.Parameters.AddWithValue("@FSCMarks", int.Parse(FscTxtbox.Text));
            cmd1.Parameters.AddWithValue("@EcatMarks", int.Parse(Ecattxtbox.Text));
            cmd2.Parameters.AddWithValue("@MatricMarks", int.Parse(Matrictxt.Text));
            cmd2.Parameters.AddWithValue("@FSCMarks", int.Parse(FscTxtbox.Text));
            cmd2.Parameters.AddWithValue("@EcatMarks", int.Parse(Ecattxtbox.Text));
            cmd3.Parameters.AddWithValue("@MatricMarks", int.Parse(Matrictxt.Text));
            cmd3.Parameters.AddWithValue("@FSCMarks", int.Parse(FscTxtbox.Text));
            cmd3.Parameters.AddWithValue("@EcatMarks", int.Parse(Ecattxtbox.Text))
                ;
            cmd.ExecuteNonQuery();
            cmd1.ExecuteNonQuery();
            cmd2.ExecuteNonQuery();
            cmd3.ExecuteNonQuery();
            MessageBox.Show("Successfully saved");
        }
    }
}
