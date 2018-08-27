using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using WebApiMongoDb.DaoImpl;
using WebApiMongoDb.Data;
using WebApiMongoDb.DAO;

namespace WebApiMongoDb
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
          

            services.AddMvc();

            //IoC start
            var builders = new ContainerBuilder();
            builders.Populate(services);
            
            builders.RegisterType<DataContext>().SingleInstance();
            builders.RegisterType<ProductDaoImpl>().As<IProductDao>().SingleInstance();
           

            var container = builders.Build();
            return new AutofacServiceProvider(container);
            //IoC end
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
