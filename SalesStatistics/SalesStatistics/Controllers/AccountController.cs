using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SalesStatistics.Data;
using SalesStatistics.Data.Entities;
using SalesStatistics.Models;
using SalesStatistics.BL;

namespace SalesStatistics.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Registration()
        {
            if (BL.Helpers.AuthHelper.IsAuthenticated(HttpContext))
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }


        [HttpPost]
        public ActionResult Registration(User user)
        {
            if (!BL.Helpers.AuthHelper.IsAuthenticated(HttpContext))
            {
                user.RoleId = 2;
                user.Cookies = Guid.NewGuid().ToString(); // cookie для авторизации
                user.Password = BL.Helpers.SecurityHelper.Hash(user.Password);

                if (!ServiceToWorkWithUsers.FindUser(user.LastName))
                {
                    return RedirectToAction("Registration", "Account");
                }

                ServiceToWorkWithUsers.AddUser(user);

                AutorizeModel autorize = new AutorizeModel() { LastName = user.LastName, Password = user.Password };
                LoginAfterRegistration(autorize);
            }

            return RedirectToAction("Login", "Account");
        }

        public ActionResult Login()
        {
            if (BL.Helpers.AuthHelper.IsAuthenticated(HttpContext))
            {
                return RedirectToAction("Index", "Home");
            }
            return View("Login");
        }

        [HttpPost]
        public ActionResult Login(AutorizeModel autorize)
        {
            User user = ServiceToWorkWithUsers.GetUser(autorize.LastName,
                    BL.Helpers.SecurityHelper.Hash(autorize.Password));
            if (user != null)
            {
                BL.Helpers.AuthHelper.LogInUser(HttpContext, user.Cookies);

                switch (user.Role.RoleName)
                {
                    case "Admin":
                        return RedirectToAction("Admin", "Admin");
                    case "User":
                        return RedirectToAction("Index", "Home");
                }
            }
            return RedirectToAction("Login", "Account");
        }

        private ActionResult LoginAfterRegistration(AutorizeModel autorize)
        {
            User user = ServiceToWorkWithUsers.GetUser(autorize.LastName, autorize.Password);

            if (user != null)
            {
                BL.Helpers.AuthHelper.LogInUser(HttpContext, user.Cookies);

                switch (user.Role.RoleName)
                {
                    case "Admin":
                        return RedirectToAction("Admin", "Admin");
                    case "User":
                        return RedirectToAction("Index", "Home");
                }
            }
            return RedirectToAction("Login", "Account");
        }

        public ActionResult LogOff()
        {
            BL.Helpers.AuthHelper.LogOffUser(HttpContext);

            return RedirectToAction("Login", "Account");
        }
    }
}