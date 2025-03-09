using BillingSystem.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingSystem.BusinessLayer.Abstract
{
    public interface IOrderService
    {
        void Add(Order order);
        void Delete(Order order);
        void Update(Order order);
        List<Order> GetAll();
        Order GetById(int id);

        Order GetOrderForTableId(int id);
    }
}
