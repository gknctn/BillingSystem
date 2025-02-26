using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingSystem.EntityLayer.Concrete
{
    public class Table
    {
        public int TableId { get; set; }
        public string TableName { get; set; }
        public ICollection<Order> Order{ get; set; }
        public int OrderId { get; set; }
    }
}
