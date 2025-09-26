using Microsoft.AspNetCore.Http;
using MVC.DataAccess.model.Employees;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Businesslogic.DataTransferObject.Employee
{
    public class UpdateEmployeeDto
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "name shoud be lees than 50")]
        [MinLength(3)]
        public string Name { get; set; } = null!;
        [Range(24, 50)]
        public int? Age { get; set; }
        [RegularExpression("^[1-9]{1,3}-[a-zA-Z]{5,10}-[a-zA-Z]{5,10}-[a-zA-Z]{5,10}$",
                      ErrorMessage = "must be 123-street-city-country")]
        public string Address { get; set; } = null!;
        [Display(Name = "Is Active")]
        public bool IsActive { get; set; }
        [DataType(DataType.Currency)]
        public decimal Salary { get; set; }
        [EmailAddress]
        public string Email { get; set; } = null!;
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; } = null!;
        [Display(Name = "Hiring Date")]
        public DateOnly HiringDate { get; set; }
        public Gender Gender { get; set; }
        public EmployeeType EmployeeType { get; set; }
        public int CreatedBy { get; set; }
        public int LastModifiedBy { get; set; }
        public int? DepartmentId { get; set; }
        //public IFormFile? Image { get; set; }


    }
}
