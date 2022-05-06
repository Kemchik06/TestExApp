using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TestExApp.Models;
using TestExApp.Repository;
using TestExApp.Repository.Implemetation;
using TestExApp.Services;
using TestExApp.Services.Implementation;

namespace TestExApp
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
            // получаем строку подключения из файла конфигурации
            string connection = Configuration.GetConnectionString("DefaultConnection");
            // добавляем контекст ApplicationContext в качестве сервиса в приложение
            services.AddDbContext<ApiContext>(options =>
                options.UseSqlServer(connection));

            services.AddControllers().AddNewtonsoftJson();

            services.AddTransient<IRepository, Repository<ApiContext>>();
            services.AddTransient<IItemService, ItemService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(builder => builder
             .AllowAnyOrigin()
             .AllowAnyMethod()
             .AllowAnyHeader());

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseDefaultFiles(); // <-- Это
            app.UseStaticFiles(); // <-- Вот этоs            
        }
    }
}
