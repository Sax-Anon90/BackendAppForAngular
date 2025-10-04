using CoreBusiness.Implementation;
using CoreBusiness.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBusiness.ServiceRegistration
{
    public static class CoreBusinessServiceRegistration
    {
        public static IServiceCollection AddCoreBusinessServices(this IServiceCollection services)
        {

            services.AddScoped<IEmployeeRepositoryAsync, EmployeeRepositoryAsync>();
            services.AddScoped<IAuthenticationRepositoryAsync, AuthenticationRepositoryAsync>();
            services.AddScoped<IUserRolesRepositoryAsync, UserRolesRepositoryAsync>();

            services.AddScoped<IJwtServiceAsync, JwtServiceAsync>();


            return services;
        }
    }
}
