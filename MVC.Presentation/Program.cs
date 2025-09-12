using Microsoft.EntityFrameworkCore;
using MVC.Businesslogic.Services;
using MVC.DataAccess.Data.Context;
using MVC.DataAccess.Repositories;

namespace MVC.Presentation
{
    //notes
    //Architecture pattern have 2 types
    //1- layered architecture[mvc]
    //2- Onion architecture[api]
    //layered architecture have 3 layers
    //1- presentation layer[UI]  (mvc)
    //2- business logic layer[service]
    //3- data access layer[repository]
    // باخود reference من ال DAL احتوه فى ال BLL
    // وباخد ال BLL احوته فى ال PL
    // وال controller بيكلم Repository عن طريق ال services 
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<ApplicationDbContext>(options => 
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            // بخلى crl يعمل object من ال departmentservices
            builder.Services.AddScoped<IDepartmentServices, DepartmentServices>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
