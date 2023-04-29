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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MyProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void StudentButton_Click(object sender, RoutedEventArgs e)
        {
            StudentPanel S = new StudentPanel();
            S.Show();
            this.Hide();
        }
        private void FineButton_Click(object sender, RoutedEventArgs e)
        {
            FinePanel F = new FinePanel();
            F.Show();
            this.Hide();
        }
        private void LogOutButton_Click(object sender, RoutedEventArgs e)
        {
            LogInFrom L = new LogInFrom();
            L.Show();
            this.Hide();
        }
        private void HostelButton_Click(object sender, RoutedEventArgs e)
        {
            AddHostelPanel A = new AddHostelPanel();
            A.Show();
            this.Hide();
        }
        private void AllocateButton_Click(object sender, RoutedEventArgs e)
        {
            AlloteRoom A = new AlloteRoom();
            A.Show();
            this.Hide();
        }
        private void DeusButton_Click(object sender, RoutedEventArgs e)
        {
            DeusPanel D = new DeusPanel();
            D.Show();
            this.Hide();
        }
        private void VisitorButton_Click(object sender, RoutedEventArgs e)
        {
            ViewComplainPanel V = new ViewComplainPanel();
            V.Show();
            this.Hide();
        }
    }
}
