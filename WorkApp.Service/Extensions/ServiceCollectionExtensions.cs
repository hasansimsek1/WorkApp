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
    /// <summary>
    /// Extensions for IServiceCollection interface.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Registers application services to the container. 
        /// </summary>
        public static void AddAppServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddIdentity<ApplicationUser, IdentityRole>(options => { options.Password.RequiredLength = 10; }).AddEntityFrameworkStores<AppDbContext>();
            services.AddDbContextPool<AppDbContext>(options => { options.UseSqlServer(config.GetConnectionString("default")); });
            services.AddScoped(typeof(ICrudRepository<,>), typeof(SqlRespository<,>));
            services.AddScoped<IToDoService, ToDoService>();
            services.AddScoped<IKanbanBoardService, KanbanBoardService>();
            services.AddScoped<INoteService, NoteService>();
            services.AddScoped<IToDoService, ToDoService>();
            services.AddScoped<IDesktopMenuService, DesktopMenuService>();
            services.AddScoped<IAuthService, AuthService>();
        }
    }
}
