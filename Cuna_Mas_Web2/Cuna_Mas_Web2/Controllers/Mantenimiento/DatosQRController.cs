using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Cuna_Mas_Web2.Models;
using Cuna_Mas_Web2.Filters;
using Cuna_Mas_Web2.Helpers;
using System.Drawing.Imaging;

namespace Cuna_Mas_Web2.Controllers.Mantenimiento
{
    public class DatosQRController : Controller
    {
        private Ninio ninio = new Ninio();
        private DatosQR datosQR = new DatosQR();
        private Racion racion = new Racion();
        
        // GET: DatosQR
        public ActionResult Index()
        {
            ViewBag.ninios = ninio.Listar();
            ViewBag.raciones = racion.Listar();
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

        public ActionResult Guardar(int id = 0)
        {
           
            if (ModelState.IsValid)
            {
                Racion objracion = new Racion().Obtener(id);

                //Save QR code
                var QRHelper = new QRCodeHelper();
                var contenido = objracion.desayuno + ", " + objracion.refrigerio + ", " + objracion.almuerzo + ", " + objracion.postre;
                var codeImage = QRHelper.GenerateQRCode(contenido.ToString(), 250);
                codeImage.Save(Server.MapPath("~/Uploads/" + objracion.Ninio.nombre + ".png"), ImageFormat.Png);
            }
            return Redirect("~/Ninio");
        }

        public ActionResult Eliminar(int id)
        {
            datosQR.id = id;
            datosQR.Eliminar();
            return Redirect("~/DatosQR");
        }
    }
}