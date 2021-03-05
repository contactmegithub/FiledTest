using Field.PaymentService.DataAccess.EntityFramework.Library.Model;
using Filed.PaymentService.WebAPI.Business;
using Filed.PaymentService.WebAPI.Controllers;
using Filed.PaymentService.WebAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filed.PaymentService.WebAPI.UnitTest.Controller
{
    [TestClass]
    public class PaymentControllerTest
    {
        private ILogger<PaymentController> _Logger;
        private IPaymentBusiness _PaymentBusiness;
        private PaymentController _PaymentController;
        [TestInitialize]
        public void Setup()
        {
            _Logger = Substitute.For<ILogger<PaymentController>>();
            _PaymentBusiness = Substitute.For<IPaymentBusiness>();
            _PaymentController = new PaymentController(_Logger, _PaymentBusiness);
        }
        [TestMethod]
        public void ProcessPaymentAsync_200()
        {
            var request = new ProcessPaymentRequest() {Amount=101 };
            var payment = new Payment() { Amount = 101, Id = 1, Status = "processed" };
           _PaymentBusiness.ProcessPaymentAsync(Arg.Any<ProcessPaymentRequest>()).Returns(payment);
            var actionResult = _PaymentController.ProcessPaymentAsync(request).GetAwaiter().GetResult() as OkObjectResult;
            Assert.Equals(200, actionResult.StatusCode);
            Assert.IsTrue(actionResult.Value is ProcessPaymentResponse);
            var result = actionResult.Value as ProcessPaymentResponse;
            Assert.IsTrue(result.PaymentAmount.Equals(payment.Amount.ToString()));
            Assert.IsTrue(result.PaymentRefrenceNumber.Equals(payment.Id.ToString()));
            Assert.IsTrue(result.PaymentStatus.Equals(payment.Status.ToString()));
        }
    }
}
