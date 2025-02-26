using BillingSystem.EntityLayer.Concrete;

namespace BillingSystem.Presentation.Models.Dtos
{
    public class CategoryWithProducts
    {
        public IOrderedEnumerable<Product> Products { get; set; }
        public IEnumerable<Category> Categories { get; set; }
    }
}
