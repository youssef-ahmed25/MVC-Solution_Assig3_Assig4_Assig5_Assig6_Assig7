using MVC.Businesslogic.DataTransferObject;
using MVC.Businesslogic.Factories;
using MVC.Businesslogic.Services.Interface;
using MVC.DataAccess.Repositories.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Businesslogic.Services
{
    public class EmployeeServices:IEmployeeServices
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeServices(IEmployeeRepository employeeRepository) 
        {
            _employeeRepository = employeeRepository;
        }

        public IEnumerable<EmployeeDto> GetAllEmp(bool withTracking = false)
        {
            var employees = _employeeRepository.GetAll(withTracking);
            var empoyeesToReturn = employees.Select(e => new EmployeeDto(){
                Id = e.Id,
                Name = e.Name,
                Email = e.Email,
                IsActive = e.IsActive,
                Salary = e.Salary,
                Gender = e.Gender.ToString(),
                EmployeeType = e.EmployeeType.ToString(),
            });
            return empoyeesToReturn;
        }

        public EmployeeDetailsDto? GetEmployeeById(int id)
        {
            var employee = _employeeRepository.GetbyId(id);
            if (employee == null)
            {
                return null;
            }
            return new EmployeeDetailsDto()
            {
                Id = employee.Id,
                Name = employee.Name,
                Email = employee.Email,
                Salary=employee.Salary,
                Address = employee.Address,
                Age = employee.Age,
                Phone = employee.PhoneNumber,
                IsActive = employee.IsActive,
                HiringDate = DateOnly.FromDateTime(employee.HiringDate),
                Gender=employee.Gender.ToString(),
            };
        }
        public int CreateEmployee(CreateEmployeeDto employeeDto)
        {
            var employee=_employeeRepository.Add(employeeDto.ToEentity());
            return employee;
        }

        public int UpdateEmployee(UpdateEmployeeDto employeeDto)
        {
            var employee = _employeeRepository.Update(employeeDto.ToEentity());
            return employee;
        }
    }
}
