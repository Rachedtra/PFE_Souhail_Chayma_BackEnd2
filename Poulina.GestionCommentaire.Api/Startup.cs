using System;
using System.Reflection;
using AutoMapper;
using GestionCommentaire.Infra.Ioc;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Polly;
using Poulina.GestionCommentaire.Data.Context;
using Swashbuckle.AspNetCore.Swagger;

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
            services.AddControllers();

            services.AddRazorPages(); 
            services.AddDbContext<GestionCommContext>(opt =>
              opt.UseSqlServer(Configuration.GetConnectionString("premiereappdb")));
            services.AddMediatR(typeof(Startup));
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddAutoMapper(typeof(Startup));
            services.AddHttpClient("User", client =>
            {
                client.BaseAddress = new Uri("http://localhost:50581/api/");

            })
                .AddTransientHttpErrorPolicy(x =>
                    x.WaitAndRetryAsync(3, _ => TimeSpan.FromMilliseconds(300)));
            services.AddRazorPages(); 
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Gestion Comm",
                    Description = " Web API",

                });

            });
            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin());
            });

            RegisterService(services);
            //services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
        }
        private void RegisterService(IServiceCollection services)
        {
            DependencyContrainer.RegisterServices(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API1 V1");
            });
            app.UseCors(options =>
          options.WithOrigins("http://localhost:4200")
           .AllowAnyMethod()
           .SetIsOriginAllowed((host) => true)
           .AllowCredentials()
           .AllowAnyHeader());
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            }); 
        }
    }
}
