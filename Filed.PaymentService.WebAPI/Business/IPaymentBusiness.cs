using Field.PaymentService.DataAccess.EntityFramework.Library.Model;
using Filed.PaymentService.WebAPI.Model;
using System.Threading.Tasks;

namespace Filed.PaymentService.WebAPI.Business
{
    public interface IPaymentBusiness
    {
        Task<Payment> ProcessPaymentAsync(ProcessPaymentRequest processPaymentRequest);
    }
}