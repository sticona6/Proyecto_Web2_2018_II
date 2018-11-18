using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Cuna_Mas_Web2.Models;
using Cuna_Mas_Web2.Filters;

namespace Cuna_Mas_Web2.Controllers.Mantenimiento
{
    public class ReunionController : Controller
    {
        private Reunion reunion = new Reunion();
        private Madre madre = new Madre();
        //GET: Reunion
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Ver(int id)
        {
            return View(reunion.Obtener(id));
        }

        public ActionResult AgregarEditar(int id = 0)
        {
            ViewBag.madre = madre.ListarCuidadora();

            return View(
                id == 0 ? new Reunion()
                : reunion.Obtener(id)
                );
        }

        public ActionResult Guardar(Reunion reunion)
        {
            if (ModelState.IsValid)
            {
                reunion.Guardar();
                return Redirect("~/Reunion");
            }
            else
            {
                return View("~/Views/Reunion/AgregarEditar.cshtml", reunion);
            }
        }

        public ActionResult Eliminar(int id)
        {
            reunion.id = id;
            reunion.Eliminar();
            return Redirect("~/Reunion");
        }
    }
}