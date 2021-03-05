using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Filed.PaymentService.WebAPI.Model
{
    public class ProcessPaymentRequest : IValidatableObject
    {
        [FromQuery(Name = "creditCardNumber")]
        [Required]
        public string CreditCardNumber { get; set; }
        [Required]
        [FromQuery(Name = "cardHolder")]
        public string CardHolder { get; set; }
        [Required]
        [FromQuery(Name = "expirationDate")]
        public DateTime ExpirationDate { get; set; }
        [FromQuery(Name = "securityCode")]
        public string SecurityCode { get; set; }
        [Required]
        [FromQuery(Name = "amount")]
        public decimal Amount { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();
            if (CreditCardNumber.Length != 16)
            {
                errors.Add(new ValidationResult("Invalid credit card number"));
            }
            if (CardHolder.Length > 25)
            {
                errors.Add(new ValidationResult("Card holder name should contains lessthan 26 characters"));
            }
            if (ExpirationDate < DateTime.Now)
            {
                errors.Add(new ValidationResult("Expiration date cannot be past date"));
            }
            if (!string.IsNullOrEmpty(SecurityCode) && SecurityCode.Length > 3)
            {
                errors.Add(new ValidationResult("Invaid security code"));
            }
            if(Amount <= 0)
            {
                errors.Add(new ValidationResult("Amount should be greaterthan zero"));
            }
            return errors;
        }
    }
}
