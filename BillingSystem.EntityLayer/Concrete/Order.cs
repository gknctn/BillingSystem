using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingSystem.EntityLayer.Concrete
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public bool IsPaid { get; set; } = false;

        // Foreign Key
        public int TableId { get; set; }

        // Navigation Properties
        public Table Table { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
        public Payment Payment { get; set; }
    }
}
