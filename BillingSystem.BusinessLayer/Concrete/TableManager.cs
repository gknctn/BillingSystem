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
    public class TableManager : ITableService
    {
        private readonly ITableDal _tableDal;

        public TableManager(ITableDal tableDal)
        {
            _tableDal = tableDal;
        }

        public void Add(Table table)
        {
            _tableDal.Add(table);
        }

        public void Delete(Table table)
        {
            _tableDal.Delete(table);
        }

        public List<Table> GetAll()
        {
            return _tableDal.GetAll();
        }

        public Table GetById(int id)
        {
            return _tableDal.GetById(id);
        }

        public void Update(Table table)
        {
            _tableDal.Update(table);
        }
    }
}
