using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Cuna_Mas_Web2.Models;
using Cuna_Mas_Web2.Filters;

namespace Cuna_Mas_Web2.Controllers.Mantenimiento
{
    public class MadreController : Controller
    {
        private Models.Madre madre = new Models.Madre();
        private Usuario usuario = new Usuario();
        // GET: Madre
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Ver(int id)
        {
            return View(madre.Obtener(id));
        }

        public ActionResult AgregarEditar(int id = 0)
        {
            ViewBag.usuario = usuario.Listar();

            return View(
                id == 0 ? new Models.Madre()
                : madre.Obtener(id)
                );
        }

        public ActionResult Guardar(Models.Madre madre)
        {
            if (ModelState.IsValid)
            {
                madre.Guardar();
                return Redirect("~/Madre");
            }
            else
            {
                return View("~/Views/Madre/AgregarEditar.cshtml", madre);
            }
        }

        public ActionResult Eliminar(int id)
        {
            madre.id = id;
            madre.Eliminar();
            return Redirect("~/Madre");
        }
    }
}