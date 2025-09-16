using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC.DataAccess.model.Departments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.DataAccess.Data.Configration
{
    internal class DepartmentConfig : BaseEntityConfigurations<Employee>,IEntityTypeConfiguration<Employee>
    {
        public new void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(d=>d.Id).UseIdentityColumn(10,10);
            builder.Property(d => d.Name).HasColumnType("varchar(100)");
            builder.Property(d => d.Code).HasColumnType("varchar(50)");
            builder.Property(d => d.Description).HasColumnType("varchar(100)");
            base.Configure(builder);

        }
    }
}
