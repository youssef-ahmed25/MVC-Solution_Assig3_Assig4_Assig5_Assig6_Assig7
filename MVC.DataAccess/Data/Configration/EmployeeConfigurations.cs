using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC.DataAccess.model.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.DataAccess.Data.Configration
{
    internal class EmployeeConfigurations : BaseEntityConfigurations<Employee>, IEntityTypeConfiguration<Employee>
    {
        public new void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(e => e.Name).HasColumnType("nvarchar(50)");
            builder.Property(e => e.Salary).HasColumnType("decimal(10,2)");

            builder.Property(e => e.Gender)
                .HasConversion((gender)=>gender.ToString(),
                (toGender)=>(Gender) Enum.Parse(typeof(Gender), toGender));

            builder.Property(e => e.EmployeeType)
                .HasConversion((EmpType) => EmpType.ToString(),
                (toEmpType) => (EmployeeType)Enum.Parse(typeof(EmployeeType), toEmpType));

            base.Configure(builder);
        }
    }
}
