using System.Threading.Tasks;

namespace Field.PaymentService.DataAccess.EntityFramework.Library
{
    public interface IPaymentServiceDA<T>
    {
        Task AddAsync(T entity);
        Task<T> GetAsync(int Id);
        Task UpdateAsync(T entity);
    }
}