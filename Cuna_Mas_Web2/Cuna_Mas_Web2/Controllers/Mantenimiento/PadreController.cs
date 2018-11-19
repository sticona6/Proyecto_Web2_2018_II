using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Cuna_Mas_Web2.Models;
using Cuna_Mas_Web2.Filters;

namespace Cuna_Mas_Web2.Controllers.Mantenimiento
{
    public class PadreController : Controller
    {
        private Padre padre = new Padre();
        private Usuario usuario = new Usuario();
        private Reunion reunion = new Reunion();
        private Models.Madre madre = new Models.Madre();
        // GET: Padre
        public ActionResult Index()
        {
            return View(padre.Listar());
        }

        public ActionResult Ver(int id)
        {
            return View(padre.Obtener(id));
        }

        public ActionResult AgregarEditar(int id = 0)
        {
            ViewBag.madre = madre.Listar();
            ViewBag.usuario = usuario.Listar();
            ViewBag.reunion = reunion.Listar();
            return View(
                id == 0 ? new Padre() //agregar un nuevo objeto
                : padre.Obtener(id)
                );
        }

        public ActionResult Guardar(Padre padre)
        {
            if (ModelState.IsValid)
            {
                padre.Guardar();
                return Redirect("~/Padre");
            }
            else
            {
                return View("~/Views/Padre/AgregarEditar.cshtml", padre);
            }
        }

        public ActionResult Eliminar(int id)
        {
            padre.id = id;
            padre.Eliminar();
            return Redirect("~/Padre");
        }
    }

}