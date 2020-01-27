using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login
{
    class DataAcces
    {
        //SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Myconnection"].ConnectionString);


        public void InsertPerson(string Name, string Address, string PlaceBirth, string PhoneNum)
        {
           // using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Koneksi.CnnVal("MyConnection")))
            //{

                //List<Employee> people = new List<Employee>();
                //people.Add(new Employee { Name = Name, PhoneNum = PhoneNum, Address = Address, PlaceBirth = PlaceBirth });

              
                //conn.Execute(" exec SP_Retrieve_Insert @Name, @PhoneNum,  @Address, @PlaceBirth", people);
           // }
        }

        
      

        public static List<Employee> GetAll(int Id)
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["Myconnection"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                return db.Query<Employee>("GRidAll",new {id= Id }, commandType:CommandType.StoredProcedure).ToList();
            }
        }
    }
}
