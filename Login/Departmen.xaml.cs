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
    /// Interaction logic for Departmen.xaml
    /// </summary>
    public partial class Departmen : UserControl
    {

        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Myconnection"].ConnectionString);
        private int currentRow;

        public Departmen()
        {
            InitializeComponent();
        }
        public void clear()
        {
            name.Text = "";
            manager.Text = "";
        }
        public void refresh()
        {
            var view = conn.QueryAsync< DataDepartment>("exec SP_Retrive_Select_DEpt").Result.ToList();
            Detail_dept.ItemsSource = view;
        }

        private void btn_insert(object sender, RoutedEventArgs e)
        {
         var Check = conn.ExecuteAsync("exec SP_InsertDepartment  @name,@manager", 
             new { name = name.Text, manager = manager.Text });
            MessageBox.Show("Data Has Been Entered");
            clear();
        }
        

        private void Detail_dept_Loaded(object sender, RoutedEventArgs e)
        {
            var check = conn.QueryAsync<DataDepartment>("exec SP_Retrive_Select_DEpt").Result.ToList();
            var grid = sender as DataGrid;
            grid.ItemsSource = check;
            refresh();
        }


       

        private void Detail_dept_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object item = Detail_dept.SelectedItem;
            name.Text = (Detail_dept.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
            manager.Text = (Detail_dept.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;

        }
    }
}
