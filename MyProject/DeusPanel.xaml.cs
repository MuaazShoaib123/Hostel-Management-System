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
    /// Interaction logic for DeusPanel.xaml
    /// </summary>
    public partial class DeusPanel : Window
    {
        public DeusPanel()
        {
            InitializeComponent();
        }
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow M = new MainWindow();
            M.Show();
            this.Hide();
        }
        private void AssignBtn_Click(object sender, RoutedEventArgs e)
        {
            AssignPanel1.Visibility = Visibility.Visible;
            HideUpdatePanel();
        }
        private void RetreievBtn_Click(object sender, RoutedEventArgs e)
        {
            AssignPanel1.Visibility = Visibility.Collapsed;
            HideUpdatePanel();
            RetreievePanel.Visibility = Visibility.Visible; 
        }
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            HideUpdatePanel();
            RetreievePanel.Visibility = Visibility.Visible;
        }
        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            RetreievePanel.Visibility = Visibility.Collapsed;
            AssignPanel1.Visibility = Visibility.Collapsed;
            ShowUpdatePanel();
            ComitDeusButton.Content = "UPDATE";
        }
        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            RetreievePanel.Visibility = Visibility.Collapsed;
            AssignPanel1.Visibility = Visibility.Collapsed;
            ShowUpdatePanel();
            ComitDeusButton.Content = "REMOVE";
        }
        private void ShowUpdatePanel()
        {
            StudentViewPanel.Visibility = Visibility.Visible;
            DuesPanel.Visibility = Visibility.Visible;
        }
        private void HideUpdatePanel()
        {
            StudentViewPanel.Visibility = Visibility.Collapsed;
            DuesPanel.Visibility = Visibility.Collapsed;
        }

        private void ComitDeusButton_Click_1(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
