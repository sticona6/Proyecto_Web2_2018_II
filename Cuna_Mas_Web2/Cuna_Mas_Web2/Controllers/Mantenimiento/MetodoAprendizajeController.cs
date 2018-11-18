using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Cuna_Mas_Web2.Models;
using Cuna_Mas_Web2.Filters;

namespace Cuna_Mas_Web2.Controllers.Mantenimiento
{
    public class MetodoAprendizajeController : Controller
    {
        private MetodoAprendizaje metodo = new MetodoAprendizaje();
        // GET: MetodoAprendizaje
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Ver(int id)
        {
            return View(metodo.Obtener(id));
        }
        public ActionResult AgregarEditar(int id = 0)
        {
            return View(
                id == 0 ? new MetodoAprendizaje() //agregar un nuevo objeto
                : metodo.Obtener(id)
                );
        }
        public ActionResult Guardar(MetodoAprendizaje metodo)
        {
            if (ModelState.IsValid)
            {
                metodo.Guardar();
                return Redirect("~/MetodoAprendizaje");
            }
            else
            {
                return View("~/Views/MetodoAprendizaje/AgregarEditar.cshtml", metodo);
            }
        }
        public ActionResult Eliminar(int id)
        {
            metodo.id = id;
            metodo.Eliminar();
            return Redirect("~/MetodoAprendizaje");
        }
    }
}