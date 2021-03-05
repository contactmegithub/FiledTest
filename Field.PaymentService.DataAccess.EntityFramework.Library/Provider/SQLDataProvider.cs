using Field.PaymentService.DataAccess.EntityFramework.Library.DataAccess;
using Field.PaymentService.DataAccess.EntityFramework.Library.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Field.PaymentService.DataAccess.EntityFramework.Library.Provider
{
    public class SQLDataProvider : IDataProvider<Payment>
    {
        private readonly PaymentContext _PaymentContext;
        public SQLDataProvider(PaymentContext paymentContext)
        {
            _PaymentContext = paymentContext;
        }
        public async Task<Payment> GetAsync(int Id)
        {
            throw new NotImplementedException();
        }
        public async Task AddAsync(Payment entity)
        {
            await _PaymentContext.Payments.AddAsync(entity).ConfigureAwait(false);
            await _PaymentContext.SaveChangesAsync().ConfigureAwait(false);
        }
        public async Task UpdateAsync(Payment entity)
        {
            var result = _PaymentContext.Payments.FirstOrDefault(p => p.Id.Equals(entity.Id));
            result.Status = entity.Status;
            await _PaymentContext.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}
