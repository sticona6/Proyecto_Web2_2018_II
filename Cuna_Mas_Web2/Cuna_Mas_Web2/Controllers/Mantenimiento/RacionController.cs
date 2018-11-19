using System.Web.Mvc;
using Cuna_Mas_Web2.Models;
using Cuna_Mas_Web2.Filters;

namespace Cuna_Mas_Web2.Controllers.Mantenimiento.Madre
{
    public class RacionController : Controller
    {
        // GET: Racion
        private Racion objracion = new Racion();
        private Ninio ovjninio = new Ninio();

        public ActionResult Index()
        {
            return View(objracion.Listar());
        }

        public ActionResult Ver(int id)
        {
            return View(objracion.Obtener(id));
        }
    }
}