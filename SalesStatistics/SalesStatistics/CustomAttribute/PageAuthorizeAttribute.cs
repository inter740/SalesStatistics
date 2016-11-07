using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SalesStatistics.Data;
using SalesStatistics.Data.Entities;

namespace SalesStatistics.CustomAttribute
{
    public class PageAuthorizeAttribute : AuthorizeAttribute
    {
        public string UserRoles { get; set; }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var authCooke = httpContext.Request.Cookies["__AUTH"];

            if (authCooke != null)
            {
                User user = ServiceToWorkWithUsers.GetUserByCookeis(authCooke.Value);

                if (user!=null)
                {
                    return UserRoles.Split(',').Any(r => r.Trim().ToLower() == user.Role.RoleName.Trim().ToLower());
                }
                return false;
            }

            return false;
        }
    }
}