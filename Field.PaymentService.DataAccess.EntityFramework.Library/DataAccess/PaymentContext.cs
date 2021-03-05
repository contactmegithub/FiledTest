using Field.PaymentService.DataAccess.EntityFramework.Library.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Field.PaymentService.DataAccess.EntityFramework.Library.DataAccess
{
    public class PaymentContext:DbContext
    {
        public PaymentContext(DbContextOptions options) : base(options) { }
        public DbSet<Payment> Payments { get; set; }
    }
}
