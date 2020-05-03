using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using GestionCommentaire.Infra.Ioc;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Poulina.GestionCommentaire.Data.Context;


namespace Poulina.GestionCommentaire.Api
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
            services.AddDbContext<GestionCommContext>(opt =>
              opt.UseSqlServer(Configuration.GetConnectionString("premiereappdb")));
            services.AddMediatR(typeof(Startup));
            services.AddMediatR(Assembly.GetExecutingAssembly());
            RegisterService(services);
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }
        private void RegisterService(IServiceCollection services)
        {
            DependencyContrainer.RegisterServices(services);
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
