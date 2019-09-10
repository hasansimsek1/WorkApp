using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WorkApp.Common.Configurations;
using WorkApp.Service.Extensions;

namespace WorkApp.UI.AspNetCoreMvc
{
    /// <summary>
    /// Responsible for running configurations at the beginning of the application.
    /// </summary>
    public class Startup
    {
        private IConfiguration _config;

        public Startup(IConfiguration config)
        {
            _config = config;
        }

        /// <summary>
        /// This method gets called by the runtime. 
        /// Use this method to add services to the container. 
        /// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        /// </summary>
        /// <param name="services">Collection of the services that will be added to the dependency injection container.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AutoMapperMappings));

            AuthorizationPolicy authPolicy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
            AuthorizeFilter authFilter = new AuthorizeFilter(authPolicy);
            services.AddMvc(config => config.Filters.Add(authFilter)).AddXmlSerializerFormatters();

            services.AddAppServices(_config);
        }

        /// <summary>
        /// This method gets called by the runtime. 
        /// Use this method to configure the HTTP request pipeline.
        /// </summary>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("Error");
                app.UseStatusCodePagesWithReExecute("/Error/{0}");
            }

            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseMvcWithDefaultRoute();

            /*
            app.Run(async (context) =>
            {
                await context.Response
                .WriteAsync(@"<h1>This is the end of the app!</h1> <br />  
                            <h2>How did you come here we don't know but you can open an issue on github from <a href=""https://github.com/hasansimsek1/WorkApp/issues""> here </a> </h2> <br /> 
                            <h2>Or, you can continue with the <a href=""/Home/Index/""> main page </a> </h2>");
            });
            */
        }
    }
}
