using System;
using System.Threading.Tasks;

namespace Field.PaymentGateway.Library
{
    public class PremiumPaymentService : IPremiumPaymentService
    {
        private readonly IMockProcessor _mockProcessor;
        public PremiumPaymentService(IMockProcessor mockProcessor)
        {
            this._mockProcessor = mockProcessor;
        }

        public async Task<bool> ProcessPayment(string creditCardNumber, string cardHolder, DateTime expirationDate, string securityCode, decimal amount)
        {
            return await _mockProcessor.ProcessPayment(creditCardNumber, cardHolder, expirationDate, securityCode, amount);
        }
    }
}
