using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;
using System.Reflection;
using System.IO;
using MediatR;
using ElementIoT.Particle.Infrastructure.Model.Messaging;
using ElementIoT.Particle.Infrastructure.Model.Handling;
using ElementIoT.Particle.Infrastructure.Processor.MediatR;
using ElementIoT.Silicon.Service.Command;
using ElementIoT.Particle.Operational.Logging;
using ElementIoT.Particle.Operational.Error;
using ElementIoT.Silicon.Handler.Command;
using ElementIoT.Silicon.Handler.Event;
using CRepository = ElementIoT.Silicon.Repository.Command;
using QRepository = ElementIoT.Silicon.Repository.Query;

using IoTCProvider = ElementIoT.Silicon.DataProvider.IoTHubProvider.Command;

using SqlCProvider = ElementIoT.Silicon.DataProvider.SqlProvider.Command;
using SqlQProvider = ElementIoT.Silicon.DataProvider.SqlProvider.Query;

using CacheQProvider = ElementIoT.Silicon.DataProvider.CacheProvider.Query;
using ElementIoT.Particle.Operational.Caching;
using Microsoft.IdentityModel.Tokens;
using ElementIoT.Particle.Infrastructure.Api;

namespace ElementIoT.Silicon.Api.Gateway
{
    /// <summary>
    /// 
    /// </summary>
    public class Startup: ApiStartup
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Startup"/> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        public Startup(IConfiguration configuration) :
            base(configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Gets the configuration.
        /// </summary>
        /// <value>
        /// The configuration.
        /// </value>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// Configures the services.
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services">The services.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            base.ConfigureAuthenticationServices(services);

            services.AddMvc();

            base.ConfigureSwaggerServices(services);

            // Core Services
            services.AddLogging();
            services.AddSingleton<IConfiguration>(Configuration);

            // Operational
            services.AddSingleton<ILogPolicy, DevLogPolicy>();
            services.AddSingleton<IErrorPolicy, ApiErrorPolicy>();
            services.AddSingleton<ICachePolicy, MemoryCachePolicy>();

            // Data Providers
            services.AddScoped<IoTCProvider.IDeviceCommandDataProvider, IoTCProvider.DeviceDataProvider>();
            services.AddScoped<SqlCProvider.IDeviceCommandDataProvider, SqlCProvider.DeviceDataProvider>();
            services.AddScoped<SqlQProvider.IDeviceQueryDataProvider, SqlQProvider.DeviceDataProvider>();
            services.AddScoped<CacheQProvider.IDeviceQueryDataProvider, CacheQProvider.DeviceDataProvider>();


            // Repositories
            services.AddScoped<CRepository.IDeviceRepository, CRepository.DeviceRepository>();
            services.AddScoped<QRepository.IDeviceRepository, QRepository.DeviceRepository>();

            // Domain Services
            services.AddScoped<IDeviceService, DeviceService>();

            // Command and Event Handlers

            services.AddMediatR(typeof(CommandHandler<ICommand>).Assembly);
            services.AddMediatR(typeof(SiliconCommandHandler).Assembly);
            services.AddMediatR(typeof(SiliconEventHandler).Assembly);

            // Command and Event Buses
            services.AddScoped<ICommandBus, MediatRCommandBus>();
            services.AddScoped<IEventBus, MediatREventBus>();
        }

        /// <summary>
        /// Configures the specified application.
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app">The application.</param>
        /// <param name="env">The env.</param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();

            base.ConfigureSwaggerApp(app, env);

            app.UseMvc();
        }
    }
}
