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
    /// Interaction logic for ViewComplainPanel.xaml
    /// </summary>
    public partial class ViewComplainPanel : Window
    {
        public ViewComplainPanel()
        {
            InitializeComponent();
        }
        private void BackItem_Click(object sender, RoutedEventArgs e)
        {
            MainWindow M = new MainWindow();
            this.Hide();
            M.Show();
        }
        private void ViewItwm_Click(object sender, RoutedEventArgs e)
        {
            DeletePanel.Visibility = Visibility.Collapsed;
            ViewPanel.Visibility = Visibility.Visible;
        }

        private void DeleteItem_Click(object sender, RoutedEventArgs e)
        {
            DeletePanel.Visibility = Visibility.Visible;
            ViewPanel.Visibility = Visibility.Collapsed;
        }
        private void CloseBtn1_Click(object sender, RoutedEventArgs e)
        {
            DeletePanel.Visibility = Visibility.Collapsed;
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            ViewPanel.Visibility = Visibility.Collapsed;
        }
    }
}
