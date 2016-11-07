using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesStatistics.Data.Entities;

namespace SalesStatistics.Data
{
    public class Repository : IRepository
    {
        StatisticsContext _context = new StatisticsContext();

        public void Add<T>(T entity) where T : BaseEntity
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        public IEnumerable<T> Get<T>() where T : BaseEntity
        {
            return _context.Set<T>();
        }
    }
}
