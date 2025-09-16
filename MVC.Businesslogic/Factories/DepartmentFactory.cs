using MVC.Businesslogic.DataTransferObject.Department;
using MVC.DataAccess.model.Departments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Businesslogic.Factories
{
    public static class DepartmentFactory
    {
        public static DepartmentDetailsDto toDepartmentDetailsDto(this Department department)
        {
            return new DepartmentDetailsDto()
            {
                Id = department.Id,
                Name = department.Name,
                Description = department.Description,
                Code = department.Code,
                CreatedBy = department.CreatedBy,
                DateofCreation = DateOnly.FromDateTime(department.CreatedOn ?? DateTime.Now),
                LastModifiedBy = department.LastModifiedBy,
                IsDeleted = department.IsDeleted
            };
        }
        public static DepartmentDto toDepartmentDto(this Department department)
        {
            return new DepartmentDto()
            {
                Id = department.Id,
                Name = department.Name,
                Description = department.Description,
                Code = department.Code,
                DateofCreation = DateOnly.FromDateTime(department.CreatedOn ?? DateTime.Now)
            };
        }
        //بتحول ل entity تسمى ToEntity
        public static Department ToEentity(this CreateDepartmindDto departmindDto)
        {
            return new Department()
            {
                Name = departmindDto.Name,
                Description = departmindDto.Description,
                Code = departmindDto.Code,
                CreatedOn = departmindDto.DateofCreation.ToDateTime(new TimeOnly())
            };
        }
        public static Department ToEentity(this UpdatedDepartmentDto departmindDto)
        {
            return new Department()
            {
                Id = departmindDto.Id,
                Name = departmindDto.Name,
                Description = departmindDto.Description,
                Code = departmindDto.Code,
                CreatedOn = departmindDto.DateofCreation.ToDateTime(new TimeOnly())
            };
        }
    }
}
