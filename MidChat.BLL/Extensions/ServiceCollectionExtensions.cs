using AutoMapper.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MidChat.BLL.Interfeces.BLLInterfeces;
using MidChat.BLL.Interfeces.BLLInterfeces.CRUDService;
using MidChat.BLL.Services;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Reflection;
using MidChat.BLL.Interfeces;
using MidChat.BLL.Repositories;

namespace MidChat.BLL.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAppDbContext(this IServiceCollection services, Microsoft.Extensions.Configuration.IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(o =>
            {
                o.UseLazyLoadingProxies();
                o.UseSqlServer(configuration.GetConnectionString("AppDb"));
            });
            return services;
        }

        public static IServiceCollection AddAutomapperProfiles(this IServiceCollection services, params Assembly[] otherMapperAssemblies)
        {
            List<Assembly> assemblies = new List<Assembly>(otherMapperAssemblies)
            {
                Assembly.GetExecutingAssembly()
            };
            services.AddAutoMapper(assemblies);
            return services;
        }

        public static IServiceCollection AddBusinessLayerDependencies(this IServiceCollection services, AutoMapper.Configuration.IConfiguration configuration)
        {
            services.AddCRUDServices();
            services.AddTransient<IAppUsersManager, AppUsersManager>();
            services.AddTransient<IAppSignInManager, AppSignInManager>();
            return services;
        }

        private static IServiceCollection AddCRUDServices(this IServiceCollection services)
        {
            services.AddScoped<IUserCrudService, UsersCrudServices>();
            return services;
        }

        public static IServiceCollection AddAppDbDependencies(this IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, AppUnitOfWork>();
            services.AddTransient<IUsersRepository, UsersRepository>();
            services.AddTransient<IGroupRepository, GroupRepository>();
            services.AddTransient<IMessegesRepository, MessegesRepository>();
            return services;
        }
    }
}
