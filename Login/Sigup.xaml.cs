using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace Login
{
    /// <summary>
    /// Interaction logic for Sigup.xaml
    /// </summary>
    public partial class Sigup : Window
    {
        static string conn = System.Configuration.ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
        SqlConnection sqlConnection = new SqlConnection(conn);
        public Sigup()
        {
            InitializeComponent();
        }

        private void sigupnbtn_Click(object sender, RoutedEventArgs e)
        {
            string myPassword = password.Password;
            string mySalt = BCrypt.Net.BCrypt.GenerateSalt();
            string myHash = BCrypt.Net.BCrypt.HashPassword(myPassword, mySalt);
            var affectedRows = sqlConnection.Execute("INSERT INTO TB_M_Login (email,password,role) VALUES (@email, @password,@role)", new { email = email.Text, password = myHash });
            if (affectedRows < 0)
            {
                MessageBox.Show("Failed to Register");
            }
            else
            {
                MessageBox.Show("Success to Register");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            new MainWindow().Show();
        }
    }
}
