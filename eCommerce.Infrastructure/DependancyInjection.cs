using eCommerce.Core.RepositoryContracts;
using eCommerce.Core.ServiceContracts;
using eCommerce.Core.Service;

using eCommerce.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace eCommerce.Infrastructure
{
   public static class DependancyInjection
   {
        /// <summary>
        /// Extension method to Add infrastructure services to dependency injection container
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddInfrastruction(this IServiceCollection services)
        {
            // TODO : Add Services to the IoC container 
            // Infrastructure services often include data access, caching and other low-level components.
            //services.AddSingleton<IUserRepository, UserRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            //services.AddTransient<IUserService, UserService>();

            return services;
        }
    }
}
