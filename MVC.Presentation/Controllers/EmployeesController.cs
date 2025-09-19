using AspNetCoreGeneratedDocument;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using MVC.Businesslogic.DataTransferObject.Employee;
using MVC.Businesslogic.Services.Interface;
using MVC.DataAccess.model.Employees;

namespace MVC.Presentation.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IEmployeeServices _employeeServices;
        private readonly ILogger<EmployeesController> _logger;
        private readonly IWebHostEnvironment _env;

        public EmployeesController(IEmployeeServices employeeServices,
                                   ILogger<EmployeesController>logger,
                                   IWebHostEnvironment env)
        {
            _employeeServices = employeeServices;
            _logger = logger;
            _env = env;
        }
        public IActionResult Index()
        {
            var employees = _employeeServices.GetAllEmp();
            return View(employees);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateEmployeeDto employeeDto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = _employeeServices.CreateEmployee(employeeDto);
                    if (result > 0)
                        return RedirectToAction(nameof(Index));
                    else
                        ModelState.AddModelError(string.Empty, "Failed to create employee");
                }
                catch (Exception ex)
                {
                    if(_env.IsDevelopment())
                        ModelState.AddModelError(string.Empty, ex.Message);
                    else
                        _logger.LogError(ex.Message);
                }
                
            }
            return View(employeeDto);
        }
        public IActionResult Details(int? id)
        {
            if(id is null) return BadRequest();
            var employee = _employeeServices.GetEmployeeById(id.Value);
            if (employee is null) return NotFound();
            return View(employee);
        }
        [HttpGet]
        public IActionResult Edit(int? id) 
        {
            if (id <= 0) return BadRequest();
            var employee = _employeeServices.GetEmployeeById(id.Value);
            if (employee is null) return NotFound();
            return View(new UpdateEmployeeDto()
            {
                Id = employee.Id,
                Name = employee.Name,
                Age = employee.Age,
                Address = employee.Address,
                IsActive = employee.IsActive,
                Salary = employee.Salary,
                Email = employee.Email,
                PhoneNumber = employee.PhoneNumber,
                HiringDate = employee.HiringDate,
                Gender = Enum.Parse<Gender>(employee.Gender),
                EmployeeType = Enum.Parse<EmployeeType>(employee.EmployeeType),
            });

        }
        [HttpPost]
        public IActionResult Edit([FromRoute]int? id ,UpdateEmployeeDto employeeDto)
        {
            if(id is null || id != employeeDto.Id) return BadRequest();
            if (ModelState.IsValid)
            {
                try
                {
                    var result = _employeeServices.UpdateEmployee(employeeDto);
                    if (result > 0)
                        return RedirectToAction(nameof(Index));
                    else
                        ModelState.AddModelError(string.Empty, "Failed to update employee");
                }
                catch (Exception ex)
                {
                    if (_env.IsDevelopment())
                        ModelState.AddModelError(string.Empty, ex.Message);
                    else
                        _logger.LogError(ex.Message);
                }
            }
            return View(employeeDto);

        }
        [HttpPost]
        public IActionResult Delete(int? id)
        {
            if (id is null) return BadRequest();
            try
            {
                var result = _employeeServices.DeleteEmployee(id.Value);
                if (result)
                    return RedirectToAction(nameof(Index));
                else
                    _logger.LogError($"Failed to delete employee with id {id}");
            }
            catch (Exception ex)
            {
                if (_env.IsDevelopment())
                    ModelState.AddModelError(string.Empty, ex.Message);
                else
                    _logger.LogError(ex.Message);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
