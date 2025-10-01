using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVC.DataAccess.model.IdentityModels;
using MVC.Presentation.Utilities;
using MVC.Presentation.ViewModels.Account;

namespace MVC.Presentation.Controllers
{
    public class AccountController : Controller

    {
        public readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(UserManager<ApplicationUser> userManager,
                                 SignInManager<ApplicationUser> signInManager)
        {

            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var user = _userManager.FindByNameAsync(viewModel.UserName).Result;
                if (user is null)
                {
                    user = new ApplicationUser()
                    {
                        FirstName = viewModel.FirstName,
                        LastName = viewModel.LastName,
                        UserName = viewModel.UserName,
                        Email = viewModel.Email
                    };
                    var result = _userManager.CreateAsync(user, viewModel.Password).Result;
                    if (result.Succeeded)
                    {
                        return RedirectToAction("LogIn");
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                    }

                }
                else
                {
                    ModelState.AddModelError(string.Empty, "UserName already exists");

                }

            }
            return View(viewModel);
        }

        public IActionResult LogIn()
        {
            return View();
        }
        [HttpPost]
        public IActionResult LogIn(LoginViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var user = _userManager.FindByEmailAsync(viewModel.Email).Result;
                if (user is not null)
                {
                    var flag = _userManager.CheckPasswordAsync(user, viewModel.Password).Result;
                    if (flag)
                    {
                        var Result = _signInManager.PasswordSignInAsync(user, viewModel.Password, viewModel.RememberMe, false).Result;
                        if (Result.IsNotAllowed)
                        {
                            ModelState.AddModelError(string.Empty, "Not Allowed To SignIn");
                        }
                        if (Result.IsLockedOut)
                        {
                            ModelState.AddModelError(string.Empty, "You Are LockedOut");
                        }
                        if (Result.Succeeded)
                        {
                            return RedirectToAction(nameof(HomeController.Index), "Home");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "InCorrect Email Or Password");
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid LogIn");
                }
            }
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult LogOut()
        {
            _signInManager.SignOutAsync().GetAwaiter().GetResult();
            return RedirectToAction(nameof(LogIn));

        }

        public IActionResult ForgetPassword()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SendResetPasswordLink(ForgetPasswordViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                
                var user = _userManager.FindByEmailAsync(viewModel.Email).Result;
                if (user is not null)
                {
                    var Token = _userManager.GeneratePasswordResetTokenAsync(user).Result;
                    var ResetPasswordLink = Url.Action("ResetPassword", "Account", new { email = viewModel.Email,Token }, Request.Scheme);
                    var email = new Email()
                    {
                        To = viewModel.Email,
                        Subject = "Reset Password",
                        Body = ResetPasswordLink
                    };
                    EmailSettings.SendEmail(email);
                    return RedirectToAction(nameof(CheckYourInbox));
                }
            }
            ModelState.AddModelError(string.Empty, "Invalid operation");
            return View(nameof(ForgetPassword), viewModel);
        }
        public IActionResult CheckYourInbox()
        {
            return View();
        }
        [HttpGet]
        public IActionResult ResetPassword(string email,string Token)
        {
            TempData["email"] = email;
            TempData["Token"] = Token;
            return View();
        }
        [HttpPost]
        public IActionResult ResetPassword(ResetPasswordViewModel viewModel)
        {
            if (!ModelState.IsValid) return View(viewModel);
            string email = TempData["email"]as string?? string.Empty;
            string Token = TempData["Token"] as string ?? string.Empty;

            var user = _userManager.FindByEmailAsync(email).Result;
            if (user is not null)
            {
                var result = _userManager.ResetPasswordAsync(user, Token, viewModel.Password).Result;
                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(LogIn));
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }

            return View(viewModel);
        }
        
    }
}
