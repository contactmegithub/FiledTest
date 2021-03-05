using Field.PaymentService.DataAccess.EntityFramework.Library.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Field.PaymentService.DataAccess.EntityFramework.Library
{
    public class PaymentServiceDA<T> : IPaymentServiceDA<T>
    {
        private readonly IDataProvider<T> _dataProvider;
        public PaymentServiceDA(IDataProvider<T> dataProvider)
        {
            _dataProvider = dataProvider;
        }
        public async Task<T> GetAsync(int id)
        {
            return await _dataProvider.GetAsync(id);
        }
        public async Task AddAsync(T entity)
        {
            await _dataProvider.AddAsync(entity);
        }
        public async Task UpdateAsync(T entity)
        {
            await _dataProvider.UpdateAsync(entity);
        }
    }
}
