using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingSystem.EntityLayer.Concrete
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }

        [DataType(DataType.Currency)]
        public decimal ProductPrice { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }

        // ürünün kategorisi
        public Category? Category { get; set; }

        // ürünün kategori id'si
        public int CategoryId { get; set; }
        // Navigation Property: Bir ürün birden fazla sipariş kaleminde olabilir.
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
