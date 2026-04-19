using Mysqlx.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERPSimplesLTE.Filters
{
    public class JwtAuthenticationAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var request = filterContext.HttpContext.Request;
            var token = request.Cookies["jwt"].Value;

            if (token != null)
            {
                var userName = Helpers.AuthenticationHelper.ValidateToken(token);
                if (userName == null)
                {
                    filterContext.Result = new HttpStatusCodeResult(401, "No Username found.");
                }
            }
            else
            {
                filterContext.Result = new HttpStatusCodeResult(401, "Token Null");
            }

            base.OnActionExecuting(filterContext);
        }
    }
}