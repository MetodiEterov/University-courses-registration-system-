using DomainLayer.Contracts;
using DomainLayer.Entities;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGeneration.Design;

using RepositoryLayer.ApplicationContext;
using RepositoryLayer.RepositoryClasses;

using ServiceLayer.Services;

namespace CourseManagement.Extensions
{
    public static class ServiceConfiguration
    {
        public static void ConfigureAppServices(this IServiceCollection services, string connectionString)
        {
            services.AddControllersWithViews();
            services.AddDbContext<RepositoryContext>(options =>
                options.UseSqlServer(connectionString, b => b.MigrationsAssembly("CourseManagement")));
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<IStudentCourseRepository, StudentCourseRepository>();
            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped<IRepositoryManager, RepositoryManager>();
            services.AddScoped<IServiceManager, ServiceManager>();
            services.AddSingleton<ILoggingService, LoggingService.LoggingManagement.LoggingService>();
            services.AddIdentity<User, IdentityRole>(options =>
            {
                options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+/ ";
                options.Password.RequiredLength = 3;
                options.Password.RequireDigit = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
            })
            .AddEntityFrameworkStores<RepositoryContext>();
            services.AddAutoMapper(typeof(Program));
            services.AddCors(p => p.AddPolicy("corsapp", builder =>
            {
                builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
            }));
        }
    }
}
