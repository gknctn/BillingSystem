using BillingSystem.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingSystem.BusinessLayer.Abstract
{
    public interface ITableService
    {
        void Add(Table table);
        void Delete(Table table);
        void Update(Table table);
        List<Table> GetAll();
        Table GetById(int id);
    }
}
