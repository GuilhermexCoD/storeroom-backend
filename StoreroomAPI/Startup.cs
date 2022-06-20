using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Storeroom.Application.Services;
using Storeroom.Application.Services.Interfaces;
using Storeroom.Domain.Models;
using Storeroom.Persistence.Context;
using Storeroom.Persistence.Interfaces;
using Storeroom.Persistence.Repository;
using Storeroom.Application.Helpers;
using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StoreroomAPI
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
            string connectionString = Configuration.GetConnectionString("MySqlConnection");

            services.AddDbContext<StoreroomContext>(
                context => {
                    context.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
                }
            );

            services.AddCors();
            services.AddControllers()
                    .AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = 
                        Newtonsoft.Json.ReferenceLoopHandling.Ignore
                    );

            services.AddAutoMapper(typeof(StoreroomProfile));        

            ConfigureDepencencies(services);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "StoreroomAPI", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "StoreroomAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors( policy => policy.AllowAnyHeader()
                                        .AllowAnyMethod()
                                        .AllowAnyOrigin()
            
            );

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    
        private void ConfigureDepencencies(IServiceCollection services){

            //Services
            services.AddScoped<IService<EntityBase>,Service<EntityBase,EntityBase>>();
            services.AddScoped<IProductService,ProductService>();
            services.AddScoped<IProductPropService,ProductPropService>();
            services.AddScoped<IProductStatusService,ProductStatusService>();
            services.AddScoped<IFamilyService,FamilyService>();
            services.AddScoped<IUserService,UserService>();

            //Repositories
            services.AddScoped<IRepository<EntityBase>,RepositoryBase<EntityBase>>();
            services.AddScoped<IProductRepository,ProductRepository>();
            services.AddScoped<IProductPropRepository,ProductPropRepository>();
            services.AddScoped<IProductStatusRepository,ProductStatusRepository>();
            services.AddScoped<IFamilyRepository,FamilyRepository>();
            services.AddScoped<IUserRepository,UserRepository>();
        }
    }
}
