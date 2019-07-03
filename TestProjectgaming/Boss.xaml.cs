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
    /// Interaction logic for Boss.xaml
    /// </summary>
    public partial class Boss : Window
    {
        public Boss()
        {
            InitializeComponent();
        }
        public static string secret = "";
        public static string weapon = "";
        int status = 1;
        int shibi = 0;
        int statusBoss = 1;
        bool keyD = false;
        bool keyA = false;
        bool keyJ = false;
        bool keyK = false;
        bool keyL = false;
        int AxeC;
        int ShuC;
        int KunaC;
        int BomC;

        DispatcherTimer timer = new DispatcherTimer();
        DispatcherTimer timerBoss = new DispatcherTimer();
        DispatcherTimer timerKunai = new DispatcherTimer();

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            label2.Content = "$  " + MainWindow.MN;
            label.Content = MainWindow.NM;
            string sql = "SELECT * FROM `logingame1` WHERE username ='" + MainWindow.NM + "'";
            MySqlConnection con = new MySqlConnection("host=localhost;user=project;password=123456;database=gameshop");
            MySqlCommand cmd = new MySqlCommand(sql, con);
            con.Open();
            MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                AxeC = dr.GetInt16("axe");
                ShuC = dr.GetInt16("shuriken");
                KunaC = dr.GetInt16("kunai");
                BomC = dr.GetInt16("bomb");
            }
            con.Close();

            this.Focus();
            timer.Tick += new EventHandler(dispatPlayer);
            timer.Interval = new TimeSpan(0, 0, 0, 0, 50);
            timer.Start();

            timerBoss.Tick += new EventHandler(dispatBoss);
            timerBoss.Interval = new TimeSpan(0, 0, 0, 0, 150);
            timerBoss.Start();

            timerKunai.Tick += new EventHandler(dispatkunai);
            timerKunai.Interval = new TimeSpan(0, 0, 0, 0, 20);
            timerKunai.Start();
        }

        private void dispatkunai(object sender, EventArgs e)
        {

            if (KunaC == 1)
            {
                double d = Math.Sqrt(Math.Pow(Canvas.GetTop(kunai) - Canvas.GetTop(boss), 2) + Math.Pow(Canvas.GetLeft(kunai) - Canvas.GetLeft(boss), 2));

                if (shibi <= 100)
                {

                    if (Canvas.GetLeft(kunai) >= 0)
                        Canvas.SetLeft(kunai, Canvas.GetLeft(kunai) + 20);
                    else
                        Canvas.SetLeft(kunai, -122);
                    if (d <= 152)
                    {
                        BossHP.Value -= 25;
                        Canvas.SetLeft(kunai, Canvas.GetLeft(kunai) - 1000);
                        Canvas.SetLeft(boss, Canvas.GetLeft(boss) + 50);
                        if (BossHP.Value <= 0)
                        {
                            MainWindow.MN += 100; //add money
                            label1.Content = "$  " + MainWindow.MN;
                            Canvas.SetLeft(boss, Canvas.GetLeft(boss) + 1000);
                            Winner wn = new Winner();
                            wn.Show();
                            this.Hide();
                            timer.Stop();
                            timerKunai.Stop();
                            timerBoss.Stop();
                        }

                    }
                }
            }
            else if (BomC == 1)
            {
                double d = Math.Sqrt(Math.Pow(Canvas.GetTop(bomb) - Canvas.GetTop(boss), 2) + Math.Pow(Canvas.GetLeft(bomb) - Canvas.GetLeft(boss), 2));

                if (shibi <= 100)
                {

                    if (Canvas.GetLeft(bomb) >= 0)
                        Canvas.SetLeft(bomb, Canvas.GetLeft(bomb) + 20);
                    else
                        Canvas.SetLeft(bomb, -122);
                    if (d <= 152)
                    {
                        BossHP.Value -= 40;
                        Canvas.SetLeft(bomb, Canvas.GetLeft(bomb) - 1000);
                        Canvas.SetLeft(boss, Canvas.GetLeft(boss) + 50);
                        if (BossHP.Value <= 0)
                        {
                            MainWindow.MN += 100; //add money
                            label1.Content = "$  " + MainWindow.MN;
                            Canvas.SetLeft(boss, Canvas.GetLeft(boss) + 1000);
                            Winner wn = new Winner();
                            wn.Show();
                            this.Hide();
                            timer.Stop();
                            timerKunai.Stop();
                            timerBoss.Stop();
                        }

                    }
                }
            }
            else if (ShuC == 1)
            {
                double d = Math.Sqrt(Math.Pow(Canvas.GetTop(shuriken) - Canvas.GetTop(boss), 2) + Math.Pow(Canvas.GetLeft(shuriken) - Canvas.GetLeft(boss), 2));

                if (shibi <= 100)
                {

                    if (Canvas.GetLeft(shuriken) >= 0)
                        Canvas.SetLeft(shuriken, Canvas.GetLeft(shuriken) + 20);
                    else
                        Canvas.SetLeft(shuriken, -122);
                    if (d <= 152)
                    {
                        BossHP.Value -= 15;
                        Canvas.SetLeft(shuriken, Canvas.GetLeft(shuriken) - 1000);
                        Canvas.SetLeft(boss, Canvas.GetLeft(boss) + 50);
                        if (BossHP.Value <= 0)
                        {
                            MainWindow.MN += 100; //add money
                            label1.Content = "$  " + MainWindow.MN;
                            Canvas.SetLeft(boss, Canvas.GetLeft(boss) + 1000);
                            Winner wn = new Winner();
                            wn.Show();
                            this.Hide();
                            timer.Stop();
                            timerKunai.Stop();
                            timerBoss.Stop();
                        }

                    }
                }
            }
        }

        private void dispatBoss(object sender, EventArgs e)
        {
            double d = Math.Sqrt(Math.Pow(Canvas.GetTop(boss) - Canvas.GetTop(player), 2) + Math.Pow(Canvas.GetLeft(boss) - Canvas.GetLeft(player), 2));

            if (d >= 200)
            {
                if (statusBoss == 1)
                {
                    boss.Source = new BitmapImage(new Uri(@"\res\idle 2 (2).png", UriKind.Relative));
                    statusBoss = 2;
                }
                else if (statusBoss == 2)
                {
                    boss.Source = new BitmapImage(new Uri(@"\res\idle 2 (3).png", UriKind.Relative));
                    statusBoss = 3;
                }
                else if (statusBoss == 3)
                {
                    boss.Source = new BitmapImage(new Uri(@"\res\idle 2 (4).png", UriKind.Relative));
                    statusBoss = 4;
                }
                else if (statusBoss == 4)
                {
                    boss.Source = new BitmapImage(new Uri(@"\res\idle 2 (5).png", UriKind.Relative));
                    statusBoss = 5;
                }
                else if (statusBoss == 5)
                {
                    boss.Source = new BitmapImage(new Uri(@"\res\idle 2 (6).png", UriKind.Relative));
                    statusBoss = 6;
                }
                else if (statusBoss == 6)
                {
                    boss.Source = new BitmapImage(new Uri(@"\res\idle 2 (7).png", UriKind.Relative));
                    statusBoss = 7;
                }
                else if (statusBoss == 7)
                {
                    boss.Source = new BitmapImage(new Uri(@"\res\idle 2 (8).png", UriKind.Relative));
                    statusBoss = 8;
                }
                else if (statusBoss == 8)
                {
                    boss.Source = new BitmapImage(new Uri(@"\res\idle 2 (9).png", UriKind.Relative));
                    statusBoss = 9;
                }
                else if (statusBoss == 9)
                {
                    boss.Source = new BitmapImage(new Uri(@"\res\idle 2 (10).png", UriKind.Relative));
                    statusBoss = 10;
                }
                else if (statusBoss == 10)
                {
                    boss.Source = new BitmapImage(new Uri(@"\res\idle 2 (1).png", UriKind.Relative));
                    statusBoss = 1;
                }
            }
            else if (d <= 199)
            {

                if (statusBoss == 1)
                {
                    boss.Source = new BitmapImage(new Uri(@"\res\Boss2.png", UriKind.Relative));
                    statusBoss = 2;

                }
                else if (statusBoss == 2)
                {
                    boss.Source = new BitmapImage(new Uri(@"\res\Boss3.png", UriKind.Relative));
                    statusBoss = 3;

                }
                else if (statusBoss == 3)
                {
                    boss.Source = new BitmapImage(new Uri(@"\res\Boss4.png", UriKind.Relative));
                    statusBoss = 4;

                }
                else if (statusBoss == 4)
                {
                    boss.Source = new BitmapImage(new Uri(@"\res\Boss5.png", UriKind.Relative));
                    statusBoss = 5;

                }
                else if (statusBoss == 5)
                {
                    boss.Source = new BitmapImage(new Uri(@"\res\Boss6.png", UriKind.Relative));
                    statusBoss = 6;
                }
                else if (statusBoss == 6)
                {
                    boss.Source = new BitmapImage(new Uri(@"\res\Boss7.png", UriKind.Relative));
                    statusBoss = 7;
                }
                else if (statusBoss == 7)
                {
                    boss.Source = new BitmapImage(new Uri(@"\res\Boss8.png", UriKind.Relative));
                    statusBoss = 8;
                }
                else if (statusBoss == 8)
                {
                    boss.Source = new BitmapImage(new Uri(@"\res\Boss9.png", UriKind.Relative));
                    statusBoss = 9;
                }
                else if (statusBoss == 9)
                {
                    boss.Source = new BitmapImage(new Uri(@"\res\Boss10.png", UriKind.Relative));
                    statusBoss = 10;
                }
                else if (statusBoss == 10)
                {
                    boss.Source = new BitmapImage(new Uri(@"\res\Boss1.png", UriKind.Relative));
                    statusBoss = 1;
                }

            }


            if (d < 100)
            {
                if (keyK == true)
                {
                    BossHP.Value -= 20;
                    Canvas.SetLeft(boss, Canvas.GetLeft(boss) + 50);
                    if (BossHP.Value <= 0)
                    {
                        MainWindow.MN += 100; //add money
                        label1.Content = "$  " + MainWindow.MN;
                        Canvas.SetLeft(boss, Canvas.GetLeft(boss) + 1000);
                        Winner wn = new Winner();
                        wn.Show();
                        this.Hide();
                        timer.Stop();
                        timerKunai.Stop();
                        timerBoss.Stop();
                    }
                 }
            }
            if (d < 100 && Canvas.GetLeft(player) >= 0)
            {

                playerHP.Value -= 20;
                Canvas.SetLeft(player, Canvas.GetLeft(player) - 50);
                if (playerHP.Value <= 0)
                {
                    final.result = "GAME OVER";
                    final fn = new final();
                    fn.Show();
                    this.Hide();
                    timer.Stop();
                    timerKunai.Stop();
                    timerBoss.Stop();
                }      


            }


            Random rn = new Random();
            {
                if (rn.Next(10) >= 8)
                {
                    Canvas.SetLeft(boss, Canvas.GetLeft(boss) + 20);
                }
                else if (Canvas.GetLeft(boss) >= Canvas.GetLeft(player))
                {
                    Canvas.SetLeft(boss, Canvas.GetLeft(boss) - 20);
                }
            }
        }

        private void dispatPlayer(object sender, EventArgs e)
        {
            string step = "";
            if (keyK == true)
            {
                if (AxeC == 1)
                {
                    step = "AXE";
                }
                else
                {
                    step = "Attack";
                }

            }
            else if (keyL == true)
            {
                step = "Thro";
                
            }

            else if (keyD == true)
            {
                step = "next";
            }
            else if (keyA == true)
            {
                step = "moveback";

            }
            else if (keyJ == true)
            {
                if (AxeC == 1)
                {
                    step = "AXEBACK";
                }
                else
                {
                    step = "Attackback";
                }

            }

            if (status == 1)// เมื่อผู้เล่นยืนอยู่นิ่งๆ
            {
                player.Source = new BitmapImage(new Uri(@"\res\" + step + "2.png", UriKind.Relative));
                status = 2;
            }
            else if (status == 2)
            {
                player.Source = new BitmapImage(new Uri(@"\res\" + step + "3.png", UriKind.Relative));
                status = 3;
            }
            else if (status == 3)
            {
                player.Source = new BitmapImage(new Uri(@"\res\" + step + "4.png", UriKind.Relative));
                status = 4;
                
            }
            else if (status == 4)
            {
                player.Source = new BitmapImage(new Uri(@"\res\" + step + "5.png", UriKind.Relative));
                status = 5;
            }
            else if (status == 5)
            {
                player.Source = new BitmapImage(new Uri(@"\res\" + step + "6.png", UriKind.Relative));
                status = 6;
            }
            else if (status == 6)
            {
                player.Source = new BitmapImage(new Uri(@"\res\" + step + "7.png", UriKind.Relative));
                status = 7;
            }
            else if (status == 7)
            {
                player.Source = new BitmapImage(new Uri(@"\res\" + step + "8.png", UriKind.Relative));
                status = 8;
            }
            else if (status == 8)
            {
                player.Source = new BitmapImage(new Uri(@"\res\" + step + "9.png", UriKind.Relative));
                status = 9;
            }
            else if (status == 9)
            {
                player.Source = new BitmapImage(new Uri(@"\res\" + step + "10.png", UriKind.Relative));
                status = 10;
            }
            else if (status == 10)
            {
                player.Source = new BitmapImage(new Uri(@"\res\" + step + "1.png", UriKind.Relative));
                status = 1;
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.D && Canvas.GetLeft(player) <= 950 && Canvas.GetLeft(boss) >= Canvas.GetLeft(player))
            {
                Canvas.SetLeft(player, Canvas.GetLeft(player) + 20);
                keyD = true;
            }
            else if (e.Key == Key.A && Canvas.GetLeft(player) >= 0)
            {
                Canvas.SetLeft(player, Canvas.GetLeft(player) - 20);
                keyA = true;
            }
            else if (e.Key == Key.K)
            {
                keyK = true;
            }
            else if (e.Key == Key.J)
            {
                keyJ = true;
            }
            else if (e.Key == Key.L)
            {
                if (KunaC == 1)
                {
                    Canvas.SetLeft(kunai, Canvas.GetLeft(player) + 100);
                    keyL = true;
                    shibi++;
                }
                else if(ShuC == 1)
                {
                    Canvas.SetLeft(shuriken, Canvas.GetLeft(player) + 100);
                    keyL = true;
                    shibi++;
                }
                else if (BomC == 1)
                {
                    Canvas.SetLeft(bomb, Canvas.GetLeft(player) + 100);
                    keyL = true;
                    shibi++;
                }

            }
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.D)
            {
                keyD = false;
            }
            else if (e.Key == Key.A)
            {
                keyA = false;
            }
            else if (e.Key == Key.K)
            {
                keyK = false;
            }
            else if (e.Key == Key.J)
            {
                keyJ = false;
            }
            else if (e.Key == Key.L)
            {
                keyL = false;

            }

        }
    }
}
