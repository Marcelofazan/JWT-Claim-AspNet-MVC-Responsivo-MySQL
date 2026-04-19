using ERPSimplesLTE.Controllers;
using ERPSimplesLTE.Filters;
using ERPSimplesLTE.Helpers;
using System.Security.Claims;
using System.Web.Mvc;
using System.Web.Razor.Tokenizer;

namespace TESTE_LTE.Controllers
{
    public class HomeController : BaseController
    {
        [JwtAuthentication]
        [ERPSimplesLTE.AuthorizeAttribute(ClaimType = ClaimTypes.Role, ClaimValue = Constants.UserRoles.Admin + "," + Constants.UserRoles.User)]
        public ActionResult Inicio()
        {
            return View();
        }

        [JwtAuthentication]
        [ERPSimplesLTE.AuthorizeAttribute(ClaimType = ClaimTypes.Role, ClaimValue = Constants.UserRoles.Admin + "," + Constants.UserRoles.User)]
        public ActionResult About()
        {
            return View();
        }

        [JwtAuthentication]
        [ERPSimplesLTE.AuthorizeAttribute(ClaimType = ClaimTypes.Role, ClaimValue = Constants.UserRoles.Admin + "," + Constants.UserRoles.User)]
        public ActionResult Contato()
        {
            return View();
        }

    }
}