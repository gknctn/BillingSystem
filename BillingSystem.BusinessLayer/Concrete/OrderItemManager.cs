using BillingSystem.BusinessLayer.Abstract;
using BillingSystem.DataAccessLayer.Abstract;
using BillingSystem.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingSystem.BusinessLayer.Concrete
{
    public class OrderItemManager : IOrderItemService
    {
        private readonly IOrderItemDal _orderItemDal;

        public OrderItemManager(IOrderItemDal orderItemDal)
        {
            _orderItemDal = orderItemDal;
        }

        public void Add(OrderItem orderItem)
        {
            _orderItemDal.Add(orderItem);
        }

        public void Delete(OrderItem orderItem)
        {
            _orderItemDal.Delete(orderItem);
        }

        public List<OrderItem> GetAll()
        {
            return _orderItemDal.GetAll();
        }

        public OrderItem GetById(int id)
        {
            return _orderItemDal.GetById(id);
        }

        public List<OrderItem> GetOrderItemForOrderId(int id)
        {
            return _orderItemDal.GetOrderItemForOrderId(id);
        }

        public void Update(OrderItem orderItem)
        {
            _orderItemDal.Update(orderItem);
        }
    }
}
