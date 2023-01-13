using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.RightsManagement;
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
        public bool isActiveW, isActiveB;
        public int ctime;
        public DispatcherTimer timer;
        public MainWindow()
        {
            InitializeComponent();
            var timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1) };
            timer.Tick += timer_Tick;
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();
        }

        public void Lodid()
        {
            whiteL.Visibility = Visibility.Collapsed;
            whiteB.Visibility = Visibility.Collapsed;
            blackL.Visibility = Visibility.Collapsed;
            blackB.Visibility = Visibility.Collapsed;
            tenB.Visibility = Visibility.Visible;
            fiveB.Visibility = Visibility.Visible;
            oneB.Visibility = Visibility.Visible;
            idoL.Visibility = Visibility.Visible;
        }

        private void FoWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Lodid();
        }
        void timer_Tick(object sender, EventArgs e)
        {
            if (isActiveW)
            {
                if (ctime > 1)
                {
                    ctime--;
                    whiteL.Content = string.Format("{0}:{1}", ctime / 60, ctime % 60);
                }
                else
                {
                    MessageBox.Show("Vesztett a fehér!");
                }
            }
            if (isActiveB)
            {
                if (ctime > 1)
                {
                    ctime--;
                    blackL.Content = string.Format("{0}:{1}", ctime / 60, ctime % 60);
                }
                else
                {
                    MessageBox.Show("Vesztett a fekete!");
                }
            }
        }

        private void tenB_Click(object sender, RoutedEventArgs e)
        {
            ctime = 600;
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
            ctime = 300;
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
            ctime = 60;
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

        private void whiteB_Click(object sender, RoutedEventArgs e)
        {
            isActiveW = true;
            blackB.Visibility = Visibility.Collapsed;
            whiteB.Visibility = Visibility.Collapsed;
        }

        private void blackB_Click(object sender, RoutedEventArgs e)
        {
            isActiveB = true;
            blackB.Visibility = Visibility.Collapsed;
            whiteB.Visibility = Visibility.Collapsed;
        }

        private void closeL_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            FoWindow.Close();
        }

        private void resetL_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Lodid();
            isActiveB= false;
            isActiveW= false;
        }

        private void FoWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                if (isActiveB)
                {
                    isActiveB = false;
                    isActiveW = true;
                }
                else
                {
                    isActiveW = false;
                    isActiveB = true;
                }
            }
        }
    }
}
