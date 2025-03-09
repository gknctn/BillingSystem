using BillingSystem.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingSystem.DataAccessLayer.Abstract
{
    public interface IOrderDal : IGenericDal<Order>
    {
        Order GetOrderForTableId(int id);
    }
}
