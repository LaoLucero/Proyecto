using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Proyecto.Models;


namespace Proyecto
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // Este m�todo es llamado por el tiempo de ejecuci�n. Utilice este m�todo para agregar servicios al contenedor.
        public void ConfigureServices(IServiceCollection services)
        {
 
            services.AddControllers();

            services.AddDbContext<Service>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))); //CADENA LAMDA

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Proyecto", Version = "v1" });
            });
        }

        // Este m�todo es llamado por el tiempo de ejecuci�n. Utilice este m�todo para configurar la canalizaci�n de solicitudes HTTP.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Proyecto v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
