using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using UtilityInspect.FieldOrderService.Data;
using UtilityInspect.FieldOrderService.Repositories;

namespace UtilityInspect.FieldOrderService
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

            services.AddControllers();

            services.AddSingleton<IFieldOrderRepository, FieldOrderRepository>();

            services.Configure<FieldOrderDatabaseSettings>(Configuration.GetSection(nameof(FieldOrderDatabaseSettings)));

            services.AddSingleton<IFieldOrderDatabaseSettings>(sp => sp.GetRequiredService<IOptions<FieldOrderDatabaseSettings>>().Value);

            services.AddSingleton<IFieldOrderDbContext, FieldOrderDbContext>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "UtilityInspect.FieldOrderService", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "UtilityInspect.FieldOrderService v1"));
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
