using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Cuna_Mas_Web2.Models;
using Cuna_Mas_Web2.Filters;

namespace Cuna_Mas_Web2.Controllers.Mantenimiento.Madre
{
    public class NinioController : Controller
    {
        private Ninio ninio = new Ninio();
        private MetodoAprendizaje metodo = new MetodoAprendizaje();
        private Padre padre = new Padre();
        private Models.Madre madre = new Models.Madre();

        // GET: Ninio
        public ActionResult Index()
        {
            return View(ninio.Listar());
        }

        public ActionResult Ver(int id)
        {
            return View(ninio.Obtener(id));
        }

        public ActionResult AgregarEditar(int id = 0)
        {
            ViewBag.madre = madre.Listar();
            ViewBag.padre = padre.Listar();
            ViewBag.metodo = metodo.Listar();
            return View(
                id == 0 ? new Ninio()
                : ninio.Obtener(id)
                );
        }

        public ActionResult Guardar(Ninio ninio)
        {
            if (ModelState.IsValid)
            {
                ninio.Guardar();
                return Redirect("~/Ninio");
            }
            else
            {
                return View("~/Views/Ninio/AgregarEditar.cshtml", ninio);
            }
        }

        public ActionResult Eliminar(int id)
        {
            ninio.id = id;
            ninio.Eliminar();
            return Redirect("~/Ninio");
        }
    }
}