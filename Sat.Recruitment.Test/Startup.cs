using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Sat.Recruitment.Core.Interfaces;
using Sat.Recruitment.Infrastructure;
using Sat.Recruitment.Infrastructure.Repositories;

namespace Sat.Recruitment.Test
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IUserRepository, UserRepository>();

            //Dependecy Injection
            services.AddInfrastructure();
        }
    }
}
