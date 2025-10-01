using System.ComponentModel.DataAnnotations;

namespace MVC.Presentation.ViewModels.Account
{
    public class LoginViewModel
    {
        [DataType(DataType.EmailAddress)]
        public String Email { get; set; }
        [DataType(DataType.Password)]
        public String Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
