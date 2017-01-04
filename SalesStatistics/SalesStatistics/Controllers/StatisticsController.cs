using System.Linq;
using System.Web.Mvc;
using SalesStatistics.BL.castToDto;
using SalesStatistics.CustomAttribute;
using SalesStatistics.Data;
using SalesStatistics.Data.dto;
using SalesStatistics.Data.Entities;

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
            if (!BL.Helpers.AuthHelper.IsAuthenticated(HttpContext))
            {
                return RedirectToAction("Login", "Account");
            }

            return View("StatisticsIndex");
        }


        [HttpPost]
        public JsonResult ReturnBestsellersPerMonth(DtoBestseller dto)
        {
            var user = BL.Helpers.AuthHelper.GetUser(HttpContext);
            var query = _service.Get<Bestseller>().Where(x => (x.Date.Month == dto.Month && x.Date.Year==dto.Year) && x.UserId == user.Id);
            var hits = CastToDto.BestsellersListDto(query);

            return Json(hits);
        }


        [HttpPost]
        public JsonResult ReturnBestsellersForPeriod(DtoBestseller dto)
        {
            var user = BL.Helpers.AuthHelper.GetUser(HttpContext);
            var query = _service.Get<Bestseller>().Where(x => (x.Date.Month >= dto.StartMonth && x.Date.Month <= dto.EndMonth && x.Date.Year == dto.Year) && x.UserId == user.Id);
            var hits = CastToDto.BestsellersListDto(query);
            return Json(hits);
        }

        [HttpPost]
        public JsonResult ReturnAppliancesesForMonth(DtoAppliances dto)
        {
            var user = BL.Helpers.AuthHelper.GetUser(HttpContext);
            var query = _service.Get<Appliances>().Where(x => x.Date.Month == dto.Month && x.UserId == user.Id);
            var appli = CastToDto.AppliancesesListDto(query);

            return Json(appli);
        }

        [HttpPost]
        public JsonResult ReturnAppliancesesForPeriod(DtoAppliances dto)
        {
            var user = BL.Helpers.AuthHelper.GetUser(HttpContext);
            var query = _service.Get<Appliances>().Where(x => (x.Date.Month >= dto.StartMonth && x.Date.Month <= dto.EndMonth && x.UserId == user.Id));
            var appli = CastToDto.AppliancesesListDto(query);

            return Json(appli);
        }


        [HttpPost]
        public JsonResult ReturnSimForMonth(DtoSim dto)
        {
            var user = BL.Helpers.AuthHelper.GetUser(HttpContext);
            var query = _service.Get<SimCard>().Where(x => x.Date.Month == dto.Month && x.UserId == user.Id);
            var sim = CastToDto.SimListDto(query);

            return Json(sim);
        }


        [HttpPost]
        public JsonResult ReturnSimForMonthForOperator(DtoSim dto)
        {
            var user = BL.Helpers.AuthHelper.GetUser(HttpContext);
            var query = _service.Get<SimCard>().Where(x => (x.Date.Month == dto.Month && x.Operator.ToString() == dto.Operator && x.UserId == user.Id));
            var sim = CastToDto.SimListDto(query);

            return Json(sim);
        }

        [HttpPost]
        public JsonResult ReturnSimForPeriod(DtoSim dto)
        {

            var user = BL.Helpers.AuthHelper.GetUser(HttpContext);
            var query = _service.Get<SimCard>().Where(x => x.Date.Month >= dto.StartMonth && x.Date.Month <= dto.EndMonth && x.UserId == user.Id);
            var sim = CastToDto.SimListDto(query);

            return Json(sim);
        }

        [HttpPost]
        public JsonResult ReturnSimForPeriodForOperator(DtoSim dto)
        {
            var user = BL.Helpers.AuthHelper.GetUser(HttpContext);
            var query = _service.Get<SimCard>().Where(x => (x.Date.Month >= dto.StartMonth && x.Date.Month <= dto.EndMonth && x.Operator.ToString() == dto.Operator && x.UserId == user.Id));
            var sim = CastToDto.SimListDto(query);

            return Json(sim);
        }


    }
}