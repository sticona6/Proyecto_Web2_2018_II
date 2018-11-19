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
            return View(datosmedicos.Listar());
        }

        public ActionResult Ver(int id)
        {
            return View(datosmedicos.Obtener(id));
        }

        public ActionResult AgregarEditar(int id = 0)
        {
            ViewBag.ninio = ninio.Listar();

            return View(
                id == 0 ? new DatosMedicos() //agregar un nuevo objeto
                : datosmedicos.Obtener(id)
                );
        }

        public ActionResult Guardar(DatosMedicos datosmedicos)
        {
            if (ModelState.IsValid)
            {
                datosmedicos.Guardar();
                return Redirect("~/DatosMedicos");
            }
            else
            {
                return View("~/Views/DatosMedicos/AgregarEditar.cshtml", datosmedicos);
            }
        }

        public ActionResult Eliminar(int id)
        {
            datosmedicos.id = id;
            datosmedicos.Eliminar();
            return Redirect("~/DatosMedicos");
        }
    }
}