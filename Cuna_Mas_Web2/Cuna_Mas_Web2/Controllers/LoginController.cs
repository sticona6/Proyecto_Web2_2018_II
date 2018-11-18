using System.Web.Mvc;

using Cuna_Mas_Web2.Models;
using Cuna_Mas_Web2.Filters;

namespace Cuna_Mas_Web2.Controllers
{
    public class LoginController : Controller
    {
        private Usuario usuario = new Usuario();

        // GET: Login
        [NoLogin]
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Validar(string Usuario, string Password)
        {
            var rm = usuario.ValidarLogin(Usuario, Password);

            if (rm.response)
            {
                rm.href = Url.Content("/Default");
            }
            else
            {
                rm.href = Url.Content("/Login");
            }
            return Json(rm);
        }

        public ActionResult logout()
        {
            SessionHelper.DestroyUserSession();
            return Redirect("~/Login");
        }

        public ActionResult CrearUsuario()
        {
            return View();
        }
    }
}