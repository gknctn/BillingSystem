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
    public class PaymentManager : IPaymentService
    {
        private readonly IPaymentDal _paymentDal;
        public void Add(Payment payment)
        {
            _paymentDal.Add(payment);
        }

        public void Delete(Payment payment)
        {
            _paymentDal.Delete(payment);
        }

        public List<Payment> GetAll()
        {
            return _paymentDal.GetAll();
        }

        public Payment GetById(int id)
        {
            return _paymentDal.GetById(id);
        }

        public void Update(Payment payment)
        {
            _paymentDal.Update(payment);
        }
    }
}
