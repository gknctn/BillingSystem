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
    public class EfOrderItemRepository : GenericRepository<OrderItem>, IOrderItemDal
    {
        private readonly Context _context;

        public EfOrderItemRepository(Context context) : base(context)
        {
            _context = context;
        }

        public List<OrderItem> GetOrderItemForOrderId(int id)
        {
            {
                return _context.OrderItems.Where(x => x.OrderId.Equals(id)).Include(y => y.Product).Include(z => z.Order).ToList();
            }
        }
    }
}
