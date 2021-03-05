using System;
using System.Threading.Tasks;

namespace Field.PaymentGateway.Library
{
    public interface IExpensivePaymentGateway
    {
        Task<bool> ProcessPayment(string creditCardNumber, string cardHolder, DateTime expirationDate, string securityCode, decimal amount);
    }
}