using projectF.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
namespace projectF
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
			builder.Services.AddDbContext<ApplicationDBcontext>(Options =>
			{
				Options.UseSqlServer(builder.Configuration.GetConnectionString("myConnection"));
			});

            builder.Services.AddSession(
options => {
options.IdleTimeout = TimeSpan.FromDays(1);
options.Cookie.HttpOnly = true;
options.Cookie.IsEssential = true;
}

);

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
                pattern: "{controller=Welcome}/{action=Index}/{id?}");
            app.UseSession();
            app.Run();
        }
    }
}