using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Cuna_Mas_Web2.Models;
using Cuna_Mas_Web2.Filters;

namespace Cuna_Mas_Web2.Controllers.Mantenimiento
{
    public class RankingController : Controller
    {
        private Ranking ranking = new Ranking();
        private Models.Madre madre = new Models.Madre();
        // GET: Ranking
        public ActionResult Index()
        {
            return View(ranking.Listar());
        }

        public ActionResult Ver(int id)
        {
            return View(ranking.Obtener(id));
        }

        public ActionResult AgregarEditar(int id = 0)
        {
            ViewBag.madre = madre.Listar();
            
            return View(
                id == 0 ? new Ranking() //agregar un nuevo objeto
                : ranking.Obtener(id)
                );
        }

        public ActionResult Guardar(Ranking ranking)
        {
            if (ModelState.IsValid)
            {
                ranking.Guardar();
                return Redirect("~/Ranking");
            }
            else
            {
                return View("~/Views/Ranking/AgregarEditar.cshtml", ranking);
            }
        }

        public ActionResult Eliminar(int id)
        {
            ranking.id = id;
            ranking.Eliminar();
            return Redirect("~/Ranking");
        }
    }
}