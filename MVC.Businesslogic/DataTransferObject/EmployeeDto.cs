using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Businesslogic.DataTransferObject
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public int? Age { get; set; } 

        public decimal Salary { get; set; }
        public bool IsActive { get; set; }

        public string Gender { get; set; } = null!;
        public string EmployeeType { get; set; } = null!;
    }
}
