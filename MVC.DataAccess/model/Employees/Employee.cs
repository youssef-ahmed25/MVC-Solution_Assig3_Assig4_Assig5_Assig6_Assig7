using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.DataAccess.model.Employees
{
    public class Employee: BaseEntity
    {
        public string Name { get; set; } = null!;
        public string? Address { get; set; }
        public int? Age { get; set; }

        public decimal Salary { get; set; }
        public string Email { get; set; } = null!;
        public DateTime HiringDate { get; set; }
        public Gender Gender { get; set; }
        public EmployeeType EmployeeType { get; set; }
        public string PhoneNumber { get; set; } = null!;
        public bool IsActive { get; set; }
    }
}
