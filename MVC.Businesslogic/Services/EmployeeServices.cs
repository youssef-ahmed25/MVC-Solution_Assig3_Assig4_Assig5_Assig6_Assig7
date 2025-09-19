using AutoMapper;
using MVC.Businesslogic.DataTransferObject.Employee;
using MVC.Businesslogic.Factories;
using MVC.Businesslogic.Services.Interface;
using MVC.DataAccess.model.Employees;
using MVC.DataAccess.Repositories.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Businesslogic.Services
{
    public class EmployeeServices : IEmployeeServices
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public EmployeeServices(IEmployeeRepository employeeRepository,IMapper mapper) 
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public IEnumerable<EmployeeDto> GetAllEmp(bool withTracking = false)
        {
            var employees = _employeeRepository.GetAll(withTracking);
            var empoyeesToReturn = _mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeDto>>(employees);
            return empoyeesToReturn;
            //var employees = _employeeRepository.GetAll(E=>new EmployeeDto
            //{
            //    Id = E.Id,
            //    Name = E.Name,
            //    Age = E.Age,
            //    Salary = E.Salary
            //}).Where(E => E.Age > 24);
            //return employees;
            #region Enumerable and IQueryable
            //Enumerableجزء
            //var employees = _employeeRepository.GetEnumerable();
            //var empoyeesToReturn = employees.Select(E=>new EmployeeDto
            //{
            //    Name = E.Name,
            //    Age = E.Age,
            //    Email = E.Email

            //});
            //IQueryableجزء
            //var employees = _employeeRepository.GetQueryable();
            //var empoyeesToReturn = employees.Select(E => new EmployeeDto
            //{
            //    Name = E.Name,
            //    Age = E.Age,
            //    Email = E.Email

            //}); 
            //return empoyeesToReturn;
            #endregion
            #region basic convert
            //var empoyeesToReturn = employees.Select(e => new EmployeeDto()
            //{
            //    Id = e.Id,
            //    Name = e.Name,
            //    Email = e.Email,
            //    IsActive = e.IsActive,
            //    Salary = e.Salary,
            //    Gender = e.Gender.ToString(),
            //    EmployeeType = e.EmployeeType.ToString(),
            //}); 
            //return empoyeesToReturn;
            #endregion

        }

        public EmployeeDetailsDto? GetEmployeeById(int id)
        {
            var employee = _employeeRepository.GetbyId(id);
            if (employee == null)
            {
                return null;
            }
            return _mapper.Map<Employee, EmployeeDetailsDto>(employee);
            #region basic
            //return new EmployeeDetailsDto()
            //{
            //    //Id = employee.Id,
            //    //Name = employee.Name,
            //    //Email = employee.Email,
            //    //Salary=employee.Salary,
            //    //Address = employee.Address,
            //    //Age = employee.Age,
            //    //Phone = employee.PhoneNumber,
            //    //IsActive = employee.IsActive,
            //    //HiringDate = DateOnly.FromDateTime(employee.HiringDate),
            //    //Gender=employee.Gender.ToString(),
            //}; 
            #endregion
        }
        public int CreateEmployee(CreateEmployeeDto employeeDto)
        {
            //var employee=_employeeRepository.Add(employeeDto.ToEentity());
            //return employee;
            var employee = _mapper.Map<CreateEmployeeDto, Employee>(employeeDto);
            return _employeeRepository.Add(employee);
        }

        public int UpdateEmployee(UpdateEmployeeDto employeeDto)
        {
            //var employee = _employeeRepository.Update(employeeDto.ToEentity());
            //return employee;
            return _employeeRepository.Update(_mapper.Map<UpdateEmployeeDto, Employee>(employeeDto));
        }

        public bool DeleteEmployee(int id)
        {
            var employee = _employeeRepository.GetbyId(id);
            if (employee is null)
            {
                return false;
            }
            //softDelete
            employee.IsDeleted = true;
            var result= _employeeRepository.Update(employee);
            if (result > 0)
            {
                return true;
            }else return false;
        }
    }
}
