using System.Web.Mvc;
using Cuna_Mas_Web2.Models;
using Cuna_Mas_Web2.Filters;

namespace Cuna_Mas_Web2.Controllers.Mantenimiento.Madre
{
    public class ObservacionController : Controller
    {
        private Observacion observacion = new Observacion();
        private Models.Madre madre = new Models.Madre();

        // GET: Observacion
        public ActionResult Index()
        {
            return View(observacion.Listar());
        }
        public ActionResult Ver(int id)
        {
            return View(observacion.Obtener(id));
        }

        public ActionResult AgregarEditar(int id = 0)
        {
            ViewBag.madre = madre.Listar();

            return View(
                id == 0 ? new Observacion() //agregar un nuevo objeto
                    : observacion.Obtener(id)
            );
        }

        public ActionResult Guardar(Observacion observacion)
        {
            if (ModelState.IsValid)
            {
                observacion.Guardar();
                return Redirect("~/Observacion");
            }
            else
            {
                return View("~/Views/Observacion/AgregarEditar.cshtml", observacion);
            }
        }

        public ActionResult Eliminar(int id)
        {
            observacion.id = id;
            observacion.Eliminar();
            return Redirect("~/Observacion");
        }
    }
}