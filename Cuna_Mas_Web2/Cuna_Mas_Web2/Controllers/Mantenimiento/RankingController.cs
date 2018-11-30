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
        //public ActionResult Index()
        //{
        //    return View(ranking.Listar());
        //}
        
        public ActionResult AgregarEditar(int id = 0)
        {
            ViewBag.madre = madre.Listar();

            return View(new Ranking());//agregar un nuevo objeto);
        }

        public ActionResult Guardar(Ranking rankModel)
        {
            if (ModelState.IsValid)
            {
                Ranking rankAux = new Ranking().ObtenerPadreRanking(rankModel.fk_id_padre);
                if (rankAux != null)
                {
                    rankModel.id = rankAux.id;
                    rankModel.Guardar();
                }
                else
                {
                    rankModel.Guardar();
                }

                return Redirect("~/Padre");
            }
            else
            {
                return Redirect("~/Ninio");
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