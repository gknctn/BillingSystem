using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingSystem.EntityLayer.Concrete
{
    public class Payment
    {
        public int PaymentId { get; set; } // Ödeme ID'si (Primary Key)
        public DateTime PaymentDate { get; set; } // Ödeme Tarihi
        public decimal AmountPaid { get; set; } // Ödenen Tutar
        public string PaymentMethod { get; set; } // Ödeme Yöntemi (Nakit, Kredi Kartı)

        // Foreign Key: Hangi siparişe ait olduğu
        public int OrderId { get; set; }
        public Order Order { get; set; } // Navigation Property: Sipariş
    }
}
