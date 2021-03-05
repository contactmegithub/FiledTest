using AutoMapper;
using Field.PaymentService.DataAccess.EntityFramework.Library.Model;
using Filed.PaymentService.WebAPI.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Filed.PaymentService.WebAPI.Filter
{
    public class ResultFilter : ResultFilterAttribute
    {
        public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            var resultFromAction = context.Result as ObjectResult;
            if (resultFromAction?.Value == null || resultFromAction.StatusCode < 200 || resultFromAction.StatusCode >= 300)
            {
                await next();
                return;
            }
            var mapper = context.HttpContext.RequestServices.GetService(typeof(IMapper)) as IMapper;
            var actionDescriptor = context.ActionDescriptor as ControllerActionDescriptor;
            var actionInfo = $"{actionDescriptor.ControllerName}{actionDescriptor.ActionName}";
            resultFromAction.Value = TransformResult(mapper, actionInfo, resultFromAction);
            await next();
        }

        private object TransformResult(IMapper mapper, string actionInfo, ObjectResult resultFromAction)
        {
            return actionInfo switch
            {
                "PaymentProcessPaymentAsync" => MapResult<Payment, ProcessPaymentResponse>(mapper, resultFromAction),
                _ => resultFromAction.Value,
            };
            throw new NotImplementedException();
        }

        private object MapResult<TSource, TDestination>(IMapper mapper, ObjectResult resultFromAction)
        {
            return mapper.Map<TDestination>(resultFromAction.Value);
        }
    }
}
