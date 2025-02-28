using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingSystem.EntityLayer.Concrete
{
    public class Order
    {
        public int OrderId { get; set; } // Sipariş ID'si (Primary Key)
        public DateTime OrderDate { get; set; } // Sipariş Tarihi
        public decimal TotalAmount { get; set; } // Toplam Tutar
        public bool IsPaid { get; set; } // Ödendi mi?

        // Foreign Key: Hangi masaya ait olduğu
        public int TableId { get; set; }
        public Table Table { get; set; } // Navigation Property: Masa

        // Navigation Property: Bir siparişte birden fazla sipariş kalemi olabilir.
        public ICollection<OrderItem> OrderItems { get; set; }

        // Navigation Property: Ödeme bilgisi
        public Payment Payment { get; set; }
    }
}
