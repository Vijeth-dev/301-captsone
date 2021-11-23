using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using CustomerManagemenrSystem.Service.Business;
using CustomerManagement.Repo;
using CustomerManagement.Repo.Entities.Context;
using CustomerManagement.Service.Abstractions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Swagger;

namespace CustomerManagement.Api
{
    public class Startup
    {
        private static string _applicationPath = string.Empty;
        private static string _contentRootPath = string.Empty;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public Startup(IHostingEnvironment env)
        {
            _applicationPath = env.WebRootPath;
            _contentRootPath = env.ContentRootPath;
            // Setup configuration sources.

            var builder = new ConfigurationBuilder()
                .SetBasePath(_contentRootPath)
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);
            if (env.IsDevelopment())
            {
                // This reads the configuration keys from the secret store.
                // For more details on using the user secret store see http://go.microsoft.com/fwlink/?LinkID=532709
                // builder.AddUserSecrets();
            }
            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddControllers();
            //Auto Mapper Configurations
            var mappingConfig = new MapperConfiguration(mc =>
            {
               // mc.AddProfile(new MapperHelper());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            /*DI*/
            /*DI*/
            services.AddTransient<ICustomerService, CustomerService>();
            services.AddTransient<ICustomerManagementRepo, CustomerManagementRepo>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CustomerManager", Version = "v1" });
            });
            services.AddDbContext<CustomerManagementContext>(options =>

                options.UseSqlServer("Data Source=VSSqlKibana\\SQLEXPRESS;Initial Catalog=CustomerManagement;Integrated Security=True",
                b => b.MigrationsAssembly("CustomerManagement.Repo"))
            );
            /*Registering connection string*/
            // services.Configure<ApplicationString>(Configuration.GetSection("ApplicationString"));
            services.AddMvc()
                  .AddMvcOptions(options =>
                  {
                      options.EnableEndpointRouting = false;
                        options.MaxModelValidationErrors = 50;
                      options.ModelBindingMessageProvider.SetValueMustNotBeNullAccessor(
                          (_) => "The field is required.");
                  });

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
                app.UseHsts();
            }
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "CustomerManager v1");
            });
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
