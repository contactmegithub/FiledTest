using System;
using System.Threading.Tasks;

namespace Field.PaymentGateway.Library
{
    public interface IPremiumPaymentService
    {
        Task<bool> ProcessPayment(string creditCardNumber, string cardHolder, DateTime expirationDate, string securityCode, decimal amount);
    }
}