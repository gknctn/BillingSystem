using BillingSystem.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingSystem.BusinessLayer.Abstract
{
    public interface IPaymentService
    {
        void Add(Payment payment);
        void Delete(Payment payment);
        void Update(Payment payment);
        List<Payment> GetAll();
        Payment GetById(int id);
    }
}
