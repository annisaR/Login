using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
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

namespace Login
{
    /// <summary>
    /// Interaction logic for PagDepartmen.xaml
    /// </summary>
    public partial class PagDepartmen : UserControl
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Myconnection"].ConnectionString);
        public PagDepartmen()
        {
            InitializeComponent();
        }

        private void Tmpil_employe_Loaded(object sender, RoutedEventArgs e)
        {
            
            var check = conn.QueryAsync<Employee>("exec SP_Retrivie_SElect_").Result.ToList();
            var grid = sender as DataGrid;
            grid.ItemsSource = check;
            
        }

       
    }
}
