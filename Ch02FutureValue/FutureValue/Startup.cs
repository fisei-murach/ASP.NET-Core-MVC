using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FutureValue
{
    // NOTA: Archivo comentado.
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
            // Activa los servicios requeridos por los controladores y 
            // las vistas Razor de una app MVC
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // El siguiente codigo configura los servicios que la app esta
            // usando.

            // Para comenzar, este código verifica si el entorno de alojamiento web 
            // es un entorno de desarrollo
            if (env.IsDevelopment())
            {
                // Si es así, el middleware maneja las excepciones al mostrar una 
                // página web diseñada para desarrolladores, no para usuarios finales.
                // Por lo general, eso es lo que desea cuando se encuentra en un entorno de desarrollo
                
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // Caso contrario, si implementa la aplicación en un entorno de producción, 
                // el middleware maneja las excepciones al mostrar una página que el 
                // desarrollador personaliza para los usuarios finales. 
                // Eso suele ser lo que quiere para un entorno de producción.
                app.UseExceptionHandler("/Home/Error");


                // HTTP con Seguridad de Transporte Estricta (HSTS)
                // Además, este código llama al método UseHsts() para configurar el middleware 
                // para enviar encabezados HTTP Strict Transport Security(HSTS) a los clientes, 
                // lo cual es una práctica recomendada para las aplicaciones de producción.

                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            // Middlewares
            // Las siguientes cuatro instrucciones configuran los componentes de middleware 
            // que son los mismos para entornos de desarrollo y producción.

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            // Es importante tener en cuenta que el método UseEndpoints () 
            // en este se establece como el controlador predeterminado 
            // para la aplicación el controlador "Home", y establece como 
            // acción predeterminada la acción Index(). Como resultado, cuando se 
            // inicia la aplicación, se llama al método de acción Index()
            // del controlador "Home". Esto hace que se muestre la vista "Index", que
            // generalmente es lo que se desea.
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
