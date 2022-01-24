using AutoMapper.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MidChat.BLL.Interfeces.BLLInterfeces;
using MidChat.BLL.Interfeces.BLLInterfeces.CRUDService;
using MidChat.BLL.Services;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace MidChat.BLL.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAutomapperProfiles(this IServiceCollection services, params Assembly[] otherMapperAssemblies)
        {
            List<Assembly> assemblies = new List<Assembly>(otherMapperAssemblies)
            {
                Assembly.GetExecutingAssembly()
            };
            services.AddAutoMapper(assemblies);
            return services;
        }

        public static IServiceCollection AddBusinessLayerDependencies(this IServiceCollection services, IConfiguration configuration)
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
    }
}
