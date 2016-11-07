using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SalesStatistics.CustomAttribute;
using SalesStatistics.Data.Entities;
using SalesStatistics.Models;

namespace SalesStatistics.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        [PageAuthorize(UserRoles = "User,Admin")]
        public ActionResult UserAccount()
        {

            User user = Helpers.AuthHelper.GetUser(HttpContext);
            ModelForHome model = new ModelForHome(user);
            return View("UserPage", model);
        }
    }
}