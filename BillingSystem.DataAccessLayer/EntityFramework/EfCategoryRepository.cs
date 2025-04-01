using BillingSystem.DataAccessLayer.Abstract;
using BillingSystem.DataAccessLayer.Concrete;
using BillingSystem.DataAccessLayer.Repository;
using BillingSystem.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingSystem.DataAccessLayer.EntityFramework
{
    public class EfCategoryRepository : GenericRepository<Category>, ICategoryDal
    {
        private readonly Context _context;

        public EfCategoryRepository(Context context) : base(context)
        {
            _context = context;
        }

        public IQueryable<Category> GetAllCategoriesWithProduct(int id)
        {
            return _context.Categories.Where(z => z.CategoryId.Equals(id)).Where(z => z.IsActive.Equals(true)).Include(p => p.Products);
        }
    }
}
