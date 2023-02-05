using CourseManagement.Extensions;
using Microsoft.EntityFrameworkCore;
using NLog;

namespace CourseManagement
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.ConfigureAppServices(connectionString);

            var app = builder.Build();
            app.ConfigureMiddleware();
            app.MigrateDatabase().Run();
        }
    }
}