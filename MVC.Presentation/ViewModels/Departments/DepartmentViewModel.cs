namespace MVC.Presentation.ViewModels.Departments
{
    public class DepartmentViewModel
    {
        
        public string Name { get; set; } = null!;
        public string? Description { get; set; } = string.Empty;
        public string Code { get; set; } = null!;

        public DateOnly DateofCreation { get; set; }
    }
}
