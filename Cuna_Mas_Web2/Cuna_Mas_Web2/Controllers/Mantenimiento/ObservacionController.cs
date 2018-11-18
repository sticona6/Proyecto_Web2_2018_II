using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Cuna_Mas_Web2.Models;
using Cuna_Mas_Web2.Filters;

namespace Cuna_Mas_Web2.Controllers.Mantenimiento
{
    public class ObservacionController : Controller
    {
        // GET: Observacion
        private Observacion observacion = new Observacion();
        private Cuna_Mas_Web2.Models.Madre madre = new Cuna_Mas_Web2.Models.Madre();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Ver(int id)
        {
            return View(observacion.Obtener(id));
        }

        public ActionResult AgregarEditar(int id = 0)
        {
            ViewBag.madre = madre.Listar();

            return View(
                id == 0 ? new Observacion() //agregar un nuevo objeto
                : observacion.Obtener(id)
                );
        }

        public ActionResult Guardar(Observacion observacion)
        {
            if (ModelState.IsValid)
            {
                observacion.Guardar();
                return Redirect("~/Observacion");
            }
            else
            {
                return View("~/Views/Observacion/AgregarEditar.cshtml", observacion);
            }
        }

        public ActionResult Eliminar(int id)
        {
            observacion.id = id;
            observacion.Eliminar();
            return Redirect("~/Observacion");
        }
    }
}