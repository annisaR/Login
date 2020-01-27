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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Configuration;
using Dapper;

namespace Login
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static string conn = System.Configuration.ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
        SqlConnection sqlConnection = new SqlConnection(conn);
        public MainWindow()
        {
            InitializeComponent();
        }


        private void loginbtn_Click(object sender, RoutedEventArgs e)
        {
            string Mypassword = password.Password;
            var getPassword = sqlConnection.Query<Class1>("select * from TB_M_Login where email = @email", new { email = email.Text }).SingleOrDefault();
            var result = BCrypt.Net.BCrypt.Verify(Mypassword, getPassword.Password);
            if (getPassword.role=="admin")
            {
                
                    this.Hide();
                    new Dashboard().Show();
                
               
            }
            else
                MessageBox.Show(this, "isikan data.", "Message");
        }

        private void sigupnbtn_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            new Sigup().Show();
        }
    }
}



      