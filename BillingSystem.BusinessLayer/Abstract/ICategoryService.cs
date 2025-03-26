using BillingSystem.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingSystem.BusinessLayer.Abstract
{
    public interface ICategoryService : IGenericServices<Category>
    {
        IQueryable<Category> GetAllCategoriesWithProduct(int id);

    }
}
