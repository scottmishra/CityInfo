using CityInfo.DatabaseContexts;
using CityInfo.DAL;
using CityInfo.DAL.Interfaces;
using CityInfo.Services;
using CityInfo.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;
using NLog.Extensions.Logging;

namespace CityInfo
{
    public class Startup
    {
        // creating a static configuratoin manager object
        public static IConfigurationRoot ConfigurationRoot;

        public Startup(IHostingEnvironment environment)
        {
            // build up the configuration based on the needs of the project, using several extensions assemblies
            // We can add multiple configuration files, but have to remember that order isimportant
            var builder = new ConfigurationBuilder()
                .SetBasePath(environment.ContentRootPath)
                .AddJsonFile("appSettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appSettings.{environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables(); //allows env variables to be read like Conf file
            // Create the configuration root object
            ConfigurationRoot = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //Adding mvc to the service container
            services.AddMvc()
                .AddJsonOptions(o =>
                {
                    if (o.SerializerSettings.ContractResolver != null)
                    {
                        //Remove the name changing resolver in JSON, keep the DTO names
                        var castedResolver = o.SerializerSettings.ContractResolver as DefaultContractResolver;
                        castedResolver.NamingStrategy = null;
                    }
                });
            //Register a custom service
#if DEBUG
            services.AddTransient<IMailService, LocalMailService>();
#else
            services.AddTransient<IMailService,CloudMailService>();
#endif

            //Add the db context services
            var connectionString = ConfigurationRoot["connectionStrings:cityInfoConnectionString"];
            services.AddDbContext<CityInfoContext>(options => options.UseSqlServer(connectionString));
            services.AddScoped<ICityInfoRepository, CityInfoRepository>();
            services.AddScoped<CitiesDataStore>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory,
            CityInfoContext context)
        {
            loggerFactory.AddConsole();
            loggerFactory.AddDebug();
            //Extension method to help make nlog provider integration easier
            loggerFactory.AddNLog();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler();
            }
            context.EnsreSeedDataForContext();
            //Configuring the app to use MVC middleware to handle http request
            app.UseMvc();
            //Show simple status code pages
            app.UseStatusCodePages();
        }
    }
}