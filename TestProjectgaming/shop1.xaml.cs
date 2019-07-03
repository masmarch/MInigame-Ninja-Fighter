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

namespace TestProjectgaming
{
    /// <summary>
    /// Interaction logic for shop1.xaml
    /// </summary>
    /// 
    public partial class shop1 : Window
    {
        public shop1()
        {
            InitializeComponent();
        }
        int AxeC = 0;
        int ShuC = 0;
        int KunaC = 0;
        int BomC = 0;
        
        private void axe_Click(object sender, RoutedEventArgs e)
        {
            if (AxeC == 1)
            {
                MessageBox.Show("ท่านมีไอเท็มนี้เเล้ว");
            }
            else if (MainWindow.MN >= 300)
            {
                string sql = "UPDATE `logingame1` SET `axe`= 1  WHERE username ='" + MainWindow.NM + "'";

                MySqlConnection con = new MySqlConnection("host=localhost;user=project;password=123456;database=gameshop");
                MySqlCommand cmd = new MySqlCommand(sql, con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("ซื้อไอเท็มเรียบร้อยเเล้ว");
                MainWindow.MN -= 300;
                label.Content = MainWindow.MN;
            }
            else
                MessageBox.Show("มีเงินไม่เพียงพอ","Important Message");
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (ShuC == 1)
            {
                MessageBox.Show("ท่านมีไอเท็มนี้เเล้ว");
            }
            else if (MainWindow.MN >= 500)
            {
                string sql = "UPDATE `logingame1` SET `shuriken`= 1,`kunai`= 0,`bomb`= 0  WHERE username ='" + MainWindow.NM + "'";

                MySqlConnection con = new MySqlConnection("host=localhost;user=project;password=123456;database=gameshop");
                MySqlCommand cmd = new MySqlCommand(sql, con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MainWindow.MN -= 500;
                label.Content = MainWindow.MN;
            }            
            else
                MessageBox.Show("มีเงินไม่เพียงพอ");
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (KunaC == 1)
            {
                MessageBox.Show("ท่านมีไอเท็มนี้เเล้ว");
            }
            else if (MainWindow.MN >= 800)
            {
                string sql = "UPDATE `logingame1` SET `kunai`= 1,`shuriken`= 0,`bomb`= 0  WHERE username ='" + MainWindow.NM + "'";

                MySqlConnection con = new MySqlConnection("host=localhost;user=project;password=123456;database=gameshop");
                MySqlCommand cmd = new MySqlCommand(sql, con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MainWindow.MN -= 800;
                label.Content = MainWindow.MN;
            }
            else
                MessageBox.Show("มีเงินไม่เพียงพอ");
        }

        private void bomb_Click(object sender, RoutedEventArgs e)
        {
            if (BomC == 1)
            {
                MessageBox.Show("ท่านมีไอเท็มนี้เเล้ว");
            }
            else if (MainWindow.MN >= 1000)
            {
                string sql = "UPDATE `logingame1` SET `bomb`= 1,`kunai`= 0,`shuriken`= 0  WHERE username ='" + MainWindow.NM + "'";

                MySqlConnection con = new MySqlConnection("host=localhost;user=project;password=123456;database=gameshop");
                MySqlCommand cmd = new MySqlCommand(sql, con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MainWindow.MN -= 1000;
                label.Content = MainWindow.MN;
            }
            else
                MessageBox.Show("มีเงินไม่เพียงพอ");
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Home hm = new Home();
            hm.Show();
            this.Hide();
            string sql = "UPDATE `logingame1` SET `price`= '"+MainWindow.MN+"' WHERE username ='" + MainWindow.NM + "'";

            MySqlConnection con = new MySqlConnection("host=localhost;user=project;password=123456;database=gameshop");
            MySqlCommand cmd = new MySqlCommand(sql, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            label.Content = "$  "+ MainWindow.MN ;
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
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
