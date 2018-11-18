using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Cuna_Mas_Web2.Models;
using Cuna_Mas_Web2.Filters;

namespace Cuna_Mas_Web2.Controllers.Mantenimiento
{
    public class DatosQRController : Controller
    {
        private DatosQR datosQR = new DatosQR();
        private Racion racion = new Racion();
        // GET: DatosQR
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Ver(int id)
        {
            return View(datosQR.Obtener(id));
        }

        public ActionResult AgregarEditar(int id = 0)
        {
            ViewBag.madre = racion.Listar();

            return View(
                id == 0 ? new DatosQR()
                : datosQR.Obtener(id)
                );
        }

        public ActionResult Guardar(DatosQR datosQR)
        {
            if (ModelState.IsValid)
            {
                datosQR.Guardar();
                return Redirect("~/DatosQR");
            }
            else
            {
                return View("~/Views/DatosQR/AgregarEditar.cshtml", datosQR);
            }
        }

        public ActionResult Eliminar(int id)
        {
            datosQR.id = id;
            datosQR.Eliminar();
            return Redirect("~/DatosQR");
        }
    }
}