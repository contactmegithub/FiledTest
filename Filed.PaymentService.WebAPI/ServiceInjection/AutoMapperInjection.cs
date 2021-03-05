using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Filed.PaymentService.WebAPI.ServiceInjection
{
    public class AutoMapperInjection : IServiceInjection
    {
        public void InjectService(IServiceCollection service, IConfiguration configuration)
        {
            service.AddAutoMapper(typeof(Startup));
        }
    }
}
