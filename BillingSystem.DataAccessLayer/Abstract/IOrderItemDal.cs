using BillingSystem.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingSystem.DataAccessLayer.Abstract
{
    public interface IOrderItemDal : IGenericDal<OrderItem>
    {
        List<OrderItem> GetOrderItemForOrderId(int id);
    }
}
