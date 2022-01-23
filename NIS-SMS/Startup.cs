using Day2.Models;
using Day2.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Day1
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            #region Built in Services [created by framework and called by user]
            //Register AutoMapper Service
            services.AddAutoMapper(typeof(Startup));

            //Register Session Service
            services.AddSession(s =>
            {
                s.IdleTimeout = TimeSpan.FromMinutes(3);
            });

            //Register conection string
            services.AddDbContext<DbEntities>(
                options=>options.UseSqlServer("Data Source=.;Initial Catalog=ITI_DB;Integrated Security=True"));

            #endregion

            #region Custom Services [created and called by user] 
            //Register Dependency injection Services
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<IInstructorRepository, InstructorRepository>();
            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped<ICrsResultRepository, CrsResultRepository>();

            #endregion

            //Framwork service [created and called by framework]
            services.AddControllersWithViews();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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

            //Register Session MiddleWare
            app.UseSession();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
