using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SalesStatistics.CustomAttribute;
using SalesStatistics.Data;
using SalesStatistics.Data.Entities;
using SalesStatistics.Models;

namespace SalesStatistics.Controllers
{
    [PageAuthorize(UserRoles = "User,Admin")]
    public class HomeController : Controller
    {

        ServiceToWorkWithEntityFromDb _service = new ServiceToWorkWithEntityFromDb();

        // GET: Home
        [AllowAnonymous]
        public ActionResult Index()
        {
            var user = Helpers.AuthHelper.GetUser(HttpContext);

            ModelForHome model = new ModelForHome(user);

            if (!Helpers.AuthHelper.IsAuthenticated(HttpContext))
            {
                return RedirectToAction("Login", "Account");
            }
            return View(model);
        }

        [HttpPost]
        public void AddBestsellers(Bestseller bestseller)
        {
            _service.AddBest(bestseller);
        }

        [HttpPost]
        public void AddAppliances(Appliances appliances)
        {
            _service.AddAppliances(appliances);
        }

        [HttpPost]
        public void AddInsurance(Insurance insurance)
        {
            _service.AddInsurance(insurance);
        }

        [HttpPost]
        public void AddSimCard(SimCard simCard)
        {
            _service.AddSimCard(simCard);
        }

        [HttpPost]
        public string GetUserName()
        {
            var user = Helpers.AuthHelper.GetUser(HttpContext);

            ModelForHome model = new ModelForHome(user);

            return model.UserName;
        }

        [HttpPost]
        public int GetUserId()
        {
            var user = Helpers.AuthHelper.GetUser(HttpContext);

            ModelForHome model = new ModelForHome(user);

            return model.UserId;
        }
    }
}