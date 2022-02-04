using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Core.Attributes;
using Core.Enums;
using Infrastructure.Persistence.Contexts;
using Infrastructure.Persistence.Repositories;

namespace Domain
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Registro de todos los servicios a Injectar del proyecto
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var defaultConnectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<ContractManagerContext>(options =>
               options.UseSqlServer(defaultConnectionString));

            services.AddScoped(typeof(IGenericRepository), typeof(GenericRepository));

            RegisterServices(ref services);

            return services;
        }

        /// <summary>
        /// Inyección de dependencia automatica de los servicios en la carpeta "Services"
        /// De acuerdo a el atributte que posean dichos serivicios 
        /// </summary>
        /// <param name="services"></param>
        private static void RegisterServices(ref IServiceCollection services)
        {
            var AssemblyServicesTypes = AppDomain.CurrentDomain.GetAssemblies()
                                        .SelectMany(t => t.GetTypes())
                                            .Where(t => t.IsClass && t.Namespace == "Domain.Services");

            foreach (Type serviceClass in AssemblyServicesTypes)
            {
                if (!serviceClass.IsClass)
                    continue;

                if (serviceClass.GetCustomAttributes(typeof(InjectableServiceAttribute), true).FirstOrDefault() is not InjectableServiceAttribute attributeInjectable)
                    continue;

                switch (attributeInjectable.GetTypeInjectable())
                {
                    case EServices.None:
                        continue;
                    case EServices.Singleton:
                        services.AddSingleton(serviceClass);
                        break;
                    case EServices.Scope:
                        services.AddScoped(serviceClass);
                        break;
                    case EServices.Transient:
                        services.AddTransient(serviceClass);
                        break;
                    default:
                        continue;
                }
            }

        }
    }
}
