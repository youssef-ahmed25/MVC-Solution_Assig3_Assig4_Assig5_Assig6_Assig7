using MVC.DataAccess.model.Employees;
using System.ComponentModel.DataAnnotations;

namespace MVC.Presentation.ViewModels.Employees
{
    public class EmployeeViewModel
    {
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

        [Display(Name = "Department")]
        public int? DepartmentId { get; set; }
        public IFormFile? Image { get; set; }
    }
}
