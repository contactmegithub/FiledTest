using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Filed.PaymentService.WebAPI.ServiceInjection
{
    public class MVCInjection : IServiceInjection
    {
        public void InjectService(IServiceCollection service, IConfiguration configuration)
        {
            service.AddMvc(options =>
            {
                options.RespectBrowserAcceptHeader = true;
                options.ReturnHttpNotAcceptable = true;
                options.EnableEndpointRouting = false;
                options.ModelBindingMessageProvider.SetAttemptedValueIsInvalidAccessor((message, feild) => $"This value {System.Net.WebUtility.UrlEncode(message)} is not valid from {feild}");
            }).AddJsonOptions(jsonOptions =>
            jsonOptions.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull);
            service.AddControllers();
            service.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }
    }
}
