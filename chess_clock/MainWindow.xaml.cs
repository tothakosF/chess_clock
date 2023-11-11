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
        public int ctime, btime, wtime;
        public DispatcherTimer timer;
        public MainWindow()
        {
            InitializeComponent();
            var timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1) };
            timer.Tick += timer_Tick;
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();
        }

        public void Load()
        {
            whiteL.Visibility = Visibility.Collapsed;
            whiteB.Visibility = Visibility.Collapsed;
            blackL.Visibility = Visibility.Collapsed;
            blackB.Visibility = Visibility.Collapsed;
            tenB.Visibility = Visibility.Visible;
            fiveB.Visibility = Visibility.Visible;
            oneB.Visibility = Visibility.Visible;
            idoL.Visibility = Visibility.Visible;
            whiteL.Foreground = Brushes.White;
            blackL.Foreground = Brushes.White;
        }

        private void Main_Window_Loaded(object sender, RoutedEventArgs e)
        {
            Load();
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
                    MessageBox.Show("Lejárt az idő!");
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
                    MessageBox.Show("Lejárt az idő!");
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
            whiteL.Foreground = Brushes.Red;
            blackL.Foreground = Brushes.White;
            blackB.Visibility = Visibility.Collapsed;
            whiteB.Visibility = Visibility.Collapsed;
        }

        private void blackB_Click(object sender, RoutedEventArgs e)
        {
            isActiveB = true;
            whiteL.Foreground = Brushes.White;
            blackL.Foreground = Brushes.Red;
            blackB.Visibility = Visibility.Collapsed;
            whiteB.Visibility = Visibility.Collapsed;
        }

        private void closeL_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Main_Window.Close();
        }

        private void resetL_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Load();
            isActiveB= false;
            isActiveW= false;
        }

        private void Main_Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                if (isActiveB)
                {
                    isActiveB = false;
                    isActiveW = true;
                    whiteL.Foreground = Brushes.Red;
                    blackL.Foreground = Brushes.White;
                    string bszam = whiteL.Content.ToString();
                    if (bszam.Length == 4)
                    {
                        int bmin = Convert.ToInt32(bszam.Substring(0, 1));
                        int bsec = Convert.ToInt32(bszam.Substring(2, 2));
                        int bossz = bmin * 60 + bsec;
                        ctime = bossz;
                    }
                    else if (bszam.Length == 3)
                    {
                        int bmin = Convert.ToInt32(bszam.Substring(0, 1));
                        int bsec = Convert.ToInt32(bszam.Substring(2, 1));
                        int bossz = bmin * 60 + bsec;
                        ctime = bossz;
                    }
                }
                else if (isActiveW)
                {
                    isActiveW = false;
                    isActiveB = true;
                    blackL.Foreground = Brushes.Red;
                    whiteL.Foreground = Brushes.White;
                    string wszam = blackL.Content.ToString();
                    if (wszam.Length == 4)
                    {
                        int wmin = Convert.ToInt32(wszam.Substring(0, 1));
                        int wsec = Convert.ToInt32(wszam.Substring(2, 2));
                        int wossz = wmin * 60 + wsec;
                        ctime = wossz;
                    }
                    else if (wszam.Length == 3)
                    {
                        int wmin = Convert.ToInt32(wszam.Substring(0, 1));
                        int wsec = Convert.ToInt32(wszam.Substring(2, 1));
                        int wossz = wmin * 60 + wsec;
                        ctime = wossz;
                    }
                }
            }
        }
    }
}
