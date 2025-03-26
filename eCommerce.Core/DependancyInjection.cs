using eCommerce.Core.Service;
using eCommerce.Core.ServiceContracts;
using Microsoft.Extensions.DependencyInjection;

namespace eCommerce.Core
{
    public static class DependancyInjection
    {
        /// <summary>
        /// Extension method to Add infrastructure services to dependency injection container
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddCore(this IServiceCollection services)
        {
            // TODO : Add Services to the IoC container 
            // Infrastructure services often include data access, caching and other low-level components.



            services.AddTransient<IUserService, UserService>();
            return services;
        }
    }
}
