using Autofac;
using Field.PaymentGateway.Library;
using Field.PaymentService.DataAccess.EntityFramework.Library;
using Field.PaymentService.DataAccess.EntityFramework.Library.Model;
using Field.PaymentService.DataAccess.EntityFramework.Library.Provider;
using Filed.PaymentService.WebAPI.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Filed.PaymentService.WebAPI.ServiceInjection
{
    public class DependancyInjection : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<PaymentBusiness>().As<IPaymentBusiness>();
            builder.RegisterType<CheapPaymentGateway>().As<ICheapPaymentGateway>();
            builder.RegisterType<ExpensivePaymentGateway>().As<IExpensivePaymentGateway>();
            builder.RegisterType<PremiumPaymentService>().As<IPremiumPaymentService>();
            builder.RegisterType<PaymentServiceDA<Payment>>().As<IPaymentServiceDA<Payment>>();
            builder.RegisterType<MockProcessor>().As<IMockProcessor>();
            builder.RegisterType<SQLDataProvider>().As<IDataProvider<Payment>>();
            base.Load(builder); 
        }
    }
}
