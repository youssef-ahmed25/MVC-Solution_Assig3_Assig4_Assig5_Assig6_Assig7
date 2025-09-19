using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Businesslogic.DataTransferObject.Employee
{
    public class EmployeeDetailsDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public int? Age { get; set; }

        public decimal Salary { get; set; }
        public bool IsActive { get; set; }
        public DateOnly HiringDate { get; set; }
        public string Gender { get; set; } = null!;
        public string EmployeeType { get; set; } = null!;
        public int CreatedBy { get; set; }
        public int LastModifiedBy { get; set; }

        public DateTime CreatedOn { get; set; }
        public DateTime LastModifiedOn { get; set; }


    }
}
