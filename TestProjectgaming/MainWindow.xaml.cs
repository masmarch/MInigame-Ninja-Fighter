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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TestProjectgaming
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
        public static string NM;
        public static int MN;

        private void register_Click(object sender, RoutedEventArgs e)
        {
            string sql = "SELECT * FROM logingame1";
            sql = "INSERT INTO logingame1 (username,password) VALUE('" + usernametxt.Text + "','" + passwordtxt.Password + "')";
            MySqlConnection con = new MySqlConnection("host=localhost;user=project;password=123456;database=gameshop");
            MySqlCommand cmd = new MySqlCommand(sql, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("register เรียบร้อยเเล้ว");
        }

        private void login_Click(object sender, RoutedEventArgs e)
        {
            string user= usernametxt.Text;
            string sql = "SELECT * FROM logingame1 WHERE username ='" + user + "'AND password = '" +passwordtxt.Password+"'";
            MySqlConnection con = new MySqlConnection("host=localhost;user=project;password=123456;database=gameshop");
            MySqlCommand cmd = new MySqlCommand(sql, con);
            con.Open();
            MySqlDataReader mdr = cmd.ExecuteReader();

            if(mdr.Read()) 
            {
                MessageBox.Show("Login Suscess");
                NM = user;
                MN = mdr.GetInt16("price");
                Home hm = new Home();
                hm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Username or Password was wrong!!!");
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            shop1 sh = new shop1();
            sh.Show();
            this.Hide();
        }
    }
}
