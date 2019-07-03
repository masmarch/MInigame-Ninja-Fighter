using MySql.Data.MySqlClient;
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
using System.Windows.Threading;

namespace TestProjectgaming
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Window
    {
        public Home()
        {
            InitializeComponent();
        }

        int status = 1;
        DispatcherTimer timer = new DispatcherTimer();

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
          
            timer.Tick += new EventHandler(dispatTick);
            timer.Interval = new TimeSpan(0, 0, 0, 0, 50);
            timer.Start();
        }

        private void dispatTick(object sender, EventArgs e)
        {
            if (status == 1)// เมื่อผู้เล่นยืนอยู่นิ่งๆ
            {
                player.Source = new BitmapImage(new Uri(@"\res\Glide2.png", UriKind.Relative));
                status = 2;
            }
            else if (status == 2)
            {
                player.Source = new BitmapImage(new Uri(@"\res\Glide3.png", UriKind.Relative));
                status = 3;
            }
            else if (status == 3)
            {
                player.Source = new BitmapImage(new Uri(@"\res\Glide4.png", UriKind.Relative));
                status = 4;
            }
            else if (status == 4)
            {
                player.Source = new BitmapImage(new Uri(@"\res\Glide5.png", UriKind.Relative));
                status = 5;
            }
            else if (status == 5)
            {
                player.Source = new BitmapImage(new Uri(@"\res\Glide6.png", UriKind.Relative));
                status = 6;
            }
            else if (status == 6)
            {
                player.Source = new BitmapImage(new Uri(@"\res\Glide7.png", UriKind.Relative));
                status = 7;
            }
            else if (status == 7)
            {
                player.Source = new BitmapImage(new Uri(@"\res\Glide8.png", UriKind.Relative));
                status = 8;
            }
            else if (status == 8)
            {
                player.Source = new BitmapImage(new Uri(@"\res\Glide9.png", UriKind.Relative));
                status = 9;
            }
            else if (status == 9)
            {
                player.Source = new BitmapImage(new Uri(@"\res\Glide10.png", UriKind.Relative));
                status = 10;
            }
            else if (status == 10)
            {
                player.Source = new BitmapImage(new Uri(@"\res\Glide1.png", UriKind.Relative));
                status = 1;

            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            playWindow1 pw1 = new playWindow1();
            pw1.Show();
            this.Hide();
        }

        private void quit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void howTo_Click(object sender, RoutedEventArgs e)
        {
            Howtoplay ht = new Howtoplay();
            ht.Show();
            this.Hide();
        }

        private void shopItem_Click(object sender, RoutedEventArgs e)
        {
            shop1 sh = new shop1();
            sh.Show();
            this.Hide();
        }
    }
}
