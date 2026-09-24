using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace ProjectManagement_API.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg=> {
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
                });

            //register all mapper related services like mappingprofiles by scanning
            //the executing assembly i.e.Application layer. So, no need to register 
            //for every mapping profile
            services.AddAutoMapper(cfg =>
            {
                cfg.AddMaps(Assembly.GetExecutingAssembly());
            });
            return services;
        }
    }
}
