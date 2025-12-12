using Microsoft.EntityFrameworkCore;
using TE_assignment_2025.Dal;

namespace TE_assignment_2025
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();

            // Add services to the container.
            

            var connnection = builder.Configuration.GetConnectionString("TeAssignmentConStr");
            builder.Services.AddDbContext<TEAssignmentDBContext>(options => options.UseMySql(connnection, ServerVersion.AutoDetect(connnection)));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Projects}/{action=Index}/{id?}");

            

            app.Run();
        }
    }
}
