using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using worthWatchingAPI.Connectors;
using worthWatchingAPI.Mapping;
using worthWatchingAPI.Orchestrators;

namespace worthWatchingAPI
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddOrchestrations(Configuration);
            services.AddMapper();
            services.AddConverter();
            services.AddHttpClient<IOMDBConnector, OMDBConnector>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }

    internal static class serviceExtensions
    {
        public static IServiceCollection AddOrchestrations(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddScoped(typeof(MovieOrchestrator));
            return serviceCollection;
        }

        public static IServiceCollection AddMapper(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped(typeof(MovieMapper));
            return serviceCollection;
        }
        
        public static IServiceCollection AddConverter(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped(typeof(MovieConverter));
            return serviceCollection;
        }
    }
}
