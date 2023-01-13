using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
using System.Windows.Threading;

namespace chess_clock
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int ctime;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void FoWindow_Loaded(object sender, RoutedEventArgs e)
        {
            whiteL.Visibility = Visibility.Collapsed;
            whiteB.Visibility = Visibility.Collapsed;
            blackL.Visibility = Visibility.Collapsed;
            blackB.Visibility = Visibility.Collapsed;
            var timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1) };
            timer.Tick += timer_Tick;
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();
        }
        private void timer_Tick(object sender, EventArgs e)
        { 

        }

        private void tenB_Click(object sender, RoutedEventArgs e)
        {
            ctime = 10;
            whiteB.Visibility = Visibility.Visible;
            whiteL.Visibility = Visibility.Visible;
            blackB.Visibility = Visibility.Visible;
            blackL.Visibility = Visibility.Visible;
            whiteL.Content = "10:00";
            blackL.Content = "10:00";
            idoL.Visibility = Visibility.Collapsed;
            tenB.Visibility = Visibility.Collapsed;
            fiveB.Visibility = Visibility.Collapsed;
            oneB.Visibility = Visibility.Collapsed;
        }

        private void fiveB_Click(object sender, RoutedEventArgs e)
        {
            ctime = 5;
            whiteB.Visibility = Visibility.Visible;
            whiteL.Visibility = Visibility.Visible;
            blackB.Visibility = Visibility.Visible;
            blackL.Visibility = Visibility.Visible;
            whiteL.Content = "5:00";
            blackL.Content = "5:00";
            idoL.Visibility = Visibility.Collapsed;
            tenB.Visibility = Visibility.Collapsed;
            fiveB.Visibility = Visibility.Collapsed;
            oneB.Visibility = Visibility.Collapsed;
        }

        private void oneB_Click(object sender, RoutedEventArgs e)
        {
            ctime = 1;
            whiteB.Visibility = Visibility.Visible;
            whiteL.Visibility = Visibility.Visible;
            blackB.Visibility = Visibility.Visible;
            blackL.Visibility = Visibility.Visible;
            whiteL.Content = "1:00";
            blackL.Content = "1:00";
            idoL.Visibility = Visibility.Collapsed;
            tenB.Visibility = Visibility.Collapsed;
            fiveB.Visibility = Visibility.Collapsed;
            oneB.Visibility = Visibility.Collapsed;
        }
    }
}
