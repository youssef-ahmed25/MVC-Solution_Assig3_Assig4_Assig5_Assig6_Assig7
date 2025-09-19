using MVC.Businesslogic.DataTransferObject.Employee;
using MVC.DataAccess.model.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Businesslogic.Factories
{
    public static class EmployeeFactory 
    {
        public static Employee ToEentity(this CreateEmployeeDto employeeDto)
        {
            return new Employee()
            {
                Name = employeeDto.Name,
                Age = employeeDto.Age,
                Address = employeeDto.Address,
                IsActive = employeeDto.IsActive,
                Salary = employeeDto.Salary,
                Email = employeeDto.Email,
                PhoneNumber = employeeDto.PhoneNumber,
                Gender = employeeDto.Gender,
                HiringDate = employeeDto.HiringDate.ToDateTime(TimeOnly.MinValue), 
                EmployeeType = employeeDto.EmployeeType,
                CreatedBy = employeeDto.CreatedBy,
                LastModifiedBy = employeeDto.LastModifiedBy
            };
        }

        public static Employee ToEentity(this UpdateEmployeeDto employeeDto)
        {
            return new Employee()
            {
                Id = employeeDto.Id,
                Name = employeeDto.Name,
                Age = employeeDto.Age,
                Address = employeeDto.Address,
                IsActive = employeeDto.IsActive,
                Salary = employeeDto.Salary,
                Email = employeeDto.Email,
                PhoneNumber = employeeDto.PhoneNumber,
                Gender = employeeDto.Gender,
                HiringDate = employeeDto.HiringDate.ToDateTime(TimeOnly.MinValue),
                EmployeeType = employeeDto.EmployeeType,
                CreatedBy = employeeDto.CreatedBy,
                LastModifiedBy = employeeDto.LastModifiedBy

            };
        }
    }
}
