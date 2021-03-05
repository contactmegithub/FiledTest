using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Field.PaymentGateway.Library
{
    public class MockProcessor : IMockProcessor
    {
        public ValueTask<bool> ProcessPayment(string creditCardNumber, string cardHolder, DateTime expirationDate, string securityCode, decimal amount)
        {
            return new ValueTask<bool>(true);
        }
    }
}
