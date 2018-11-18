using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Cuna_Mas_Web2.Models;
using Cuna_Mas_Web2.Filters;

namespace Cuna_Mas_Web2.Controllers.Mantenimiento
{
    public class RacionController : Controller
    {
        private Racion racion = new Racion();
        private Ninio ninio = new Ninio();
        // GET: Racion
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Ver(int id)
        {
            return View(racion.Obtener(id));
        }

        public ActionResult AgregarEditar(int id = 0)
        {
            ViewBag.madre = ninio.Listar();

            return View(
                id == 0 ? new Racion() //agregar un nuevo objeto
                : racion.Obtener(id)
                );
        }

        public ActionResult Guardar(Racion racion)
        {
            if (ModelState.IsValid)
            {
                racion.Guardar();
                return Redirect("~/Racion");
            }
            else
            {
                return View("~/Views/Racion/AgregarEditar.cshtml", racion);
            }
        }

        public ActionResult Eliminar(int id)
        {
            racion.id = id;
            racion.Eliminar();
            return Redirect("~/Racion");
        }
    }
}