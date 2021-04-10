using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using NLayerProject.API.DTOs;
using NLayerProject.API.Extensions;
using NLayerProject.API.Filters;
using NLayerProject.Core.Repositories;
using NLayerProject.Core.Services;
using NLayerProject.Core.UnitOfWork;
using NLayerProject.Data;
using NLayerProject.Data.Repositories;
using NLayerProject.Data.UnitOfWorks;
using NLayerProject.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NLayerProject.API
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
            //dependency Injection
            services.AddScoped<NotFoundFilter>();
            services.AddAutoMapper(typeof(Startup));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IRepository<>),typeof(Repository<>));
            services.AddScoped(typeof(IService<>),typeof(Service.Services.Service<>));
            services.AddScoped<ICategoryService,CategoryService>();
            services.AddScoped<IProductService, ProductService>();


            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(Configuration["ConnectionStrings:Default"],o=> {
                    o.MigrationsAssembly("NLayerProject.Data");
                });
            });

            services.AddControllers();
            //custom error model

            //add global custom filter all controllers
            //services.AddControllers(o=> {
            //    o.Filters.Add(new ValidationFilter());
            //});
            services.Configure<ApiBehaviorOptions>(options => {

                options.SuppressModelStateInvalidFilter = true;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //extension
            app.UseCustomException();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
