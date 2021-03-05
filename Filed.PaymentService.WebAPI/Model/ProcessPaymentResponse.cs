using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Filed.PaymentService.WebAPI.Model
{
    public class ProcessPaymentResponse
    {
        [JsonProperty("paymentRefrenceNumber")]
        public string PaymentRefrenceNumber { get; set; }
        [JsonProperty("paymentStatus")]
        public string PaymentStatus { get; set; }
        [JsonProperty("paymentAmount")]
        public string PaymentAmount { get; set; }
    }
}
