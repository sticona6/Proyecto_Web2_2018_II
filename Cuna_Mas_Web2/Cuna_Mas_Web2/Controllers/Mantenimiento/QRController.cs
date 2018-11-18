using System.Web.Mvc;
using Cuna_Mas_Web2.Models;
using Cuna_Mas_Web2.Filters;

namespace Cuna_Mas_Web2.Controllers.Mantenimiento.Madre
{
    public class QRController : Controller
    {
        // GET: QR
        private Racion objracion = new Racion();

        public ActionResult Index()
        {
            return View(objracion.Listar());
        }

        public ActionResult generarQR()
        {
            return View();
        }
    }
}