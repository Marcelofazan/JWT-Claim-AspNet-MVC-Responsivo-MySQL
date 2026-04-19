using ERPSimplesLTE.Helpers;
using ERPSimplesLTE.Models;
using System.Linq;
using System.Security.Claims;
using System.Web.Mvc;
using System.Web.Routing;

namespace ERPSimplesLTE.Controllers
{
    public class BaseController : Controller
    {
        protected internal Usuario Usuario { get; private set; }

        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);
            var user = User as ClaimsPrincipal;
            if (user != null)
            {
                var claims = user.Claims.ToList();
                var sessionClaim = claims.FirstOrDefault(o => o.Type == Constants.UserSession);
                if (sessionClaim != null)
                {
                    Usuario = sessionClaim.Value.ToObject<Usuario>();
                }
            }
        }
    }
}
