using Microsoft.AspNetCore.Mvc;
using MVC.Businesslogic.Services;
using MVC.DataAccess.Repositories;

namespace MVC.Presentation.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentServices _departmentServices;

        public DepartmentController(IDepartmentServices departmentServices)
        {
            _departmentServices = departmentServices;
        }
        public IActionResult Index()
        {
            var departments = _departmentServices.GetAllDepartments();
            return View();
        }
    }
}
