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
    /// Interaction logic for playWindow1.xaml
    /// </summary>
    public partial class playWindow1 : Window
    {
        public playWindow1()
        {
            InitializeComponent();
        }
        
        int status = 1;
        int statusbot = 1;
        int statusbot1 = 1;
        int shibi = 0;
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
        DispatcherTimer timerbot = new DispatcherTimer();
        DispatcherTimer timerbot1 = new DispatcherTimer();
        DispatcherTimer timerkunai = new DispatcherTimer();        
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            label1.Content = "$  " + MainWindow.MN;
            label.Content = MainWindow.NM;
            string sql = "SELECT * FROM `logingame1` WHERE username ='"+MainWindow.NM+"'";
            MySqlConnection con = new MySqlConnection("host=localhost;user=project;password=123456;database=gameshop");
            MySqlCommand cmd = new MySqlCommand(sql, con);
            con.Open();
            MySqlDataReader dr = cmd.ExecuteReader();
            if(dr.Read())
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

            timerbot.Tick += new EventHandler(dispatTickbot);
            timerbot.Interval = new TimeSpan(0, 0, 0, 0, 150);
            timerbot.Start();

            timerbot1.Tick += new EventHandler(dispatTickbot1);
            timerbot1.Interval = new TimeSpan(0, 0, 0, 0, 150);
            timerbot1.Start();

            timerkunai.Tick += new EventHandler(dispatkunai);
            timerkunai.Interval = new TimeSpan(0, 0, 0, 0, 20);
            timerkunai.Start();
        }

        private void dispatkunai(object sender, EventArgs e)
        {
            
            if (BomC == 1)
            {
                double d = Math.Sqrt(Math.Pow(Canvas.GetTop(bomb) - Canvas.GetTop(bot), 2) + Math.Pow(Canvas.GetLeft(bomb) - Canvas.GetLeft(bot), 2));
                if (shibi <= 100)
                {
                    if (Canvas.GetLeft(bomb) >= 0)
                        Canvas.SetLeft(bomb, Canvas.GetLeft(bomb) + 20);
                    else
                        Canvas.SetLeft(bomb, -121);
                    if (d <= 60)
                    {
                        if (d <= 60)
                        {                            
                            botHp.Value -= 40;
                            Canvas.SetLeft(bomb, Canvas.GetLeft(bomb) - 1000);
                            Canvas.SetLeft(bot, Canvas.GetLeft(bot) + 50);
                            if (botHp.Value <= 0)
                            {                                
                                MainWindow.MN += 100; //add money
                                label1.Content = "$  " + MainWindow.MN;
                                Canvas.SetTop(bot, Canvas.GetTop(bot) - 200);
                                Canvas.SetLeft(bot, Canvas.GetLeft(bot) + 1000);
                                timerbot.Stop();

                            }
                        }
                    }
                    double c = Math.Sqrt(Math.Pow(Canvas.GetTop(bomb) - Canvas.GetTop(bot1), 2) + Math.Pow(Canvas.GetLeft(bomb) - Canvas.GetLeft(bot1), 2));
                    if (shibi <= 100)
                    {
                        if (Canvas.GetLeft(bomb) >= 0)
                            Canvas.SetLeft(bomb, Canvas.GetLeft(bomb) + 20);
                        else
                            Canvas.SetLeft(bomb, -121);
                        if (c <= 60)
                        {
                            bot1Hp.Value -= 40;
                            Canvas.SetLeft(bomb, Canvas.GetLeft(bomb) - 1000);
                            Canvas.SetLeft(bot1, Canvas.GetLeft(bot1) + 50);
                            if (bot1Hp.Value <= 0)
                            {                                
                                MainWindow.MN += 100; //add money
                                label1.Content = "$  " + MainWindow.MN;
                                Canvas.SetTop(bot1, Canvas.GetTop(bot1) - 200);
                                Canvas.SetLeft(bot1, Canvas.GetLeft(bot1) + 1000);
                                timerbot1.Stop();
                               
                            }
                         }
                     }

                 }
            }
            else if (ShuC == 1)
            {
                double d = Math.Sqrt(Math.Pow(Canvas.GetTop(shuriken) - Canvas.GetTop(bot), 2) + Math.Pow(Canvas.GetLeft(shuriken) - Canvas.GetLeft(bot), 2));
                if (shibi <= 100)
                {
                    if (Canvas.GetLeft(shuriken) >= 0)
                        Canvas.SetLeft(shuriken, Canvas.GetLeft(shuriken) + 20);
                    else
                        Canvas.SetLeft(shuriken, -121);
                    if (d <= 60)
                    {
                        botHp.Value -= 15;
                        Canvas.SetLeft(shuriken, Canvas.GetLeft(shuriken) + 1000);
                        Canvas.SetLeft(bot, Canvas.GetLeft(bot) + 50);
                        if (botHp.Value <= 0)
                        {                            
                            MainWindow.MN += 100; //add money
                            label1.Content = "$  " + MainWindow.MN;
                            Canvas.SetTop(bot, Canvas.GetTop(bot) - 200);
                            Canvas.SetLeft(bot, Canvas.GetLeft(bot) + 1000);
                            timerbot.Stop();
                            //ori
                            //ori
                            //ori
                        }
                    }
                }
                double c = Math.Sqrt(Math.Pow(Canvas.GetTop(shuriken) - Canvas.GetTop(bot1), 2) + Math.Pow(Canvas.GetLeft(shuriken) - Canvas.GetLeft(bot1), 2));
                if (shibi <= 100)
                {
                    if (Canvas.GetLeft(shuriken) >= 0)
                        Canvas.SetLeft(shuriken, Canvas.GetLeft(shuriken) + 20);
                    else
                        Canvas.SetLeft(kunai, -121);
                    if (c <= 60)
                    {
                        bot1Hp.Value -= 15;
                        Canvas.SetLeft(shuriken, Canvas.GetLeft(shuriken) - 1000);
                        Canvas.SetLeft(bot1, Canvas.GetLeft(bot1) + 50);
                        if (bot1Hp.Value <= 0)
                        {                            
                            MainWindow.MN += 100; //add money
                            label1.Content = "$  " + MainWindow.MN;
                            Canvas.SetTop(bot1, Canvas.GetTop(bot1) - 200);
                            Canvas.SetLeft(bot1, Canvas.GetLeft(bot1) + 1000);
                            timerbot1.Stop();
                        }
                    }
                }

            }
            else if (KunaC == 1)
            {
                double d = Math.Sqrt(Math.Pow(Canvas.GetTop(kunai) - Canvas.GetTop(bot), 2) + Math.Pow(Canvas.GetLeft(kunai) - Canvas.GetLeft(bot), 2));
                if (shibi <= 100)
                {
                    if (Canvas.GetLeft(kunai) >= 0)
                        Canvas.SetLeft(kunai, Canvas.GetLeft(kunai) + 20);
                    else
                        Canvas.SetLeft(kunai, -121);
                    if (d <= 60)
                    {
                        botHp.Value -= 25;
                        Canvas.SetLeft(kunai, Canvas.GetLeft(kunai) - 1000);
                        Canvas.SetLeft(bot, Canvas.GetLeft(bot) + 50);
                        if (botHp.Value <= 0)
                        {
                            
                            MainWindow.MN += 100; //add money
                            label1.Content = "$  " + MainWindow.MN;
                            Canvas.SetTop(bot, Canvas.GetTop(bot) - 200);
                            Canvas.SetLeft(bot, Canvas.GetLeft(bot) + 1000);
                            timerbot.Stop();
                        }
                    }
                }
                double c = Math.Sqrt(Math.Pow(Canvas.GetTop(kunai) - Canvas.GetTop(bot1), 2) + Math.Pow(Canvas.GetLeft(kunai) - Canvas.GetLeft(bot1), 2));
                if (shibi <= 100)
                {
                    if (Canvas.GetLeft(kunai) >= 0)
                        Canvas.SetLeft(kunai, Canvas.GetLeft(kunai) + 20);
                    else
                        Canvas.SetLeft(kunai, -121);
                    if (c <= 60)
                    {
                        bot1Hp.Value -= 25;
                        Canvas.SetLeft(kunai, Canvas.GetLeft(kunai) - 1000);
                        Canvas.SetLeft(bot1, Canvas.GetLeft(bot1) + 50);
                        if (bot1Hp.Value <= 0)
                        {
                            label1.Content = "$  " + MainWindow.MN;
                            MainWindow.MN += 100; // add money
                            Canvas.SetTop(bot1, Canvas.GetTop(bot1) - 200);
                            Canvas.SetLeft(bot1, Canvas.GetLeft(bot1) + 1000);
                            timerbot1.Stop();
                        }
                    }
                }
            }
            
        }

        private void dispatTickbot1(object sender, EventArgs e)
        {
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

            //ฟังชันตีมอนเตอร์
            double d = Math.Sqrt(Math.Pow(Canvas.GetTop(bot1) - Canvas.GetTop(player), 2) + Math.Pow(Canvas.GetLeft(bot1) - Canvas.GetLeft(player), 2));

            if (d < 120)
            {
                if (keyK == true)
                {
                    bot1Hp.Value = bot1Hp.Value - 20;
                    Canvas.SetLeft(bot1, Canvas.GetLeft(bot1) + 50);

                }

                if (bot1Hp.Value <= 0)
                {

                    label1.Content = "$  " + MainWindow.MN;
                    MainWindow.MN += 100;
                    Canvas.SetTop(bot1, Canvas.GetTop(bot1) - 200);
                    Canvas.SetLeft(bot1, Canvas.GetLeft(bot1) + 1000);
                    timerbot1.Stop();
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
                }

            }


            //การทำงานของบอท
            Random rnd = new Random();
            if (rnd.Next(10) >= 8 && Canvas.GetLeft(bot1) <= 950)
            {
                Canvas.SetLeft(bot1, Canvas.GetLeft(bot1) + 20);
            }
            else if (Canvas.GetLeft(bot1) >= Canvas.GetLeft(player) && Canvas.GetLeft(bot1) > 0)
            {
                Canvas.SetLeft(bot1, Canvas.GetLeft(bot1) - 20);
            }
        }

        private void dispatTickbot(object sender, EventArgs e)
        {
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

            //ฟังชันตีมอนเตอร์
            double d = Math.Sqrt(Math.Pow(Canvas.GetTop(bot) - Canvas.GetTop(player), 2) + Math.Pow(Canvas.GetLeft(bot) - Canvas.GetLeft(player), 2));

            if (d < 120)
            { //+money
                if (keyK == true)
                {
                    botHp.Value = botHp.Value - 20;
                    Canvas.SetLeft(bot, Canvas.GetLeft(bot) + 50);
                    if (botHp.Value <= 0)
                    {                        
                        MainWindow.MN += 100;
                        Canvas.SetTop(bot, Canvas.GetTop(bot) - 200);
                        Canvas.SetLeft(bot, Canvas.GetLeft(bot) + 1000);
                        timerbot.Stop();
                        label1.Content = "$  " + MainWindow.MN;

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

                }
            }

            //การทำงานของบอท
            Random rnd = new Random();
            if (rnd.Next(10) >= 8 && Canvas.GetLeft(bot) < 950)
            {
                Canvas.SetLeft(bot, Canvas.GetLeft(bot) + 20);
            }
            else if (Canvas.GetLeft(bot) >= Canvas.GetLeft(player) && Canvas.GetLeft(bot) > 0)
            {
                Canvas.SetLeft(bot, Canvas.GetLeft(bot) - 20);
            }
        }

        private void dispatTick(object sender, EventArgs e)
        {

                string step = ""; // ฟังก์ชันลักษณะท่าทางต่าง ในการกดปุ่ม
                if (keyK == true)
                {
                    if (AxeC==1)
                    {
                        step = "AXE";
                    }
                    else if(AxeC==0)
                    {
                        step = "Attack";
                    }
                }
                else if (keyD == true)
                {
                    step = "next";
                }
                else if (keyL == true)
                {
                    step = "Thro";
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
                    else if (AxeC == 0)
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
            if (e.Key == Key.D && Canvas.GetLeft(player) < 950 && Canvas.GetLeft(bot) >= Canvas.GetLeft(player) && Canvas.GetLeft(bot1) >= Canvas.GetLeft(player))
            {
                Canvas.SetLeft(player, Canvas.GetLeft(player) + 20);
                keyD = true;
                if (Canvas.GetLeft(player) >= 950 && botHp.Value <= 0 && bot1Hp.Value <= 0)
                {

                    playWindow2 pw2 = new playWindow2();
                    pw2.Show();
                    this.Hide();
                }
            }
            else if (e.Key == Key.A && Canvas.GetLeft(player) > 0)
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
                else if (ShuC == 1)
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
