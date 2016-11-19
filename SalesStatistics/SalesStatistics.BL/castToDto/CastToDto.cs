using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesStatistics.Data.dto;
using SalesStatistics.Data.Entities;

namespace SalesStatistics.BL.castToDto
{
    public static class CastToDto
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

        public static List<DtoAppliances> AppliancesesListDto(IEnumerable<Appliances> applianceses)
        {
            List<DtoAppliances> dtoList = new List<DtoAppliances>();


            foreach (var a in applianceses)
            {
                DtoAppliances dto = new DtoAppliances(a);

                dtoList.Add(dto);
            }

            return dtoList;
        }

        public static List<DtoSim> SimListDto(IEnumerable<SimCard> sim)
        {
            List<DtoSim> dtoList = new List<DtoSim>();


            foreach (var s in sim)
            {
                DtoSim dto = new DtoSim(s);

                dtoList.Add(dto);
            }

            return dtoList;
        }

        public static List<DtoUser> UsersList(IEnumerable<User> users)
        {
            List <DtoUser> dtoList= new List<DtoUser>();

            foreach (var u in users)
            {
                DtoUser dto = new DtoUser(u);
                dtoList.Add(dto);
            }

            return dtoList;
        } 
    }
}
