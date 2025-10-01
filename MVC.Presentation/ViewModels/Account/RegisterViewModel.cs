using System.ComponentModel.DataAnnotations;

namespace MVC.Presentation.ViewModels.Account
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage ="FirstName is required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "LastName is required")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "UserName is required")]
        [MaxLength(50, ErrorMessage = "UserName should be less than 50")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
        public bool IsAgree { get; set; }
    }
}
