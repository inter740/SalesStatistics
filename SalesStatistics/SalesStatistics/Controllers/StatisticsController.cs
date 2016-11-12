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

            return View("StatisticsIndex");
        }


        [HttpPost]
        public JsonResult ReturnPerMonth(DtoBestseller dto)
        {
            var user = Helpers.AuthHelper.GetUser(HttpContext);
            var query = _service.Get<Bestseller>().Where(x => x.Date.Month == dto.Month && x.UserId == user.Id);
            var hits = CastBestsellerToDto.BestsellersListDto(query);

            return Json(hits);
        }


        [HttpPost]
        public JsonResult ReturnBestsellersForPeriod(DtoBestseller dto)
        {
            var user = Helpers.AuthHelper.GetUser(HttpContext);
            var query = _service.Get<Bestseller>().Where(x => (x.Date.Month >= dto.StartMonth && x.Date.Month <= dto.EndMonth && x.UserId == user.Id));
            var hits = CastBestsellerToDto.BestsellersListDto(query);
            return Json(hits);
        }

        [HttpPost]
        public JsonResult ReturnAppliancesesForMonth(DtoAppliances dto)
        {
            var user = Helpers.AuthHelper.GetUser(HttpContext);
            var query = _service.Get<Appliances>().Where(x => x.Date.Month == dto.Month && x.UserId == user.Id);
            var appli = CastBestsellerToDto.AppliancesesListDto(query);

            return Json(appli);
        }

        [HttpPost]
        public JsonResult ReturnAppliancesesForPeriod(DtoAppliances dto)
        {
            var user = Helpers.AuthHelper.GetUser(HttpContext);
            var query = _service.Get<Appliances>().Where(x => (x.Date.Month >= dto.StartMonth && x.Date.Month <= dto.EndMonth && x.UserId == user.Id));
            var appli = CastBestsellerToDto.AppliancesesListDto(query);

            return Json(appli);
        }


        [HttpPost]
        public JsonResult ReturnSimForMonth(DtoSim dto)
        {
            var user = Helpers.AuthHelper.GetUser(HttpContext);
            var query = _service.Get<SimCard>().Where(x => x.Date.Month == dto.Month && x.UserId == user.Id);
            var sim = CastBestsellerToDto.SimListDto(query);

            return Json(sim);
        }

        //TODO all under this
        [HttpPost]
        public JsonResult ReturnSimForMonthForOperator(DtoSim dto)
        {
            var user = Helpers.AuthHelper.GetUser(HttpContext);
            var query = _service.Get<SimCard>().Where(x => (x.Date.Month == dto.Month && x.Operator.ToString() == dto.Operator && x.UserId == user.Id));
            var sim = CastBestsellerToDto.SimListDto(query);

            return Json(sim);
        }

        [HttpPost]
        public JsonResult ReturnSimForPeriod(DtoSim dto)
        {

            var user = Helpers.AuthHelper.GetUser(HttpContext);
            var query = _service.Get<SimCard>().Where(x => x.Date.Month >= dto.StartMonth && x.Date.Month <= dto.EndMonth && x.UserId == user.Id);
            var sim = CastBestsellerToDto.SimListDto(query);

            return Json(sim);
        }

        [HttpPost]
        public JsonResult ReturnSimForPeriodForOperator(DtoSim dto)
        {
            var user = Helpers.AuthHelper.GetUser(HttpContext);
            var query = _service.Get<SimCard>().Where(x => (x.Date.Month >= dto.StartMonth && x.Date.Month <= dto.EndMonth && x.Operator.ToString() == dto.Operator && x.UserId == user.Id));
            var sim = CastBestsellerToDto.SimListDto(query);

            return Json(sim);
        }


    }
}