using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingSystem.EntityLayer.Concrete
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; } = DateTime.Now;
        public string PaymentMethod { get; set; }

        // Foreign Key
        public int OrderId { get; set; }

        // Navigation Property
        public Order Order { get; set; }
    }
}
