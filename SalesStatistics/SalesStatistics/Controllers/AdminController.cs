using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SalesStatistics.BL.castToDto;
using SalesStatistics.CustomAttribute;
using SalesStatistics.Data;
using SalesStatistics.Data.dto;
using SalesStatistics.Data.Entities;
using SalesStatistics.Models;

namespace SalesStatistics.Controllers
{
    [PageAuthorize(UserRoles = "Admin")]
    public class AdminController : Controller
    {
        // GET: Admin
        private ServiceToWorkWithEntityFromDb _service = new ServiceToWorkWithEntityFromDb();

        public ActionResult Admin()
        {
            var user = BL.Helpers.AuthHelper.GetUser(HttpContext);
            ModelGetStatisticsData model = new ModelGetStatisticsData(user);
            return View(model);
        }

        [HttpPost]
        public JsonResult GetAllUsers()
        {
            var users = _service.Get<User>();
            var userList = CastToDto.UsersList(users);
            return Json(userList);
        }

        [HttpPost]
        public void ChangeUser(DtoUser user)
        {
            
        }
    }
}