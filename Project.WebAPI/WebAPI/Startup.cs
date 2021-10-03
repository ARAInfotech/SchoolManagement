#region NameSpace
using ConfigManager;
using ConfigManager.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebAPI.BLL;
using WebAPI.BLL.DI;
using WebAPI.BLL.Interface;
using WebAPI.BLL.Interface.Login;
using WebAPI.Helpers;
using WebAPI.Middleware;
#endregion

namespace WebAPI
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
            services.AddRepository();
            services.AddControllers(options => options.Filters.Add(new HttpResponseExceptionFilter()));
            services.AddTokenAuthentication(Configuration);
            services.AddSingleton<IConfigurationManager, WebConfigManager>();
            services.AddScoped<IWeatherForecast, WeatherForecastBLL>();
            services.AddScoped<ILoginBLL, LoginBLL>();
            services.AddSwaggerGen();
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
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "MyWebApi");
            });
        }
    }
}
