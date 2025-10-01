using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVC.DataAccess.model.IdentityModels;
using MVC.Presentation.ViewModels.Account;
using MVC.Presentation.ViewModels.User;

namespace MVC.Presentation.Controllers
{
    public class UserController : Controller
    {
        public readonly UserManager<ApplicationUser> _userManager;

        public UserController(UserManager<ApplicationUser> userManager)
        {

            _userManager = userManager;

        }
        public IActionResult Index()
        {

            var users = _userManager.Users.ToList();

            var userView = new List<UserViewModel>();

            foreach (var user in users)
            {
                var userViewModel = new UserViewModel
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
                    Role = _userManager.GetRolesAsync(user).Result.FirstOrDefault()
                };

                userView.Add(userViewModel);

            }
            return View(userView);

        }
        [HttpGet]
        public IActionResult Details(string id)
        {
            if (id is null)
            {
                return BadRequest();
            }

            var user = _userManager.FindByIdAsync(id).Result;
            if (user is null)
            {
                return NotFound();
            }

            var userViewModel = new UserViewModel
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber
            };

            return View(userViewModel);
        }
        [HttpGet]
        public IActionResult Edit(string id)
        {
            if (id is null)
            {
                return BadRequest();
            }

            var user = _userManager.FindByIdAsync(id).Result;
            if (user is null)
            {
                return NotFound();
            }

            var userViewModel = new UserViewModel
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber
            };

            return View(userViewModel);
        }

        [HttpPost]
        public IActionResult Edit([FromRoute] string id, UserViewModel userVm)
        {
            if (!ModelState.IsValid)
            {
                return View(userVm);
            }
            var message = string.Empty;
            try
            {
                var user = _userManager.FindByIdAsync(id).Result;
                if (user is null)
                {
                    return NotFound();
                }
                user.FirstName = userVm.FirstName;
                user.LastName = userVm.LastName;
                user.PhoneNumber = userVm.PhoneNumber;
                var result = _userManager.UpdateAsync(user).Result;
                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                    return View(userVm);
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
                ModelState.AddModelError(string.Empty, message);
                return View(userVm);
            }
        }
        [HttpGet]
        public IActionResult Delete(string id)
        {
            if (id is null)
            {
                return BadRequest();
            }
            var user = _userManager.FindByIdAsync(id).Result;
            if (user is null)
            {
                return NotFound();
            }
            else
            {
                var userViewModel = new UserViewModel
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber
                };

                return View(userViewModel);
            }
        }
        [HttpPost]
        public IActionResult Delete(string id, UserViewModel usermodel)
        {
            
            try
            {
                var user = _userManager.FindByIdAsync(id).Result;
                if (user is null) return BadRequest();
                var result = _userManager.DeleteAsync(user).Result;
                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                    return View(usermodel);
                }
            }
            catch (Exception ex)
            {
                var message = ex.Message;
                ModelState.AddModelError(string.Empty, message);
                return View(usermodel);

            }
            
        }
    }
}
        

    


