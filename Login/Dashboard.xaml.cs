using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
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
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class Dashboard : Window
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Myconnection"].ConnectionString);
        List<Employee> people = new List<Employee>();
        public Dashboard()
        {
            InitializeComponent();
           // Getemploye();
        }

       
        private void btn_employ(object sender, RoutedEventArgs e)
        {
            UserControl1 tampil = new UserControl1();
            SPcontent.Children.Clear();
            SPcontent.Children.Add(tampil);
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PagDepartmen PagDepartmen = new PagDepartmen();
            SPcontent.Children.Clear();
            SPcontent.Children.Add(PagDepartmen);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
             Departmen Tampilgrid = new Departmen();
            SPcontent.Children.Clear();
            SPcontent.Children.Add(Tampilgrid);
        }
    }
   

       
    }
