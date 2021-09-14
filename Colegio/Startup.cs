using Colegio.Logica.Contratos;
using Colegio.Logica.Repositorios;
using Colegio.Models.Models;
using Colegio.Profiles;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Colegio
{
    public class Startup
    {

        readonly string MiCors = "MiCors"; //para que los servicios de elemento cruzado (tipo de acceso por cros cruzado)

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddCors(options =>
            {
                options.AddPolicy(name: MiCors,
                                  builder => {
                                      builder.WithHeaders("*"); //permite recibir cabeceras
                                      builder.WithOrigins("*"); //permite que los servicios sean llamado desde diferentes lugares (origen de datos)
                                      builder.WithMethods("*"); //permite metodo put y delete
                                  });


            });

            services.AddAutoMapper(typeof(ColegioProfile));
            services.AddDbContext<ColegioContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IAlumnoRepositorio, RepositorioAlumno>();
            services.AddScoped<IMateriaRepositorio, RepositorioMateria>();
            services.AddScoped<IProfesorRepositorio, RepositorioProfesor>();
            services.AddScoped<IMatriculaMateriaRepositorio, RepositorioMatriculaMateria>();
            services.AddScoped<IReporteCalificacionRepositorio, RepositorioReporteCalificacion>();
            services.AddScoped<IProfesorAsignaturaRepositorio, RepositorioProfesorAsignatura > ();
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseCors(MiCors); //permite que los servicios sean llamado desde diferentes lugares

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Alumnos}/{action=Index}/{id?}");
            });
        }
    }
}
