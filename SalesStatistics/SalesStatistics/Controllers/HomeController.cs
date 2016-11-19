using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SalesStatistics.CustomAttribute;
using SalesStatistics.Data;
using SalesStatistics.Data.dto;
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
            var user = BL.Helpers.AuthHelper.GetUser(HttpContext);

            ModelForHome model = new ModelForHome(user);

            if (!BL.Helpers.AuthHelper.IsAuthenticated(HttpContext))
            {
                return RedirectToAction("Login", "Account");
            }
            return View(model);
        }

        [HttpPost]
        public void AddBestsellers(Bestseller bestseller)
        {
            bestseller.UserId = GetUserId();
            _service.AddBest(bestseller);
        }

        [HttpPost]
        public void AddAppliances(Appliances appliances)
        {
            appliances.UserId = GetUserId();
            _service.AddAppliances(appliances);
        }

        [HttpPost]
        public void AddInsurance(Insurance insurance)
        {
            insurance.UserId = GetUserId();
            _service.AddInsurance(insurance);
        }

        [HttpPost]
        public void AddSimCard(SimCard simCard)
        {
            simCard.UserId = GetUserId();
            _service.AddSimCard(simCard);
        }

        [HttpPost]
        [AllowAnonymous]
        public string GetUserName()
        {
            var user = BL.Helpers.AuthHelper.GetUser(HttpContext);

            ModelForHome model = new ModelForHome(user);

            return model.UserName;
        }

        private int GetUserId()
        {
            var user = BL.Helpers.AuthHelper.GetUser(HttpContext);
            return user.Id;
        }

    }
}