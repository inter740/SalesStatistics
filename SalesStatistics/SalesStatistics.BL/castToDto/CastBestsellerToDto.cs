using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesStatistics.Data.dto;
using SalesStatistics.Data.Entities;

namespace SalesStatistics.BL.castToDto
{
    public static class CastBestsellerToDto
    {
        public static List<DtoBestseller> BestsellersListDto(IEnumerable<Bestseller> best)
        {
            List<DtoBestseller> dtoList = new List<DtoBestseller>();
            

            foreach (var b in best)
            {
                DtoBestseller dto = new DtoBestseller(b);

                dtoList.Add(dto);
            }

            return dtoList;
        }
    }
}
