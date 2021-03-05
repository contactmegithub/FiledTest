using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Field.PaymentService.DataAccess.EntityFramework.Library.Model
{
    public class Payment
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(16)]
        [Column(TypeName ="varchar(16)")]
        public string CreditCardNumber { get; set; }
        [Required]
        [MaxLength(25)]
        [Column(TypeName ="varchar(25)")]
        public string CardHolder { get; set; }
        [Required]
        [Column(TypeName ="date")]
        public DateTime ExpirationDate { get; set; }
        [MaxLength(3)]
        [Column(TypeName ="varchar(3)")]
        public string SecurityCode { get; set; }
        [Required]
        [Column(TypeName ="decimal")]
        public decimal Amount { get; set; }
        [Required]
        [MaxLength(10)]
        [Column(TypeName ="varchar(10)")]
        public string Status { get; set; } = "pending";
    }
}
