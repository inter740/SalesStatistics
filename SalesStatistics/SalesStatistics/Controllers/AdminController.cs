using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SalesStatistics.CustomAttribute;

namespace SalesStatistics.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        [PageAuthorize(UserRoles = "Admin")]
        public ActionResult Admin()
        {
            return View();
        }
    }
}