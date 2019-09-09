using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WorkApp.DataAccess.Entities;
using WorkApp.DataAccess.SqlServer;
using WorkApp.Respository.Interfaces;
using WorkApp.Respository.Repositories;
using WorkApp.Service.Interfaces;
using WorkApp.Service.Services;

namespace WorkApp.Service.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddAppServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 10;
            })
            .AddEntityFrameworkStores<AppDbContext>();


            services.AddDbContextPool<AppDbContext>(options =>
            {
                options.UseSqlServer(config.GetConnectionString("default"));
            });

            services.AddScoped(typeof(ICrudRepository<,>), typeof(SqlRespository<,>));
            //services.AddScoped(typeof(ICrudService<>), typeof(CrudService<>));
            services.AddScoped<IToDoService, ToDoService>();
            services.AddScoped<IKanbanBoardService, KanbanBoardService>();
            services.AddScoped<INoteService, NoteService>();
            services.AddScoped<IToDoService, ToDoService>();
            services.AddScoped<IDesktopMenuService, DesktopMenuService>();
            services.AddScoped<IAuthService, AuthService>();





            //Startup.cs configuration codes
            //services
            //    .AddDbContextPool<AppDbContext>(options => {
            //        options.UseSqlServer(_config.GetConnectionString("default"));
            //    });

            //services
            //    .AddIdentity<ApplicationUser, IdentityRole>(options => {
            //        options.Password.RequiredLength = 10;
            //    })
            //    .AddEntityFrameworkStores<AppDbContext>();


            //// AddScoped creates one instance for one http request (uses the same instance on the same http request)
            //services.AddScoped(typeof(ICrudRepository<>), typeof(SqlRespository<>));
            //services.AddScoped(typeof(ICrudService<>), typeof(CrudService<>));
            //services.AddScoped<IToDoService, ToDoService>();
            //services.AddScoped<IKanbanBoardService, KanbanBoardService>();
            //services.AddScoped<INoteService, NoteService>();
            //services.AddScoped<IToDoService, ToDoService>();
        }
    }
}
