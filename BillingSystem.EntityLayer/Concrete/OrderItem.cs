using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingSystem.EntityLayer.Concrete
{
    public class OrderItem
    {
        public int OrderItemId { get; set; }
        public int Quantity { get; set; }

        // Foreign Keys
        public int OrderId { get; set; }
        public int ProductId { get; set; }

        // Navigation Properties
        public Order Order { get; set; }
        public Product Product { get; set; }
    }
}
