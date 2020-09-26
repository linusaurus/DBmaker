using System;
using System.Collections.Generic;

namespace DBmaker.Models
{
    public partial class Employee
    {
        public Employee()
        {
            Delivery = new HashSet<Delivery>();
        }

        public int employeeID { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string middlename { get; set; }
        public bool? IsPurchaser { get; set; }
        public string EmployeeEmail { get; set; }
        public bool? Show { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int? Role { get; set; }

        public virtual ICollection<Delivery> Delivery { get; set; }
    }
}
