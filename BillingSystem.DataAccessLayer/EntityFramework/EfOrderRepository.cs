using BillingSystem.DataAccessLayer.Abstract;
using BillingSystem.DataAccessLayer.Concrete;
using BillingSystem.DataAccessLayer.Repository;
using BillingSystem.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingSystem.DataAccessLayer.EntityFramework
{
    public class EfOrderRepository : GenericRepository<Order>, IOrderDal
    {
        private readonly Context _context;

        public EfOrderRepository(Context context) : base(context)
        {
            _context = context;
        }

        public Order GetOrderForTableId(int id)
        {
            return _context.Orders
                .Where(x => x.TableId.Equals(id))
                .Where(y => y.IsPaid.Equals(false))
                .OrderByDescending(o => o.OrderDate) // En yeni sipariş en üstte
                .FirstOrDefault(); // İlk öğeyi al;
        }
    }
}
