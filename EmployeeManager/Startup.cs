using System.Linq.Expressions;
using System.Security.Policy;
using EmployeeManager.Configs;
using EmployeeManager.Db;
using EmployeeManager.Repository;
using EmployeeManager.Services;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace EmployeeManager
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddDbContext<EmployeeManagerDbContext>(option =>
                option.UseSqlServer(Configuration.GetConnectionString("EmployeeManagerDb")));

            services.AddAutoMapper(typeof(AutomapperMaps));

            services.AddSingleton(provider =>
            {
                var validate = Configuration.GetValue<bool?>("Validate");
                return new ValidationConfig(validate ?? true);
            });

            services.AddScoped<IEmployeeService, EmployeeService>();

            services.AddScoped(typeof(IRepository<>), typeof(EFRepository<>));

            services.AddValidation(opt =>
            {
                opt.AutomaticValidationEnabled = true;
                opt.ImplicitlyValidateChildProperties = true;
                opt.RegisterValidatorsFromAssemblyContaining<Startup>();

            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Employee}/{action=Index}");
            });
        }
    }
}
