using Microsoft.EntityFrameworkCore;
using MVC.DataAccess.model.Departments;
using MVC.DataAccess.model.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MVC.DataAccess.Data.Context
{
    public class ApplicationDbContext:DbContext
    {
        public DbSet<model.Departments.Employee> Departments { get; set; }
        public DbSet <model.Employees.Employee> Employees { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }


        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("ConnectionString");
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }
}
