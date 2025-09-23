using System.ComponentModel.DataAnnotations;

namespace MVC.Presentation.ViewModels.Departments
{
    public class DepartmentViewModel
    {
        
        public string Name { get; set; } = null!;
        public string? Description { get; set; } = string.Empty;

        [Range(10, int.MaxValue, ErrorMessage = "Code must be at least 10 characters long.")]
        public string Code { get; set; } = null!;

        public DateOnly DateofCreation { get; set; }
    }
}
