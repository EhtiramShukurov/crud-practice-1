
using BizLandTask.DAL;
using Microsoft.EntityFrameworkCore;

namespace BizLandTask
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<AppDbContext>(opt =>
            {
                opt.UseSqlServer(builder.Configuration.GetConnectionString("MSSQL"));
            });
            var app = builder.Build();
            app.UseStaticFiles();
            app.UseRouting();
            app.MapControllerRoute("areas","{area:exists}/{controller=Dashboard}/{action=Index}/{id?}");
            app.MapControllerRoute("default","{controller=home}/{action=index}");
            app.Run();
        }
    }
}