using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirstCrudOperation.Models
{
    public class Employee
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Qualification { get; set; }
        public string Experience { get; set; }
        public DateTime JoiningDate { get; set; }
        public string ExpectedSal { get; set; }
        //public ICollection<Employee> Employees { get; set; }

    }
}