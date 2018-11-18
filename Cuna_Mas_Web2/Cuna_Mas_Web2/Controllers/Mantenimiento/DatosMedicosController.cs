using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Cuna_Mas_Web2.Models;
using Cuna_Mas_Web2.Filters;

namespace Cuna_Mas_Web2.Controllers.Mantenimiento
{
    public class DatosMedicosController : Controller
    {
        private DatosMedicos datosmedicos = new DatosMedicos();
        private Ninio ninio = new Ninio();
        // GET: DatosMedicos
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Ver(int id)
        {
            return View(ninio.Obtener(id));
        }

        public ActionResult AgregarEditar(int id = 0)
        {
            ViewBag.madre = ninio.Listar();

            return View(
                id == 0 ? new Ninio() //agregar un nuevo objeto
                : ninio.Obtener(id)
                );
        }

        public ActionResult Guardar(Reunion reunion)
        {
            if (ModelState.IsValid)
            {
                reunion.Guardar();
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