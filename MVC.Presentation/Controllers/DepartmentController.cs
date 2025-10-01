using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVC.Businesslogic.DataTransferObject;
using MVC.Businesslogic.DataTransferObject.Department;
using MVC.Businesslogic.Services.Interface;
using MVC.DataAccess.Repositories;
using MVC.Presentation.ViewModels.Departments;

namespace MVC.Presentation.Controllers
{
    [Authorize]
    public class DepartmentController : Controller
    {
        private readonly IDepartmentServices _departmentServices;
        private readonly ILogger<DepartmentController> _logger;
        private readonly IWebHostEnvironment _env;

        public DepartmentController(IDepartmentServices departmentServices,
                             ILogger<DepartmentController> logger,
                             IWebHostEnvironment env)
        {
            _departmentServices = departmentServices;
            _logger = logger;
            _env = env;
        }
        public IActionResult Index()
        {
            //ViewData["Message"] = new DepartmentDto() { Name = "Hallo from ViewData" };
            //ViewBag.Message = new DepartmentDto() { Name = "Hallo from ViewBag" };
            var departments = _departmentServices.GetAllDepartments();
            return View(departments);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(DepartmentViewModel departmentVM)
        {
            if (!ModelState.IsValid)
            {
                return View(departmentVM);
            }
            var message = string.Empty;
            try
            {
                var departmentDto = new CreateDepartmindDto()
                {
                    Name = departmentVM.Name,
                    Description = departmentVM.Description,
                    Code = departmentVM.Code,
                    DateofCreation = departmentVM.DateofCreation
                };
                var result = _departmentServices.addDepartment(departmentDto);
               
                if (result > 0)
                {
                    message = "department created successfully";
                }
                else
                
                    //message = "department not created";
                    //ModelState.AddModelError(string.Empty, message);
                    //return View(departmentVM);
                    message = "department not created";
                TempData["Message"] = message;
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                if (_env.IsDevelopment())
                {
                    message = ex.Message;
                    return View(departmentVM);
                }
                else
                {
                    message = "department not created";
                    return View("Error", message);
                }
            } 
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            if(id is null)
            {
                return BadRequest();
            }
            var department = _departmentServices.GetDepartmentById(id.Value);
            if (department is null)
            {
                return NotFound();
            }
            return View(department);
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id is null)
            {
                return BadRequest();
            }
            var department = _departmentServices.GetDepartmentById(id.Value);
            if (department is null)
            {
                return NotFound();
            }
            return View(new DepartmentViewModel()
            {

                Name = department.Name,
                Description = department.Description,
                Code = department.Code,
                DateofCreation = department.DateofCreation
            });
        }
        [HttpPost]
        public IActionResult Edit([FromRoute]int id,DepartmentViewModel departmentVm)
        {
            if (!ModelState.IsValid)
            {
                return View(departmentVm);
            }
            var message = string.Empty;
            try
            {
                var result = _departmentServices.updateDepartment(new UpdatedDepartmentDto(){
                    Id = id,
                    Name = departmentVm.Name,
                    Description = departmentVm.Description,
                    Code = departmentVm.Code,
                    DateofCreation = departmentVm.DateofCreation
                });
                if (result > 0)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    message = "department not updated";
                    
                }

            }
            catch (Exception ex)
            {
                message =_env.IsDevelopment() ? ex.Message : "department not updated";
                
            }
            return View(departmentVm);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id is null)
            {
                return BadRequest();
            }
            var department = _departmentServices.GetDepartmentById(id.Value);
            if (department is null)
            {
                return NotFound();
            }
            return View(department);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var message= string.Empty;
            try
            {
                var result = _departmentServices.deleteDepartment(id);
                if (result)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    message = "error happened when deleting";
                    return View(nameof(Index));
                }

            }
            catch(Exception ex) 
            {
                _logger.LogError(ex, ex.Message);
                message = _env.IsDevelopment() ? ex.Message : "error happened when deleting";

            }
            return View(nameof(Index));

        }
    } 
}
