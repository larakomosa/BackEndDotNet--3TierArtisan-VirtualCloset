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
using Microsoft.EntityFrameworkCore;
using VirtualClosetAPI.Models;
using VirtualClosetAPI.Controllers;
using VirtualClosetAPI.Biz.Impl;
using VirtualClosetAPI.Data;
using VirtualClosetAPI.Data.Impl;
using VirtualClosetAPI.Controllers.Builders;
using VirtualClosetAPI.Controllers.Contracts;
using VirtualClosetAPI.Biz.Models;
using Artisan.Service.Core.Web;
using Artisan.Core.Bootstrap.StructureMap;
using System.ComponentModel;
using VirtualClosetAPI.Bootstrap;
using StructureMap;
using Container = StructureMap.Container;
using CommonServiceLocator;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using IVirtualClosetDao = VirtualClosetAPI.Data.IVirtualClosetDao;

namespace VirtualClosetAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }



        public IConfiguration Configuration { get; }


        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {

            services.AddTransient<IMessageBuilder<VirtualCloset, VirtualClosetResponse>, VirtualClosetResponseBuilder>();
            services.AddTransient<IVirtualClosetDao, VirtualClosetDao>();
            services.AddTransient<ICategoryManager, CategoryManager>();
            services.AddTransient<IVirtualClosetManager, VirtualClosetManager>();
            services.AddDbContext<VirtualClosetContext>(opt =>
            {
                opt.UseSqlServer(Configuration.GetConnectionString("VirtualClosetDb"));
            });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            var container = new Container();
            container.Configure(config =>
            {
                config.Populate(services);
                config.For<IServiceLocator>().Singleton().Use(new StructureMapServiceLocator(container));
            });

            var registrar = new StructureMapRegistrar(container);

            registrar.Register<BaseRegistry>();

            return new StructureMapServiceProvider(container);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseMvc();
        }
    }
}
