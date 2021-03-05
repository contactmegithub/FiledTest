namespace Filed.PaymentService.WebAPI.ServiceInjection
{
    internal interface IServiceInjection
    {
        void InjectService(Microsoft.Extensions.DependencyInjection.IServiceCollection service, Microsoft.Extensions.Configuration.IConfiguration configuration);
    }
}