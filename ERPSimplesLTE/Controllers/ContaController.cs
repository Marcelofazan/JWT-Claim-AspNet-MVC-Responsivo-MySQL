using ERPSimplesLTE.Aplicacao;
using ERPSimplesLTE.Filters;
using ERPSimplesLTE.Helpers;
using ERPSimplesLTE.Models;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Mysqlx.Session;
using System;
using System.Security.Claims;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace ERPSimplesLTE.Controllers
{
    public class ContaController : Controller
    {
        private readonly ContaAplicacao contaAplicacao;
        public ContaController()
        {
            contaAplicacao = new ContaAplicacao();
        }
        public ActionResult Index()
        {
            return RedirectToAction("Login", "Conta");
        }

        public ActionResult Login(AcessarViewModel vm, string returnUrl = default(string))
        {
            try
            {
                if (vm.Email != null && vm.Senha != null)
                {
                    var objusuario = contaAplicacao.ValidarLogin(vm.Email, vm.Senha);
                    if (objusuario == null)
                        return View();

                    var userSession = Authenticate(vm);

                    if (userSession != null)
                    {
                        var identity = new ClaimsIdentity(AuthenticationHelper.CreateClaim(objusuario,
                                                                Helpers.Constants.UserRoles.Admin,
                                                                Helpers.Constants.UserRoles.User),
                                                                DefaultAuthenticationTypes.ApplicationCookie
                                                                );
                        AuthenticationManager.SignIn(new AuthenticationProperties()
                        {
                            AllowRefresh = true,
                            IsPersistent = true,
                            ExpiresUtc = DateTime.UtcNow.AddHours(1)
                        }, identity);

                        if (!string.IsNullOrWhiteSpace(returnUrl) && Url.IsLocalUrl(returnUrl)) return Redirect(returnUrl);

                        var userPassword = objusuario.Senha;
                        var username = objusuario.Email;
                        if (userPassword.Equals(objusuario.Senha) && username.Equals(objusuario.Email))
                        {
                            var role = objusuario.Nome;
                            var jwtToken = AuthenticationHelper.GenerateJWTAuthetication(objusuario.Email, role);
                            var validUserName = AuthenticationHelper.ValidateToken(jwtToken);

                            if (string.IsNullOrEmpty(validUserName))
                            {
                                ModelState.AddModelError("", "Unauthorized login attempt ");

                                return View();
                            }

                            var cookie = new HttpCookie("jwt", jwtToken)
                            {
                                HttpOnly = true,
                                // Secure = true, // Uncomment this line if your application is running over HTTPS
                            };
                            Response.Cookies.Add(cookie);

                            return RedirectToAction("Inicio", "Home");
                        }
                    }
                }
            }
            catch (AuthenticationException e)
            {
                vm.MensagemErro = e.Message;
            }
            return View(vm);
        }

        public Usuario Authenticate(AcessarViewModel vm)
        {
            if (vm.Email == null && vm.Senha == null) throw new AuthenticationException("Falha no login. Endereço de e-mail ou senha incorretos");

            var objusuario = contaAplicacao.ValidarLogin(vm.Email, vm.Senha);
             
                return new Usuario
                {
                    Id = objusuario.Id,
                    Nome = objusuario.Nome
                };
        }

        public ActionResult EncerrarSessao()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie, DefaultAuthenticationTypes.ExternalCookie);
            return Redirect("~/");
        }

        private IAuthenticationManager AuthenticationManager
        {
            get { return HttpContext.GetOwinContext().Authentication; }
        }
    }
}