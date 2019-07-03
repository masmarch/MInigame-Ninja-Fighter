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
    /// Interaction logic for playWindow2.xaml
    /// </summary>
    public partial class playWindow2 : Window
    {
        public playWindow2()
        {
            InitializeComponent();
        }
        public static string secret = "";
        public static string weapon = "";
        int status = 1;
        int statusbot = 1;
        int statusbot1 = 1;
        int statusbot2 = 1;
        int statusbot3 = 1;
        int shibi = 0;
        bool keyK = false;
        bool keyD = false;
        bool keyA = false;
        bool keyJ = false;
        bool keyL = false;
        bool keyH = false;
        int AxeC;
        int ShuC;
        int KunaC;
        int BomC;


        DispatcherTimer timer = new DispatcherTimer();
        DispatcherTimer timerbot = new DispatcherTimer();
        DispatcherTimer timerbot1 = new DispatcherTimer();
        DispatcherTimer timerbot2 = new DispatcherTimer();
        DispatcherTimer timerbot3 = new DispatcherTimer();
        DispatcherTimer timerkunai = new DispatcherTimer();

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            label1.Content = "$  " + MainWindow.MN;
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
            timer.Tick += new EventHandler(dispatTick);
            timer.Interval = new TimeSpan(0, 0, 0, 0, 50);
            timer.Start();

            timerbot.Tick += new EventHandler(dispatBot);
            timerbot.Interval = new TimeSpan(0, 0, 0, 0, 150);
            timerbot.Start();

            timerbot1.Tick += new EventHandler(dispatBot1);
            timerbot1.Interval = new TimeSpan(0, 0, 0, 0, 150);
            timerbot1.Start();

            timerbot2.Tick += new EventHandler(dispatBot2);
            timerbot2.Interval = new TimeSpan(0, 0, 0, 0, 150);
            timerbot2.Start();

            timerbot3.Tick += new EventHandler(dispatBot3);
            timerbot3.Interval = new TimeSpan(0, 0, 0, 0, 150);
            timerbot3.Start();

            timerkunai.Tick += new EventHandler(dispatkunai);
            timerkunai.Interval = new TimeSpan(0, 0, 0, 0, 20);
            timerkunai.Start();
        }

        private void dispatkunai(object sender, EventArgs e)
        {
            if (KunaC == 1)
            {
                double a = Math.Sqrt(Math.Pow(Canvas.GetTop(bot) - Canvas.GetTop(kunai), 2) + Math.Pow(Canvas.GetLeft(bot) - Canvas.GetLeft(kunai), 2));
                if (shibi <= 100)//บอทสีฟ้าโดนดาวกระจาย
                {

                    if (Canvas.GetLeft(kunai) >= 0)
                        Canvas.SetLeft(kunai, Canvas.GetLeft(kunai) + 20);
                    else
                        Canvas.SetLeft(kunai, -121);
                    if (a <= 60)
                    {
                        botHP.Value -= 25;
                        Canvas.SetLeft(kunai, Canvas.GetLeft(kunai) - 1000);
                        Canvas.SetLeft(bot, Canvas.GetLeft(bot) + 50);
                        if (botHP.Value <= 0)
                        {
                            MainWindow.MN += 100; //add money
                            label1.Content = "$  " + MainWindow.MN;
                            Canvas.SetTop(bot, Canvas.GetTop(bot) - 200);
                            Canvas.SetLeft(bot, Canvas.GetLeft(bot) + 1000); 
                            timerbot.Stop();
                        }

                    }
                }
                double b = Math.Sqrt(Math.Pow(Canvas.GetTop(bot1) - Canvas.GetTop(kunai), 2) + Math.Pow(Canvas.GetLeft(bot1) - Canvas.GetLeft(kunai), 2));
                if (shibi <= 100)//บอทสีเขียวโดนดาวกระจาย
                {

                    if (Canvas.GetLeft(kunai) >= 0)
                        Canvas.SetLeft(kunai, Canvas.GetLeft(kunai) + 20);
                    else
                        Canvas.SetLeft(kunai, -121);
                    if (b <= 60)
                    {
                        bot1HP.Value -= 25;
                        Canvas.SetLeft(kunai, Canvas.GetLeft(kunai) - 1000);
                        Canvas.SetLeft(bot1, Canvas.GetLeft(bot1) + 50);
                        if (bot1HP.Value <= 0)
                        {
                            MainWindow.MN += 100; //add money
                            label1.Content = "$  " + MainWindow.MN;
                            Canvas.SetTop(bot1, Canvas.GetTop(bot1) - 200);
                            Canvas.SetLeft(bot1, Canvas.GetLeft(bot1) + 1000);
                            timerbot1.Stop();
                        }
                    }
                }
                double c = Math.Sqrt(Math.Pow(Canvas.GetTop(bot2) - Canvas.GetTop(kunai1), 2) + Math.Pow(Canvas.GetLeft(bot2) - Canvas.GetLeft(kunai1), 2));
                if (shibi <= 100)//บอทสีเหลืองโดนดาวกระจาย
                {

                    if (Canvas.GetLeft(kunai1) >= 0)
                        Canvas.SetLeft(kunai1, Canvas.GetLeft(kunai1) - 20);
                    else
                        Canvas.SetLeft(kunai1, -1000);
                    if (c <= 70)
                    {
                        bot2HP.Value -= 25;
                        Canvas.SetLeft(kunai1, Canvas.GetLeft(kunai1) - 1000);
                        Canvas.SetLeft(bot2, Canvas.GetLeft(bot2) - 50);
                        if (bot2HP.Value <= 0)
                        {
                            MainWindow.MN += 100; //add money
                            label1.Content = "$  " + MainWindow.MN;
                            Canvas.SetTop(bot2, Canvas.GetTop(bot2) - 200);
                            Canvas.SetLeft(bot2, Canvas.GetLeft(bot2) - 1000);
                            timerbot2.Stop();
                        }
                    }
                }
                double d = Math.Sqrt(Math.Pow(Canvas.GetTop(bot3) - Canvas.GetTop(kunai1), 2) + Math.Pow(Canvas.GetLeft(bot3) - Canvas.GetLeft(kunai1), 2));
                if (shibi <= 100)//บอทสีน้ำเงินโดนดาวกระจาย
                {

                    if (Canvas.GetLeft(kunai1) >= 0)
                        Canvas.SetLeft(kunai1, Canvas.GetLeft(kunai1) - 20);
                    else
                        Canvas.SetLeft(kunai1, -2000);
                    if (d <= 78)
                    {
                        bot3HP.Value -= 25;
                        Canvas.SetLeft(kunai1, Canvas.GetLeft(kunai1) - 1000);
                        Canvas.SetLeft(bot3, Canvas.GetLeft(bot3) - 50);
                        if (bot3HP.Value <= 0)
                        {
                            MainWindow.MN += 100; //add money
                            label1.Content = "$  " + MainWindow.MN;
                            Canvas.SetTop(bot3, Canvas.GetTop(bot3) - 200);
                            Canvas.SetLeft(bot3, Canvas.GetLeft(bot3) - 1000);
                            timerbot3.Stop();
                        }
                    }
                }
            }
            else if (ShuC == 1)
            {
                double a = Math.Sqrt(Math.Pow(Canvas.GetTop(bot) - Canvas.GetTop(shuriken), 2) + Math.Pow(Canvas.GetLeft(bot) - Canvas.GetLeft(shuriken), 2));
                if (shibi <= 100)//บอทสีฟ้าโดนดาวกระจาย
                {

                    if (Canvas.GetLeft(shuriken) >= 0)
                        Canvas.SetLeft(shuriken, Canvas.GetLeft(shuriken) + 20);
                    else
                        Canvas.SetLeft(shuriken, -121);
                    if (a <= 60)
                    {
                        botHP.Value -= 15;
                        Canvas.SetLeft(shuriken, Canvas.GetLeft(shuriken) - 1000);
                        Canvas.SetLeft(bot, Canvas.GetLeft(bot) + 50);
                        if (botHP.Value <= 0)
                        {
                            MainWindow.MN += 100; //add money
                            label1.Content = "$  " + MainWindow.MN;
                            Canvas.SetTop(bot, Canvas.GetTop(bot) - 200);
                            Canvas.SetLeft(bot, Canvas.GetLeft(bot) + 1000);
                            timerbot.Stop();
                        }

                    }
                }
                double b = Math.Sqrt(Math.Pow(Canvas.GetTop(bot1) - Canvas.GetTop(shuriken), 2) + Math.Pow(Canvas.GetLeft(bot1) - Canvas.GetLeft(shuriken), 2));
                if (shibi <= 100)//บอทสีเขียวโดนดาวกระจาย
                {

                    if (Canvas.GetLeft(shuriken) >= 0)
                        Canvas.SetLeft(shuriken, Canvas.GetLeft(shuriken) + 20);
                    else
                        Canvas.SetLeft(shuriken, -121);
                    if (b <= 60)
                    {
                        bot1HP.Value -= 15;
                        Canvas.SetLeft(shuriken, Canvas.GetLeft(shuriken) - 1000);
                        Canvas.SetLeft(bot1, Canvas.GetLeft(bot1) + 50);
                        if (bot1HP.Value <= 0)
                        {
                            MainWindow.MN += 100; //add money
                            label1.Content = "$  " + MainWindow.MN;
                            Canvas.SetTop(bot1, Canvas.GetTop(bot1) - 200);
                            Canvas.SetLeft(bot1, Canvas.GetLeft(bot1) + 1000);
                            timerbot1.Stop();
                        }
                    }
                }
                double c = Math.Sqrt(Math.Pow(Canvas.GetTop(bot2) - Canvas.GetTop(shuriken1), 2) + Math.Pow(Canvas.GetLeft(bot2) - Canvas.GetLeft(shuriken1), 2));
                if (shibi <= 100)//บอทสีเหลืองโดนดาวกระจาย
                {

                    if (Canvas.GetLeft(shuriken1) >= 0)
                        Canvas.SetLeft(shuriken1, Canvas.GetLeft(shuriken1) - 20);
                    else
                        Canvas.SetLeft(shuriken1, -1000);
                    if (c <= 70)
                    {
                        bot2HP.Value -= 15;
                        Canvas.SetLeft(shuriken1, Canvas.GetLeft(shuriken1) - 1000);
                        Canvas.SetLeft(bot2, Canvas.GetLeft(bot2) - 50);
                        if (bot2HP.Value <= 0)
                        {
                            MainWindow.MN += 100; //add money
                            label1.Content = "$  " + MainWindow.MN;
                            Canvas.SetTop(bot2, Canvas.GetTop(bot2) - 200);
                            Canvas.SetLeft(bot2, Canvas.GetLeft(bot2) - 1000);
                            timerbot2.Stop();
                        }
                    }
                }
                double d = Math.Sqrt(Math.Pow(Canvas.GetTop(bot3) - Canvas.GetTop(shuriken1), 2) + Math.Pow(Canvas.GetLeft(bot3) - Canvas.GetLeft(shuriken1), 2));
                if (shibi <= 100)//บอทสีน้ำเงินโดนดาวกระจาย
                {

                    if (Canvas.GetLeft(shuriken1) >= 0)
                        Canvas.SetLeft(shuriken1, Canvas.GetLeft(shuriken1) - 20);
                    else
                        Canvas.SetLeft(shuriken1, -2000);
                    if (d <= 78)
                    {
                        bot3HP.Value -= 15;
                        Canvas.SetLeft(shuriken1, Canvas.GetLeft(shuriken1) - 1000);
                        Canvas.SetLeft(bot3, Canvas.GetLeft(bot3) - 50);
                        if (bot3HP.Value <= 0)
                        {
                            MainWindow.MN += 100; //add money
                            label1.Content = "$  " + MainWindow.MN;
                            Canvas.SetTop(bot3, Canvas.GetTop(bot3) - 200);
                            Canvas.SetLeft(bot3, Canvas.GetLeft(bot3) - 1000);
                            timerbot3.Stop();
                        }
                    }
                }
            }
            else if (BomC == 1)
            {
                double a = Math.Sqrt(Math.Pow(Canvas.GetTop(bot) - Canvas.GetTop(bomb), 2) + Math.Pow(Canvas.GetLeft(bot) - Canvas.GetLeft(bomb), 2));
                if (shibi <= 100)//บอทสีฟ้าโดนดาวกระจาย
                {

                    if (Canvas.GetLeft(bomb) >= 0)
                        Canvas.SetLeft(bomb, Canvas.GetLeft(bomb) + 20);
                    else
                        Canvas.SetLeft(bomb, -121);
                    if (a <= 60)
                    {
                        botHP.Value -= 40;
                        Canvas.SetLeft(bomb, Canvas.GetLeft(bomb) - 1000);
                        Canvas.SetLeft(bot, Canvas.GetLeft(bot) + 50);
                        if (botHP.Value <= 0)
                        {
                            MainWindow.MN += 100; //add money
                            label1.Content = "$  " + MainWindow.MN;
                            Canvas.SetTop(bot, Canvas.GetTop(bot) - 200);
                            Canvas.SetLeft(bot, Canvas.GetLeft(bot) + 1000);
                            timerbot.Stop();
                        }

                    }
                }
                double b = Math.Sqrt(Math.Pow(Canvas.GetTop(bot1) - Canvas.GetTop(bomb), 2) + Math.Pow(Canvas.GetLeft(bot1) - Canvas.GetLeft(bomb), 2));
                if (shibi <= 100)//บอทสีเขียวโดนดาวกระจาย
                {

                    if (Canvas.GetLeft(bomb) >= 0)
                        Canvas.SetLeft(bomb, Canvas.GetLeft(bomb) + 20);
                    else
                        Canvas.SetLeft(bomb, -121);
                    if (b <= 60)
                    {
                        bot1HP.Value -= 40;
                        Canvas.SetLeft(bomb, Canvas.GetLeft(bomb) - 1000);
                        Canvas.SetLeft(bot1, Canvas.GetLeft(bot1) + 50);
                        if (bot1HP.Value <= 0)
                        {
                            MainWindow.MN += 100; //add money
                            label1.Content = "$  " + MainWindow.MN;
                            Canvas.SetTop(bot1, Canvas.GetTop(bot1) - 200);
                            Canvas.SetLeft(bot1, Canvas.GetLeft(bot1) + 1000);
                            timerbot1.Stop();
                        }
                    }
                }
                double c = Math.Sqrt(Math.Pow(Canvas.GetTop(bot2) - Canvas.GetTop(bomb1), 2) + Math.Pow(Canvas.GetLeft(bot2) - Canvas.GetLeft(bomb1), 2));
                if (shibi <= 100)//บอทสีเหลืองโดนดาวกระจาย
                {

                    if (Canvas.GetLeft(bomb1) >= 0)
                        Canvas.SetLeft(bomb1, Canvas.GetLeft(bomb1) - 20);
                    else
                        Canvas.SetLeft(bomb1, -1000);
                    if (c <= 70)
                    {
                        bot2HP.Value -= 40;
                        Canvas.SetLeft(bomb1, Canvas.GetLeft(bomb1) - 1000);
                        Canvas.SetLeft(bot2, Canvas.GetLeft(bot2) - 50);
                        if (bot2HP.Value <= 0)
                        {
                            MainWindow.MN += 100; //add money
                            label1.Content = "$  " + MainWindow.MN;
                            Canvas.SetTop(bot2, Canvas.GetTop(bot2) - 200);
                            Canvas.SetLeft(bot2, Canvas.GetLeft(bot2) - 1000);
                            timerbot2.Stop();
                        }
                    }
                }
                double d = Math.Sqrt(Math.Pow(Canvas.GetTop(bot3) - Canvas.GetTop(bomb1), 2) + Math.Pow(Canvas.GetLeft(bot3) - Canvas.GetLeft(bomb1), 2));
                if (shibi <= 100)//บอทสีน้ำเงินโดนดาวกระจาย
                {

                    if (Canvas.GetLeft(bomb1) >= 0)
                        Canvas.SetLeft(bomb1, Canvas.GetLeft(bomb1) - 20);
                    else
                        Canvas.SetLeft(bomb1, -2000);
                    if (d <= 78)
                    {
                        bot3HP.Value -= 40;
                        Canvas.SetLeft(bomb1, Canvas.GetLeft(bomb1) - 1000);
                        Canvas.SetLeft(bot3, Canvas.GetLeft(bot3) - 50);
                        if (bot3HP.Value <= 0)
                        {
                            MainWindow.MN += 100; //add money
                            label1.Content = "$  " + MainWindow.MN;
                            Canvas.SetTop(bot3, Canvas.GetTop(bot3) - 200);
                            Canvas.SetLeft(bot3, Canvas.GetLeft(bot3) - 1000);
                            timerbot3.Stop();
                        }
                    }
                }
            }
        }

        private void dispatBot3(object sender, EventArgs e)
        {
            double d = Math.Sqrt(Math.Pow(Canvas.GetTop(bot3) - Canvas.GetTop(player), 2) + Math.Pow(Canvas.GetLeft(bot3) - Canvas.GetLeft(player), 2));
            if (statusbot3 == 1)
            {
                bot3.Source = new BitmapImage(new Uri(@"\res\monb2.png", UriKind.Relative));
                statusbot3 = 2;

            }
            else if (statusbot3 == 2)
            {
                bot3.Source = new BitmapImage(new Uri(@"\res\monb1.png", UriKind.Relative));
                statusbot3 = 1;
            }
            if (d < 100)
            {
                if (keyJ == true)
                {
                    bot3HP.Value -= 20;
                    Canvas.SetLeft(bot3, Canvas.GetLeft(bot3) - 50);
                    if (bot3HP.Value <= 0)
                    {
                        MainWindow.MN += 100; //add money
                        label1.Content = "$  " + MainWindow.MN;
                        Canvas.SetLeft(bot3, Canvas.GetLeft(bot3HP) - 2000);
                        timerbot3.Stop();
                    }
                }

            }
            if (d < 70)
            {
                playerHP.Value -= 10;
                Canvas.SetLeft(player, Canvas.GetLeft(player) + 50);
                if (playerHP.Value == 0)
                {
                    string sql = "UPDATE `logingame1` SET `price`='" + MainWindow.MN + "'   WHERE username ='" + MainWindow.NM + "'";

                    MySqlConnection con = new MySqlConnection("host=localhost;user=project;password=123456;database=gameshop");
                    MySqlCommand cmd = new MySqlCommand(sql, con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    final.result = "GAME OVER";
                    final fn = new final();
                    fn.Show();
                    this.Hide();
                    timer.Stop();
                    timerbot.Stop();
                    timerbot1.Stop();
                    timerbot2.Stop();
                    timerbot3.Stop();
                    timerkunai.Stop();
                }
            }

            Random rd = new Random();
            {
                if (rd.Next(10) >= 8)
                {
                    Canvas.SetLeft(bot3, Canvas.GetLeft(bot3) - 20);
                }
                else if (Canvas.GetLeft(bot3) <= Canvas.GetLeft(player))
                {
                    Canvas.SetLeft(bot3, Canvas.GetLeft(bot3) + 20);
                }
            }
        }

        private void dispatBot2(object sender, EventArgs e)
        {
            double d = Math.Sqrt(Math.Pow(Canvas.GetTop(bot2) - Canvas.GetTop(player), 2) + Math.Pow(Canvas.GetLeft(bot2) - Canvas.GetLeft(player), 2));

            if (statusbot2 == 1)
            {
                bot2.Source = new BitmapImage(new Uri(@"\res\mon2.png", UriKind.Relative));
                statusbot2 = 2;

            }
            else if (statusbot2 == 2)
            {
                bot2.Source = new BitmapImage(new Uri(@"\res\mon1.png", UriKind.Relative));
                statusbot2 = 1;
            }
            if (d < 100)
            {
                if (keyJ == true)
                {
                    bot2HP.Value -= 20;
                    Canvas.SetLeft(bot2, Canvas.GetLeft(bot2) - 50);
                    if (bot2HP.Value <= 0)
                    {
                        MainWindow.MN += 100; //add money
                        label1.Content = "$  " + MainWindow.MN;
                        Canvas.SetLeft(bot2, Canvas.GetLeft(bot2HP) - 2000);
                        timerbot2.Stop();
                    }
                }

            }
            if (d < 70)
            {
                playerHP.Value -= 10;
                Canvas.SetLeft(player, Canvas.GetLeft(player) + 50);
                if (playerHP.Value == 0)
                {
                    string sql = "UPDATE `logingame1` SET `price`='"+MainWindow.MN+"'   WHERE username ='" + MainWindow.NM + "'";

                    MySqlConnection con = new MySqlConnection("host=localhost;user=project;password=123456;database=gameshop");
                    MySqlCommand cmd = new MySqlCommand(sql, con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    final.result = "GAME OVER";
                    final fn = new final();
                    fn.Show();
                    this.Hide();
                    timer.Stop();
                    timerbot.Stop();
                    timerbot1.Stop();
                    timerbot2.Stop();
                    timerbot3.Stop();
                    timerkunai.Stop();
                }
            }

                Random rd = new Random();
                {
                    if (rd.Next(10) >= 8)
                    {
                        Canvas.SetLeft(bot2, Canvas.GetLeft(bot2) - 20);
                    }
                    else if (Canvas.GetLeft(bot2) <= Canvas.GetLeft(player))
                    {
                        Canvas.SetLeft(bot2, Canvas.GetLeft(bot2) + 20);
                    }
                }
         }

        private void dispatBot1(object sender, EventArgs e)
        {
            double d = Math.Sqrt(Math.Pow(Canvas.GetTop(bot1) - Canvas.GetTop(player), 2) + Math.Pow(Canvas.GetLeft(bot1) - Canvas.GetLeft(player), 2));
            if (statusbot1 == 1)
            {
                bot1.Source = new BitmapImage(new Uri(@"\res\run2.png", UriKind.Relative));
                statusbot1 = 2;


            }
            else if (statusbot1 == 2)
            {
                bot1.Source = new BitmapImage(new Uri(@"\res\run1.png", UriKind.Relative));
                statusbot1 = 1;

            }
            if (d < 120)
            {
                if (keyK == true)
                {
                    bot1HP.Value -= 20;
                    Canvas.SetLeft(bot1, Canvas.GetLeft(bot1) + 50);
                    if (bot1HP.Value <= 0)
                    {
                        MainWindow.MN += 100; //add money
                        label1.Content = "$  " + MainWindow.MN;
                        Canvas.SetLeft(bot1, Canvas.GetLeft(bot1) + 1000);
                        timerbot1.Stop();

                    }
                }


            }
            if (d <= 90 && Canvas.GetLeft(player) >= 0)
            {
                playerHP.Value = playerHP.Value - 10;
                Canvas.SetLeft(player, Canvas.GetLeft(player) - 50);
                if (playerHP.Value <= 0)
                {
                    string sql = "UPDATE `logingame1` SET `price`='" + MainWindow.MN + "'   WHERE username ='" + MainWindow.NM + "'";

                    MySqlConnection con = new MySqlConnection("host=localhost;user=project;password=123456;database=gameshop");
                    MySqlCommand cmd = new MySqlCommand(sql, con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    final.result = "GAME OVER";
                    final fn = new final();
                    fn.Show();
                    this.Hide();
                    timer.Stop();
                    timerbot.Stop();
                    timerbot1.Stop();
                    timerbot2.Stop();
                    timerbot3.Stop();
                    timerkunai.Stop();

                }
            }

            Random rd = new Random();
            {
                if (rd.Next(10) >= 8)
                {
                    Canvas.SetLeft(bot1, Canvas.GetLeft(bot1) + 20);
                }
                else if (Canvas.GetLeft(bot1) >= Canvas.GetLeft(player))
                {
                    Canvas.SetLeft(bot1, Canvas.GetLeft(bot1) - 20);
                }
            }
        }

        private void dispatBot(object sender, EventArgs e)
        {
            double d = Math.Sqrt(Math.Pow(Canvas.GetTop(bot) - Canvas.GetTop(player), 2) + Math.Pow(Canvas.GetLeft(bot) - Canvas.GetLeft(player), 2));
            if (statusbot == 1)
            {
                bot.Source = new BitmapImage(new Uri(@"\res\walk2.png", UriKind.Relative));
                statusbot = 2;
            }
            else if (statusbot == 2)
            {
                bot.Source = new BitmapImage(new Uri(@"\res\walk1.png", UriKind.Relative));
                statusbot = 1;

            }
            if (d < 120)
            {
                if (keyK == true)
                {
                    botHP.Value -= 20;
                    Canvas.SetLeft(bot, Canvas.GetLeft(bot) + 50);
                    if (botHP.Value <= 0)
                    {
                        MainWindow.MN += 100; //add money
                        label1.Content = "$  " + MainWindow.MN;
                        Canvas.SetLeft(bot, Canvas.GetLeft(bot) + 1000);
                        timerbot.Stop();

                    }
                }
            }
            if (d <= 90 && Canvas.GetLeft(player) >= 0)
            {
                playerHP.Value = playerHP.Value - 10;
                Canvas.SetLeft(player, Canvas.GetLeft(player) - 50);
                if (playerHP.Value <= 0)
                {
                    string sql = "UPDATE `logingame1` SET `price`='" + MainWindow.MN + "'   WHERE username ='" + MainWindow.NM + "'";

                    MySqlConnection con = new MySqlConnection("host=localhost;user=project;password=123456;database=gameshop");
                    MySqlCommand cmd = new MySqlCommand(sql, con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    final.result = "GAME OVER";
                    final fn = new final();
                    fn.Show();
                    this.Hide();
                    timer.Stop();
                    timerbot.Stop();
                    timerbot1.Stop();
                    timerbot2.Stop();
                    timerbot3.Stop();
                    timerkunai.Stop();

                }
              }


            Random rd = new Random();
            {
                if (rd.Next(10) >= 8)
                {
                    Canvas.SetLeft(bot, Canvas.GetLeft(bot) + 20);
                }
                else if (Canvas.GetLeft(bot) >= Canvas.GetLeft(player))
                {
                    Canvas.SetLeft(bot, Canvas.GetLeft(bot) - 20);
                }
            }
        }

        private void dispatTick(object sender, EventArgs e)
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
            else if (keyH == true)
            {
                step = "Throw";
            
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
            if (e.Key == Key.D && Canvas.GetLeft(player) <= 950 && Canvas.GetLeft(bot) >= Canvas.GetLeft(player) && Canvas.GetLeft(bot1) >= Canvas.GetLeft(player))
            {
                Canvas.SetLeft(player, Canvas.GetLeft(player) + 20);
                keyD = true;
                if (Canvas.GetLeft(player) >= 950 && botHP.Value <= 0 && bot1HP.Value <= 0 && bot2HP.Value <= 0 && bot3HP.Value <= 0)
                {
                    Boss bs = new Boss();
                    bs.Show();
                    this.Hide();

                }
            }
            else if (e.Key == Key.A && Canvas.GetLeft(player) > 0 && Canvas.GetLeft(bot2) <= Canvas.GetLeft(player) && Canvas.GetLeft(bot3) <= Canvas.GetLeft(player))
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
                if (ShuC == 1)
                {
                    Canvas.SetLeft(shuriken, Canvas.GetLeft(player) + 100);
                    keyL = true;
                    shibi++;
                }
                if (BomC == 1)
                {
                    Canvas.SetLeft(bomb, Canvas.GetLeft(player) + 100);
                    keyL = true;
                    shibi++;
                }
            }
            else if (e.Key == Key.H)
            {
                if ((KunaC == 1))
                {
                    Canvas.SetLeft(kunai1, Canvas.GetLeft(player) + 100);
                    keyH = true;
                    shibi++;
                }
                if (ShuC == 1)
                {
                    Canvas.SetLeft(shuriken1, Canvas.GetLeft(player) + 100);
                    keyH = true;
                    shibi++;
                }
                if (BomC == 1)
                {
                    Canvas.SetLeft(bomb1, Canvas.GetLeft(player) + 100);
                    keyH = true;
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
            else if (e.Key == Key.H)
            {
                keyH = false;
            }
        }
    }
}
