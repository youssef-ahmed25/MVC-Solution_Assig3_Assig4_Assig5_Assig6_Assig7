using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Businesslogic.DataTransferObject.Department
{
    public class CreateDepartmindDto
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = string.Empty;

        [Range(10,int.MaxValue, ErrorMessage = "Code must be at least 10 characters long.")]
        public string Code { get; set; } = null!;

        public DateOnly DateofCreation { get; set; }
    }
}
