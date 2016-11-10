using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using SalesStatistics.BL.castToDto;
using SalesStatistics.CustomAttribute;
using SalesStatistics.Data;
using SalesStatistics.Data.dto;
using SalesStatistics.Data.Entities;
using SalesStatistics.Models;

namespace SalesStatistics.Controllers
{
    [PageAuthorize(UserRoles = "User,Admin")]
    public class StatisticsController : Controller
    {
        private ServiceToWorkWithEntityFromDb _service = new ServiceToWorkWithEntityFromDb();


        // GET: Statistics
        [AllowAnonymous]
        public ActionResult Index()
        {
            if (!Helpers.AuthHelper.IsAuthenticated(HttpContext))
            {
                return RedirectToAction("Login", "Account");
            }
            var user = Helpers.AuthHelper.GetUser(HttpContext);

            ModelForStatistics model = new ModelForStatistics(user);


            return View("StatisticsIndex", model);
        }

        [HttpPost]
        public JsonResult ReturnPerMonth(int month)
        {
            var user = Helpers.AuthHelper.GetUser(HttpContext);
            var hits2 = _service.Get<Bestseller>().Where(x => x.Date.Month == month && x.UserId == user.Id);
            var hits = CastBestsellerToDto.BestsellersListDto(hits2);

            return Json(hits);
        }

        //[HttpPost]
        //public JsonResult ReturnHitsPerPeriod(int startingMonth, int finalMonth)
        //{
        //    var numberOf = _service.Get<Bestseller>().Where(x => (x.Date.Month >= startingMonth && x.Date.Month <= finalMonth));

        //    return Json(numberOf);
        //}

        //TODO this. Not come inquiry from ajax
        [HttpPost]
        public JsonResult ReturnHitsPerPeriod(DtoUser dto)
        {
            var numberOf = _service.Get<Bestseller>().Where(x => (x.Date.Month >= dto.StartMonth && x.Date.Month <= dto.EndMonth));

            return Json(numberOf);
        }

        [HttpPost]
        public JsonResult ReturnAppliancesesPerMonth(int month)
        {
            var numberOf = _service.Get<Appliances>().Where(x => x.Date.Month == month);

            return Json(numberOf);
        }

        [HttpPost]
        public JsonResult ReturnAppliancesesPerPeriod(int startingMonth, int finalMonth)
        {
            var numberOf = _service.Get<Appliances>().Where(x => (x.Date.Month >= startingMonth && x.Date.Month <= finalMonth));

            return Json(numberOf);
        }

        [HttpPost]
        public JsonResult ReturnSimPerMonth(int month)
        {
            var numberOf = _service.Get<SimCard>().Where(x => x.Date.Month == month);

            return Json(numberOf);
        }

        [HttpPost]
        public JsonResult ReturnSimPerMonthByOperator(int month, string operatorName)
        {
            var numberOf = _service.Get<SimCard>().Where(x => (x.Date.Month == month && x.Operator.ToString() == operatorName));

            return Json(numberOf);
        }

        [HttpPost]
        public JsonResult ReturnSimPerPeriod(int startingMonth, int finalMonth)
        {
            var numberOf = _service.Get<SimCard>().Where(x => (x.Date.Month >= startingMonth && x.Date.Month <= finalMonth));

            return Json(numberOf);
        }

        [HttpPost]
        public JsonResult ReturnSimPerPeriodByOperator(int startingMonth, int finalMonth, string operatorName)
        {
            var numberOf = _service.Get<SimCard>().Where(x => (x.Date.Month >= startingMonth && x.Date.Month <= finalMonth && x.Operator.ToString() == operatorName));

            return Json(numberOf);
        }


    }
}