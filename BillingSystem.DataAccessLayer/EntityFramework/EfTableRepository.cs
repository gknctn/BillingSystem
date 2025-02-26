using BillingSystem.DataAccessLayer.Abstract;
using BillingSystem.DataAccessLayer.Repository;
using BillingSystem.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingSystem.DataAccessLayer.EntityFramework
{
    public class EfTableRepository : GenericRepository<Table>, ITableDal
    {
    }
}
