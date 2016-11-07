using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SalesStatistics.Data;
using SalesStatistics.Data.Entities;

namespace SalesStatistics.Models
{
    public class ModelForStatistics
    {
        ServiceToWorkWithEntityFromDb _service = new ServiceToWorkWithEntityFromDb();

        public IEnumerable<Bestseller> Bestsellers { get; set; }
        public IEnumerable<Appliances> Applianceses { get; set; }
        public IEnumerable<Insurance> Insurances { get; set; }
        public IEnumerable<SimCard> SimCards { get; set; }
        public int UserId { get; set; }


        public ModelForStatistics(User user)
        {
            Bestsellers = _service.Get<Bestseller>();
            Applianceses = _service.Get<Appliances>();
            Insurances = _service.Get<Insurance>();
            SimCards = _service.Get<SimCard>();
            UserId = user.Id;
        }
    }
}