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
    public class EfProductRepository : GenericRepository<Product>, IProductDal
    {
        private readonly Context _context;

        public EfProductRepository(Context context) : base(context)
        {
            _context = context;
        }

        public List<Product> GetAllProductsWithCategory()
        {
            return _context.Products.Include(p => p.Category).ToList();
        }
    }
}
