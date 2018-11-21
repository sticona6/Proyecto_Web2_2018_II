using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Cuna_Mas_Web2.Models;
using Cuna_Mas_Web2.Filters;

namespace Cuna_Mas_Web2.Controllers.Inicio
{
    public class Madre_FamiliaController : Controller
    {
        Cuna_Mas_Web2.Models.Madre usuario = new Cuna_Mas_Web2.Models.Madre().Obtener(Cuna_Mas_Web2.Models.SessionHelper.GetUser());

        private Madre madre = new Madre();
        private Padre padre = new Padre();
        private Reunion reunion = new Reunion();

        // GET: Madre_Familia
        public ActionResult Index()
        {
            string vComite = "";

            vComite = usuario.comite;
            
            ViewBag.reunion = reunion.Listar();
            ViewBag.padre = padre.ListarPadre(vComite);
            return View();
        }
    }
}