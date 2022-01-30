using Microsoft.Extensions.DependencyInjection;
using Sat.Recruitment.Core.Interfaces;
using Sat.Recruitment.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sat.Recruitment.Infrastructure
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<IUserRepository, UserRepository>();
            return services;
        }
    }
}
