using Microsoft.Extensions.DependencyInjection;
using ProductApp.Application.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ProductApp.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationRegistration(this IServiceCollection services)
        {
            var ass = Assembly.GetExecutingAssembly();
            services.AddAutoMapper(ass);
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(ass));
        }
    }
}
