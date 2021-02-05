using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using UtilityInspect.EmployeeService.Data;
using UtilityInspect.EmployeeService.Repositories;

namespace UtilityInspect.EmployeeService
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
           
            services.Configure<EmployeeDatabaseSettings>(Configuration.GetSection(nameof(EmployeeDatabaseSettings)));

            services.AddSingleton<IEmployeeDatabaseSettings>(sp => sp.GetRequiredService<IOptions<EmployeeDatabaseSettings>>().Value);

            services.AddSingleton<IEmployeeDbContext, EmployeeDbContext>();

            services.AddSingleton<IEmployeeRepository, EmployeeRepository>();

            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "UtilityInspect.EmployeeService", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "UtilityInspect.EmployeeService v1"));
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
