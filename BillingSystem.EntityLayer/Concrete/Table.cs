using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingSystem.EntityLayer.Concrete
{
    public class Table
    {
        public int TableId { get; set; } // Masa ID'si (Primary Key)
        public string TableName { get; set; } // Masa Adı (Örneğin: Masa 1, Masa 2)
        public bool IsOccupied { get; set; } // Masa dolu mu boş mu?

        // Navigation Property: Bir masada birden fazla sipariş olabilir.
        public ICollection<Order> Orders { get; set; }
    }
}
