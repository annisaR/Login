using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login
{
    class Class1
    {
        public string email { get; set; }
        public string Password { get; set; }
        public string role { get; set; }

    }
    class Employee
    {
        public int Id_dept { get; set; }
        public string Name { get; set; }
        public string PhoneNum { get; set; }
        public string Address { get; set; }
        public string PlaceBirth { get; set; }
        public DateTime BirthDate { get; set; }
        public string NIK { get; set; }
        public string Email { get; set; }
        public string Religion { get; set; }
        public string NPWP { get; set; }
        public string Bachelor { get; set; }
        public string University { get; set; }
        public string JoinDate { get; set; }
        public string Status { get; set; }       
    }
    class Department
    {
        public string name { get; set; }
        public string manager { get; set; }
    }

    class DataDepartment
    {
        public string name { get; set; }
        public string manager { get; set; }
    }
}
