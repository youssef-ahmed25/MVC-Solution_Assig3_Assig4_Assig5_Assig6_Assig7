using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Businesslogic.DataTransferObject.Department
{
    public class DepartmentDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; }=string.Empty;
        public string Code { get; set; } = null!;

        public DateOnly DateofCreation { get; set; }
    }
}
