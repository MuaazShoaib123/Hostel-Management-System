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

namespace MyProject
{
    /// <summary>
    /// Interaction logic for FinePanel.xaml
    /// </summary>
    public partial class FinePanel : Window
    {
        public FinePanel()
        {
            InitializeComponent();
        }
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow M = new MainWindow();
            M.Show();
            this.Hide();
        }
        //COMIT BUTTON
        private void ComitFineBtn_Click(object sender, RoutedEventArgs e)
        {
            ShowFinePanel();
            ComitFineButton.Content = "COMMIT";
        }
        //UPDATE BUTTON
        private void UpdateFineBtn_Click(object sender, RoutedEventArgs e)
        {
            ShowFinePanel();
            ComitFineButton.Content = "UPDATE";
        }
        //REMOVE BUTTON
        private void DeleteFineBtn_Click(object sender, RoutedEventArgs e)
        {
            ShowFinePanel();
            ComitFineButton.Content = "REMOVE";
        }
        //RETREIVE BUTTON
        private void RetreiveFineBtn_Click(object sender, RoutedEventArgs e)
        {
            ShowFinePanel();
            SelectStudentBtn.IsEnabled = false;
            ComitFineButton.Visibility = Visibility.Collapsed;
        }
        //SHOW PANEL
        private void ShowFinePanel()
        {
            FinePanel1.Visibility = Visibility.Visible;
            StudentViewPanel.Visibility = Visibility.Visible;
            SelectStudentBtn.IsEnabled = true;
            ComitFineButton.Visibility = Visibility.Visible;
        }
    }
}
