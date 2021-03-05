using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Filed.PaymentService.WebAPI.ServiceInjection
{
    public class ApiVersioning : IServiceInjection
    {
        public void InjectService(IServiceCollection service, IConfiguration configuration)
        {
            service.AddApiVersioning(version => {
                version.ReportApiVersions = true;
                version.AssumeDefaultVersionWhenUnspecified = true;
                version.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
            });
        }
    }
}
