using AutoMapper;
using MVC.Businesslogic.DataTransferObject.Employee;
using MVC.DataAccess.model.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Businesslogic.Profiles
{
    public class MappingProfile:Profile
    {
        #region Assig5
        public MappingProfile()
        {
            CreateMap<Employee, EmployeeDto>()
                .ForMember(dist => dist.EmpGender, options => options.MapFrom(src => src.Gender))
                .ForMember(dist => dist.EmpType, options => options.MapFrom(src => src.EmployeeType));
            //يقدر من خلالها يعمل عكس التحويله
            //.ReverseMap();

            CreateMap<Employee, EmployeeDetailsDto>()
                .ForMember(dist => dist.Gender, options => options.MapFrom(src => src.Gender))
                .ForMember(dist => dist.EmployeeType, options => options.MapFrom(src => src.EmployeeType))
                .ForMember(dist => dist.HiringDate, options => options.MapFrom(src => DateOnly.FromDateTime(src.HiringDate)));
            //.ReverseMap();

            CreateMap<CreateEmployeeDto, Employee>()
                .ForMember(dist => dist.HiringDate, options => options.MapFrom(src => src.HiringDate.ToDateTime(new TimeOnly())));
            //.ReverseMap();
            CreateMap<UpdateEmployeeDto, Employee>()
                .ForMember(dist => dist.HiringDate, options => options.MapFrom(src => src.HiringDate.ToDateTime(new TimeOnly())));
                //.ReverseMap();
        } 
        #endregion
    }
}
