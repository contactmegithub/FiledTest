using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Filed.PaymentService.WebAPI.ServiceInjection
{
    public static class InjectionService
    {
        public static void InjectService(Microsoft.Extensions.DependencyInjection.IServiceCollection service,IConfiguration configuration)
        {
            var injections = typeof(Startup).Assembly.ExportedTypes.Where(w => typeof(IServiceInjection).IsAssignableFrom(w) && !w.IsInterface && !w.IsAbstract).
                Select(Activator.CreateInstance).Cast<IServiceInjection>().ToList();

            injections.ForEach(inject => inject.InjectService(service, configuration));
        }
    }
}
