using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using ProdavnicaNaocara.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using ProdavnicaNaocara.Data.Repositories;
using Microsoft.Extensions.Options;

namespace ProdavnicaNaocara.Api
{
    public class Startup
    {
        public static IConfigurationRoot Configuration { get; set; }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(Configuration);

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });

            services.AddDbContext<ProdavnicaNaocaraDbContext>(o => o.UseSqlServer(Configuration.GetConnectionString("prodavnicaDb")));

            services.AddScoped<ProizvodiRepository>();
            services.AddScoped<ProizvodjaciRepository>();
            services.AddScoped<CenaRepository>();
            services.AddScoped<KatalogRepository>();
            services.AddScoped<StavkaKatalogaRepository>();
            services.AddScoped<MestoRepository>();
            services.AddScoped<UlicaRepostitory>();
            services.AddScoped<AdresaRepository>();
            services.AddScoped<ZaposleniRepository>();
            services.AddScoped<KupacRepository>();
            services.AddScoped<ZahtevZaPonudomRepository>();
            services.AddScoped<PonudaRepository>();
            services.AddScoped<StavkaPonudeRepository>();

            services.AddMvc()
                    .AddJsonOptions(options =>
                    {
                        options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                        options.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;
                        options.SerializerSettings.Converters.Add(new StringEnumConverter());
                    }); ;
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseStatusCodePages();

            app.UseDeveloperExceptionPage();

            app.UseCors("CorsPolicy");

            app.UseMvc();
        }
    }
}
