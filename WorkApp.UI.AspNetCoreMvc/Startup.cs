using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WorkApp.Common.Entities;
using WorkApp.DataAccess.SqlServer;
using WorkApp.Respository.Interfaces;
using WorkApp.Respository.Repositories;
using WorkApp.Service.Interfaces;
using WorkApp.Service.Services;

namespace WorkApp.UI.AspNetCoreMvc
{
    /// <summary>
    /// Class that is responsible for running user configurations on the beginning of the application.
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
            /*
             * TODO:
             *      Organize the codes in this method for readability.
             *      Services can be gathered from lower layers. but it's ok for now.
             */
             
            
            services.AddDbContextPool<AppDbContext>(options => options.UseSqlServer(_config.GetConnectionString("default")));

            services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>();

            // this options can be passed to the AddIdentity method above.
            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequiredLength = 10;
            });
            
            // this policy setting allows anonymous actions in controllers that use Authorize attribute
            AuthorizationPolicy authPolicy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
            AuthorizeFilter authFilter = new AuthorizeFilter(authPolicy);

            // add mvc to dependencies
            services.AddMvc(config => config.Filters.Add(authFilter)).AddXmlSerializerFormatters();

            // AddScoped creates one instance for one http request (uses the same instance on the same http request)
            services.AddScoped(typeof(ICrudRepository<>), typeof(SqlRespository<>));
            services.AddScoped(typeof(ICrudService<>), typeof(CrudService<>));
            services.AddScoped<IToDoService, ToDoService>();
            services.AddScoped<IKanbanBoardService, KanbanBoardService>();
            services.AddScoped<INoteService, NoteService>();
            services.AddScoped<IToDoService, ToDoService>();
        }





        /// <summary>
        /// This method gets called by the runtime. 
        /// Use this method to configure the HTTP request pipeline.
        /// </summary>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                // this adds the developer exception page to the request pipeline.
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // centeralized way to handle unexpected errors
                app.UseExceptionHandler("Error");

                // centeralized way to handle http error status code responses
                app.UseStatusCodePagesWithReExecute("/Error/{0}");
            }


            //app.UseDefaultFiles(); // serves default.html, index.htm etc.. for the root url 

            // serves static resources like css, js, html etc..
            app.UseStaticFiles();

            // this serves both UseDefaultFiles and UseStaticFiles together.. shortcut-like thing..
            //app.UseFileServer();  


            app.UseAuthentication();


            // setting up mvc in the pipeline
            app.UseMvcWithDefaultRoute();


            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});
        }
    }
}
