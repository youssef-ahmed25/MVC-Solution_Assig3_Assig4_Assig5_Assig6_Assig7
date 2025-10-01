using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVC.DataAccess.model.IdentityModels;
using MVC.Presentation.ViewModels.User;

namespace MVC.Presentation.Controllers
{
    public class ManagerController : Controller
    {
        public readonly UserManager<ApplicationUser> _rolemanager;

        public ManagerController(UserManager<ApplicationUser> rolemanager)
        {

            _rolemanager = rolemanager;

        }
        public IActionResult Index()
        {

            var roles = _rolemanager.Users.ToList();

            var roleView = new List<RoleViewModel>();

            foreach (var role in roles)
            {
                var roleViewModel = new RoleViewModel
                {
                    Id = role.Id,
                    RoleName = role.UserName
                };

                roleView.Add(roleViewModel);

            }
            return View(roleView);

        }
        [HttpGet]
        public IActionResult Details(string id)
        {
            if (id is null)
            {
                return BadRequest();
            }
            var role = _rolemanager.FindByIdAsync(id).Result;
            if (role is null)
            {
                return NotFound();
            }
            var roleViewModel = new RoleViewModel
            {
                Id = role.Id,
                RoleName = _rolemanager.GetRolesAsync(role).Result.FirstOrDefault()

            };
            return View(roleViewModel);
        }
        [HttpGet]
        public IActionResult Edit(string id)
        {
            if (id is null)
            {
                return BadRequest();
            }
            var role = _rolemanager.FindByIdAsync(id).Result;
            if (role is null)
            {
                return NotFound();
            }
            var roleViewModel = new RoleViewModel
            {
                Id = role.Id,
                RoleName = role.UserName

            };
            return View(roleViewModel);
        }
        [HttpPost]
        public IActionResult Edit([FromRoute] string id, RoleViewModel roleVm)
        {
            if (!ModelState.IsValid || id != roleVm.Id)
            {
                return BadRequest();
            }
            var role = _rolemanager.FindByIdAsync(id).Result;
            if (role is null)
            {
                return NotFound();
            }
            role.UserName = roleVm.RoleName;
            var result = _rolemanager.UpdateAsync(role).Result;
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
            return View(roleVm);
        }
        [HttpGet]
        public IActionResult Delete(string id)
        {
            if (id is null)
            {
                return BadRequest();
            }
            var role = _rolemanager.FindByIdAsync(id).Result;
            if (role is null)
            {
                return NotFound();
            }
            var roleViewModel = new RoleViewModel
            {
                Id = role.Id,
                RoleName = _rolemanager.GetRolesAsync(role).Result.FirstOrDefault()
            };
            return View(roleViewModel);
        }
        [HttpPost]
        public IActionResult Delete([FromRoute] string id, RoleViewModel roleVm)
        {
            try
            {
                var role = _rolemanager.FindByIdAsync(id).Result;
                if (role is null) return BadRequest();
                var result = _rolemanager.DeleteAsync(role).Result;
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
                    return View(roleVm);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(roleVm);
            }
        }

    }
}
