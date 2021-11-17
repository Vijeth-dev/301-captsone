using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using CustomerManagemenrSystem.Service.Business;
using CustomerManagement.Repo;
using CustomerManagement.Service.Abstractions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace CustomerManagement.Api
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
            services.AddMvc();
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
            

            /*Registering connection string*/
           // services.Configure<ApplicationString>(Configuration.GetSection("ApplicationString"));
            services.AddMvc()
                  .AddMvcOptions(options =>
                  {
                      //options.Filters.Add(new Authorization());
                        //options.Filters.Add(new LoggingFilter(Configuration["ApplicationString:DB"]));
                        //options.Filters.Add(new ErrorHandlingFilter(Configuration["ApplicationString:DB"]));
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

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
