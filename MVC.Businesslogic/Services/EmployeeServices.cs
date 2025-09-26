using AutoMapper;
using MVC.Businesslogic.DataTransferObject.Employee;
using MVC.Businesslogic.Factories;
using MVC.Businesslogic.Services.Interface;
using MVC.DataAccess.model.Employees;
using MVC.DataAccess.Repositories.Employees;
using MVC.DataAccess.Repositories.UoW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Businesslogic.Services
{
    public class EmployeeServices : IEmployeeServices
    {
        //private readonly IEmployeeRepository _employeeRepository;
        private readonly IUnitOFWork _unitOFWork;
        private readonly IMapper _mapper;
        private readonly IAttachmentService _attachmentService;

        #region befor UoW
        //public EmployeeServices(IEmployeeRepository employeeRepository, IMapper mapper)
        //{
        //    _employeeRepository = employeeRepository;
        //    _mapper = mapper;
        //} 
        #endregion
        public EmployeeServices(IUnitOFWork unitOFWork,IMapper mapper,IAttachmentService attachmentService) 
        {
            _unitOFWork = unitOFWork;
            _mapper = mapper;
            _attachmentService = attachmentService;
        }

        public IEnumerable<EmployeeDto> GetAllEmp(string? EmployeeSearchName, bool withTracking = false)
        {
            IEnumerable<Employee> employees;
            if (string.IsNullOrEmpty(EmployeeSearchName))
            {
                employees = _unitOFWork.EmployeeRepository.GetAll(withTracking);
            }
            else
            {
                employees = _unitOFWork.EmployeeRepository.GetAll(E => E.Name.ToLower().Contains(EmployeeSearchName.ToLower()));
            }

            var empoyeesToReturn = _mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeDto>>(employees);
            return empoyeesToReturn;

            #region من غير جزء ال search bar
            //var employees = _employeeRepository.GetAll(withTracking);                      
            //var empoyeesToReturn = _mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeDto>>(employees);
            //return empoyeesToReturn;
            //var employees = _employeeRepository.GetAll(E=>new EmployeeDto
            //{
            //    Id = E.Id,
            //    Name = E.Name,
            //    Age = E.Age,
            //    Salary = E.Salary
            //}).Where(E => E.Age > 24);
            //return employees; 
            #endregion
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
            var employee = _unitOFWork.EmployeeRepository.GetbyId(id);
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
            if (employeeDto.Image is not null)
            {
                employee.ImageName=_attachmentService.Upload(employeeDto.Image, "Images");
            } 
            _unitOFWork.EmployeeRepository.Add(employee);
            return _unitOFWork.Savechanges();
        }

        public int UpdateEmployee(UpdateEmployeeDto employeeDto)
        {
            //var employee = _employeeRepository.Update(employeeDto.ToEentity());
            //return employee;

            _unitOFWork.EmployeeRepository.Update(_mapper.Map<UpdateEmployeeDto, Employee>(employeeDto));
            return _unitOFWork.Savechanges();

            #region مش شغال
            //var oldImgemployee = _unitOFWork.EmployeeRepository.GetbyId(employeeDto.Id);
            //var employee = _mapper.Map<UpdateEmployeeDto, Employee>(employeeDto);
            //if (employeeDto.Image is not null)
            //{
            //    if (!string.IsNullOrEmpty(oldImgemployee?.ImageName))
            //    {
            //        _attachmentService.Delete(oldImgemployee.ImageName);
            //    }
            //    employee.ImageName = _attachmentService.Upload(employeeDto.Image, "Images");
            //}
            //_unitOFWork.EmployeeRepository.Add(employee);
            //return _unitOFWork.Savechanges(); 
            #endregion
        }

        public bool DeleteEmployee(int id)
        {
            var employee = _unitOFWork.EmployeeRepository.GetbyId(id);
            if (employee is null)
            {
                return false;
            }
            //softDelete
            employee.IsDeleted = true;
             _unitOFWork.EmployeeRepository.Update(employee);
            var result = _unitOFWork.Savechanges();
            if (result > 0)
            {
                return true;
            }else return false;
        }
    }
}
