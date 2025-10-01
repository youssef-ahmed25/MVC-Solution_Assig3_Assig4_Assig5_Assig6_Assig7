using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MVC.Businesslogic.Profiles;
using MVC.Businesslogic.Services;
using MVC.Businesslogic.Services.Interface;
using MVC.DataAccess.Data.Context;
using MVC.DataAccess.model.IdentityModels;
using MVC.DataAccess.Repositories.Departments;
using MVC.DataAccess.Repositories.Employees;
using MVC.DataAccess.Repositories.UoW;

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


    //clite side validation بيعمل ال فاليديت فى السايت قبل ميبعت للسرفر
    //server side validation بيعمل الفاليديت فى السرفر بعد ميبعت الداتا من الكلاينت
    //IQueryable بترجع اللى انا طلبته عند الداتا بيس مش memory
    //IEnumerable بترجع كل حاجه فى ال memory

    #region Notes_6
    //PartialView بنعمل عشان نحت فيه الاكواد المتشابه
    //ViewData and ViewBag بتبعت داتا من ال controller لل view
    //ViewData بتستخدم dictionary
    //ViewBag بتستخدم dynamic 
    //ViewData بتحتاج casting عشان تستخدمها
    //بستخدم ViewData و ViewBag , request عشان اباث داتا من مكان للتانى على نفس ال 
    // tempdata ,  عشان اباث داتا من مكان للتانى request مختلف
    #endregion
    #region notes_7
    //unit of work بتستخدم عشان تجمع اكتر من ريبوزيتورى فى حاجه واحده على single transaction بس وبقلل من عدد الريكويست الى الداتا بيس
    #endregion
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews(option =>
            {
                option.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
            });

            builder.Services.AddDbContext<ApplicationDbContext>(options => 
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
                options.UseLazyLoadingProxies();
            });

            builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            // بخلى crl يعمل object من ال departmentservices
            builder.Services.AddScoped<IDepartmentServices, DepartmentServices>();

            #region Assig5
            builder.Services.AddScoped<IEmployeeRepository,EmployeeRepository>();
            builder.Services.AddScoped<IEmployeeServices, EmployeeServices>();
            builder.Services.AddAutoMapper(M => M.AddProfile(new MappingProfile()));
            #endregion
            #region Assig7
            builder.Services.AddScoped<IUnitOFWork, UnitOfWork>();
            builder.Services.AddScoped<IAttachmentService, AttachmentService>();
            #endregion
            #region Assig8
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(option =>
            {
                option.Password.RequiredLength = 6;
                option.Password.RequireLowercase = true;
                option.Password.RequireUppercase = true;
                option.Password.RequireNonAlphanumeric = true;
                option.Password.RequireDigit = true;
                option.Password.RequiredUniqueChars = 3;

                option.User.RequireUniqueEmail = true;

                option.Lockout.AllowedForNewUsers = true;
                option.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(2);
                option.Lockout.MaxFailedAccessAttempts = 5;

            }).AddEntityFrameworkStores<ApplicationDbContext>()
               .AddDefaultTokenProviders();
            #endregion
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

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Account}/{action=LogIn}/{id?}");

            app.Run();
        }
    }
}
