using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesStatistics.Data.Entities;

namespace SalesStatistics.Data
{
    public interface IRepository
    {
        void Add<T>(T entity) where T : BaseEntity;
        IEnumerable<T> Get<T>() where T : BaseEntity;
    }
}
