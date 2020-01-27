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
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Myconnection"].ConnectionString);

        public UserControl1()
        {
            InitializeComponent();
            update();
        }
        private void clear()
        {
            Iddepart.Text = "";
            Name.Text = "";
            PhoneNum.Text = "";
            Addres.Text = "";
            PlaceBirth.Text = "";
            Birthdate.Text =" ";
            NIK.Text = "";
            Email.Text = "";
            Religion.Text = "";
            NPWP.Text = "";
            Bachelor.Text = "";
            University.Text = "";
            JoinDate.Text ="";
            Status.Text = "";
        }

        private void insertClick(object sender, RoutedEventArgs e)
        {
            var check = conn.ExecuteAsync("exec SP_INSERT_Employe  @Id_dept,@Name,@PhoneNum,@Addres,@PlaceBirth,@BirthDate,@NIK,@Email,@Religion,@NPWP,@Bachelor,@University,@JoinDate,@Status", 
            new
            {
                Id_dept = Iddepart.Text,
                Name = Name.Text,
                PhoneNum = PhoneNum.Text,
                Addres = Addres.Text,
                PlaceBirth = PlaceBirth.Text,
                BirthDate = Birthdate.SelectedDate,
                NIK = NIK.Text,
                Email = Email.Text,
                Religion = Religion.Text,
                NPWP = NPWP.Text,
                Bachelor = Bachelor.Text,
                University = University.Text,
                JoinDate = JoinDate.SelectedDate,
                Status = Status.Text
            });
            MessageBox.Show("Okee masukk");
            clear();
        }

        private void update()
        {
       
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Myconnection"].ConnectionString))
                {
                    conn.Open();
                    string selectquery = "Select Id from TB_M_Department";
                    SqlCommand comm = new SqlCommand(selectquery, conn);
                    SqlDataReader reader = comm.ExecuteReader();
                    while (reader.Read())
                    {
                    // Iddepart.Items.Add(reader["Name"].ToString());
                    Iddepart.Items.Add(reader["Id"].ToString());
                        
                    }

                }
          
            conn.Close();
        }

        private void Iddepart_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            Iddepart.Items.Clear();
            update ();
        }
    }
}
