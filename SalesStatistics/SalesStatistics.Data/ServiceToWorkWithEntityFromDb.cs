using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesStatistics.Data.Entities;
using SalesStatistics.Data.Entities.Abstract;

namespace SalesStatistics.Data
{
    public class ServiceToWorkWithEntityFromDb
    {
        private IRepository _repository;

        public ServiceToWorkWithEntityFromDb()
        {
            IRepository _repo = new Repository();
            _repository = _repo;
        }


        public void AddBest(Bestseller best)
        {
            _repository.Add(best);
        }

        public void AddAppliances(Appliances appliances)
        {
            _repository.Add(appliances);
        }

        public void AddInsurance(Insurance insurance)
        {
            _repository.Add(insurance);
        }

        public void AddSimCard(SimCard simCard)
        {
            _repository.Add(simCard);
        }

        public IEnumerable<T> Get<T>() where T : BaseEntity
        {
            return _repository.Get<T>();
        }

    }
}
