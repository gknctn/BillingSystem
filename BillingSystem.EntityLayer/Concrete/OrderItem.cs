using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingSystem.EntityLayer.Concrete
{
    public class OrderItem
    {
        public int OrderItemId { get; set; } // Sipariş Kalemi ID'si (Primary Key)
        public int Quantity { get; set; } // Ürün Adedi
        public decimal UnitPrice { get; set; } // Birim Fiyat

        // Foreign Key: Hangi siparişe ait olduğu
        public int OrderId { get; set; }
        public Order Order { get; set; } // Navigation Property: Sipariş

        // Foreign Key: Hangi ürüne ait olduğu
        public int ProductId { get; set; }
        public Product Product { get; set; } // Navigation Property: Ürün
    }
}
