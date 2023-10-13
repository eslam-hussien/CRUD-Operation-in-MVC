using lab2.BLL;
using lab2.Data;
using Microsoft.EntityFrameworkCore;

namespace lab2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
			builder.Services.AddDbContext<StudentDb>(a =>
			{
				a.UseSqlServer("Server=DESKTOP-3FTMPVV\\SQL0;Database=Back2school;Trusted_Connection=True;TrustServerCertificate=true");
			});
            builder.Services.AddScoped<IStudentBLL,StudentBLL>();
            builder.Services.AddScoped<IDepartmentBll,DepartmentBLL>();

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