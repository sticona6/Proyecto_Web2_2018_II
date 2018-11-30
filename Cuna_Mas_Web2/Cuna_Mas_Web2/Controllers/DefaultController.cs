using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Cuna_Mas_Web2.Models;

namespace Cuna_Mas_Web2.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        

        public ActionResult Index()
        {
            Usuario usu = new Usuario().Obtener(SessionHelper.GetUser());

            if (usu.tipo.Contains("Jefa"))
            {
                return Redirect("~/Visualizar/MadreJefa");
            }
            else
            {
                return View();
            }
            
        }
    }
}