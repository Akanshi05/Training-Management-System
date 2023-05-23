using Microsoft.EntityFrameworkCore;
using MVC_Assignment.Context;
using MVC_Assignment.Repository;

namespace MVC_Assignment
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<TrainingDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("TrainingDbConnection"));

            });

            builder.Services.AddTransient<IUserInterface,UserRepository>();
            builder.Services.AddTransient<IRequestInterface, RequestRepository>();
            builder.Services.AddTransient<IBatchInterface, BatchRepository>();
            builder.Services.AddTransient<ICourseInterface, CourseRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
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