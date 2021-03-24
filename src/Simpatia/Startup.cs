
using System;
using System.Reflection;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Simpatia.Data.repositories;
using Simpatia.Domain.interfaces;

namespace Simpatia
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
            var assembly = AppDomain.CurrentDomain.Load("Simpatia.Domain");
            services.AddMediatR(assembly);
            services.AddSingleton(Configuration);
            services.AddSingleton<Data.MongoDB>();
            AddRepositoriesServices(services);
            services.AddMediatR(typeof(Startup).GetTypeInfo().Assembly);
        }
        private static void AddRepositoriesServices(IServiceCollection services)
        {
            services.AddScoped<IAdocaoRepository, AdocaoRepository>();
            services.AddScoped<IEmpregoRepository, EmpregoRepository>();
            services.AddScoped<IRestaurantesRepository, RestaurantesRepository>();
            services.AddScoped<INoticiasRepository, NoticiasRepository>();
            services.AddScoped<IEventosRepository, EventosRepository>();

        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
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
