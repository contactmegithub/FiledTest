using Filed.PaymentService.WebAPI.Business;
using Filed.PaymentService.WebAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Filed.PaymentService.WebAPI.Controllers
{
    [Produces("application/json")]
    [ApiVersion("1")]
    [Route("api/v{versoin:apiVersion}/payment")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly ILogger<PaymentController> _Logger;
        private readonly IPaymentBusiness _PaymentBusiness;
        public PaymentController(ILogger<PaymentController> logger, IPaymentBusiness paymentBusiness)
        {
            _Logger = logger;
            _PaymentBusiness = paymentBusiness;
        }
        [ProducesResponseType(typeof(ProcessPaymentResponse), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [HttpPost]
        [Route("processpayment")]
        public async Task<IActionResult> ProcessPaymentAsync([FromQuery] ProcessPaymentRequest processPaymentRequest)
        {
            try
            {
                var result = await _PaymentBusiness.ProcessPaymentAsync(processPaymentRequest).ConfigureAwait(false);
                return Ok(result);
            }
            catch (InvalidOperationException ex)
            {
                _Logger.LogError(ex.Message, ex);
                return BadRequest();
            }
            catch (Exception ex)
            {
                _Logger.LogError(ex.Message, ex);
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}
