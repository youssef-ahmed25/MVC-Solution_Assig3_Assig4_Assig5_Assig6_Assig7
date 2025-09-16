using MVC.Businesslogic.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Businesslogic.Services.Interface
{
    public interface IEmployeeServices
    {
        IEnumerable<EmployeeDto>GetAllEmp(bool trackChanges=false);
        
        EmployeeDetailsDto? GetEmployeeById(int id);
        int CreateEmployee(CreateEmployeeDto employeeDto);
        int UpdateEmployee(UpdateEmployeeDto employeeDto);
        
    }
}
