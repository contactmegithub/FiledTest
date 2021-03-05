using Field.PaymentGateway.Library;
using Field.PaymentService.DataAccess.EntityFramework.Library;
using Field.PaymentService.DataAccess.EntityFramework.Library.Model;
using Filed.PaymentService.WebAPI.Model;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Filed.PaymentService.WebAPI.Business
{
    public class PaymentBusiness : IPaymentBusiness
    {
        private readonly ILogger<PaymentBusiness> _Iogger;
        private readonly ICheapPaymentGateway _CheapPaymentGateway;
        private readonly IExpensivePaymentGateway _ExpensivePaymentGateway;
        private readonly IPremiumPaymentService _PremiumPaymentService;
        private readonly IPaymentServiceDA<Payment> _PaymentServiceDA;
        private delegate bool ProcessPayment(string creditCardNumber, string cardHolder, DateTime expirationDate, string securityCode, decimal amount);
        public PaymentBusiness(ILogger<PaymentBusiness> logger,
                               ICheapPaymentGateway cheapPaymentGateway,
                               IExpensivePaymentGateway expensivePaymentGateway,
                               IPremiumPaymentService premiumPaymentService,
                               IPaymentServiceDA<Payment> paymentServiceDA)
        {
            _Iogger = logger;
            _CheapPaymentGateway = cheapPaymentGateway;
            _ExpensivePaymentGateway = expensivePaymentGateway;
            _PremiumPaymentService = premiumPaymentService;
            _PaymentServiceDA = paymentServiceDA;
        }
        public async Task<Payment> ProcessPaymentAsync(ProcessPaymentRequest processPaymentRequest)
        {
            var payment = await AddNewPayment(processPaymentRequest).ConfigureAwait(false);
            bool isPaymentSuceed;
            if (processPaymentRequest.Amount <= 20)
            {
                var paymentTask = _CheapPaymentGateway.ProcessPayment(processPaymentRequest.CreditCardNumber,
                                                                            processPaymentRequest.CardHolder,
                                                                            processPaymentRequest.ExpirationDate,
                                                                            processPaymentRequest.SecurityCode,
                                                                            processPaymentRequest.Amount);
                isPaymentSuceed = await ProcessPaymentAsync(paymentTask, 1);
            }
            else if (processPaymentRequest.Amount <= 500)
            {
                var paymentTask = _ExpensivePaymentGateway.ProcessPayment(processPaymentRequest.CreditCardNumber,
                                                                            processPaymentRequest.CardHolder,
                                                                            processPaymentRequest.ExpirationDate,
                                                                            processPaymentRequest.SecurityCode,
                                                                            processPaymentRequest.Amount);
                isPaymentSuceed = await ProcessPaymentAsync(paymentTask, 1);
                if (!isPaymentSuceed)
                {
                    paymentTask = _CheapPaymentGateway.ProcessPayment(processPaymentRequest.CreditCardNumber,
                                                                              processPaymentRequest.CardHolder,
                                                                              processPaymentRequest.ExpirationDate,
                                                                              processPaymentRequest.SecurityCode,
                                                                              processPaymentRequest.Amount);
                    isPaymentSuceed = await ProcessPaymentAsync(paymentTask, 1);
                }
            }
            else
            {
                var paymentTask = _CheapPaymentGateway.ProcessPayment(processPaymentRequest.CreditCardNumber,
                                                                            processPaymentRequest.CardHolder,
                                                                            processPaymentRequest.ExpirationDate,
                                                                            processPaymentRequest.SecurityCode,
                                                                            processPaymentRequest.Amount);
                isPaymentSuceed = await ProcessPaymentAsync(paymentTask, 3);
            }
            payment.Status = isPaymentSuceed ? "processed" : "failed";
            await UpdatePayment(payment);
            return payment;
        }

        private async Task<bool> ProcessPaymentAsync(Task<bool> func, int retryCount)
        {
            for (int count = 0; count < retryCount; count++)
            {
                var result = await func.ConfigureAwait(false);
                if (result)
                    return true;
            }
            return false;
        }

        private async Task<Payment> AddNewPayment(ProcessPaymentRequest processPaymentRequest)
        {
            var payment = new Payment()
            {
                Amount = processPaymentRequest.Amount,
                CardHolder = processPaymentRequest.CardHolder,
                CreditCardNumber = processPaymentRequest.CreditCardNumber,
                ExpirationDate = processPaymentRequest.ExpirationDate,
                SecurityCode = processPaymentRequest.SecurityCode,
                Status = "pending"
            };
            await _PaymentServiceDA.AddAsync(payment);
            return payment;
        }
        private async Task<Payment> UpdatePayment(Payment payment)
        {
            await _PaymentServiceDA.UpdateAsync(payment);
            return payment;
        }

    }
}
