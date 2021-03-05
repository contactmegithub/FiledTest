using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Filed.PaymentService.WebAPI.ServiceInjection
{
    public class OpenAPIInjection : IServiceInjection
    {
        public void InjectService(IServiceCollection service, IConfiguration configuration)
        {
            service.AddSwaggerGen(c => {

                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Filed.PaymentService.WebAPI", Version = "v1" });

            });
        }
    }
}
