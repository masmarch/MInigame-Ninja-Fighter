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
    /// Interaction logic for final.xaml
    /// </summary>
    public partial class final : Window
    {
        public final()
        {
            InitializeComponent();
        }
        public static string result = "";

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtResult.Content = result;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Home hm = new Home();
            hm.Show();
            this.Hide();
        }
    }
}
