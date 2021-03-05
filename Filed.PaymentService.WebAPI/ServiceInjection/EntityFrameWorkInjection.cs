using Field.PaymentService.DataAccess.EntityFramework.Library.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace Filed.PaymentService.WebAPI.ServiceInjection
{
    public class EntityFrameWorkInjection : IServiceInjection
    {
        public void InjectService(IServiceCollection service, IConfiguration configuration)
        {
            service.AddDbContext<PaymentContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("FiletPaymentDbConfig"));
            });
        }
    }
}
