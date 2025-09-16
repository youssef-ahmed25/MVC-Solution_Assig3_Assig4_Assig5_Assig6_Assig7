using MVC.DataAccess.model.Employees;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Businesslogic.DataTransferObject
{
    public  class CreateEmployeeDto
    {
        [Required]
        [MaxLength(50,ErrorMessage="name shoud be lees than 50")]
        [MinLength(3)]
        public string Name { get; set; } = null!;
        [Range(24, 50)]
        public int? Age { get; set; }
        public string Address { get; set; } = null!;
        public bool IsActive { get; set; }
        public decimal Salary { get; set; }
        public string Email { get; set; } = null!;
        
        public string Phone { get; set; } = null!;
        public DateOnly HiringDate { get; set; }
        public Gender Gender { get; set; } 
        public EmployeeType EmployeeType { get; set; } 
        public int CreatedBy { get; set; }
        public int LastModifiedBy { get; set; }

    }
}
