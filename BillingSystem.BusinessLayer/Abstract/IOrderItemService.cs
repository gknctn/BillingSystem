using BillingSystem.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingSystem.BusinessLayer.Abstract
{
    public interface IOrderItemService
    {
        void Add(OrderItem orderItem);
        void Delete(OrderItem orderItem);
        void Update(OrderItem orderItem);
        List<OrderItem> GetAll();
        OrderItem GetById(int id);
    }
}
