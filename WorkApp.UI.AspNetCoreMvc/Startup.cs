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
    public class Startup
    {
        private IConfiguration _config;

        public Startup(IConfiguration config)
        {
            _config = config;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            /*
             * TODOES:
             *      organize the codes in this method for readability.
             *      services can be gathered from lower layers. but it's ok for now.
             */
             

            services.AddDbContextPool<AppDbContext>(options => options.UseSqlServer(_config.GetConnectionString("default")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>();

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

            //services.AddScoped<DbContext, AppDbContext>();

            services.AddScoped(typeof(ICrudRepository<>), typeof(SqlRespository<>));
            services.AddScoped(typeof(ICrudService<>), typeof(CrudService<>));
            services.AddScoped<IToDoService, ToDoService>();    // it creates one instance for one http request (uses the same instance on the same http request)
            services.AddScoped<IKanbanBoardService, KanbanBoardService>();
            services.AddScoped<INoteService, NoteService>();
            services.AddScoped<IToDoService, ToDoService>();
            //services.AddTransient<IToDoService, ToDoService>();  // it creates new instance for every call to this service (even in the same http request)
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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

            // serves static resources like css, js, html etc.. static web pages that do not rendered can be served from here.
            // reverses the request pipeline..
            //app.UseDefaultFiles(); // serves default.html, index.htm etc.. for the root url 
            app.UseStaticFiles();
            //app.UseFileServer();  // this serves both UseDefaultFiles and UseStaticFiles together.. shortcut-like thing..


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
