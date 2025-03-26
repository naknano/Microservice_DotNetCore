using eCommerce.Core.DTO;
using eCommerce.Core.Service;
using eCommerce.Core.ServiceContracts;
using eCommerce.Core.Validators;
using FluentValidation;
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
            

            // FlueValidator in core layer
            services.AddValidatorsFromAssemblyContaining<LoginRequestValidator>();

            return services;
        }
    }
}
