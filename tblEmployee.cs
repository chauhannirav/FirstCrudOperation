//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FirstCrudOperation
{
    using FirstCrudOperation.Models;
    using System;
    using System.Collections.Generic;
    
    public partial class tblEmployee
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Qualification { get; set; }
        public string Experience { get; set; }
        public Nullable<System.DateTime> JoiningDate { get; set; }
        public string ExpectedSal { get; set; }
        public ICollection<Employee> Employees { get; set; }

    }
}
