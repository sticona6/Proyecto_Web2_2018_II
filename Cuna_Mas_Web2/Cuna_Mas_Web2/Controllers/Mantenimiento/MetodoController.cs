using System.Web.Mvc;
using Cuna_Mas_Web2.Models;
using Cuna_Mas_Web2.Filters;

namespace Cuna_Mas_Web2.Controllers.Mantenimiento.Madre
{
    public class MetodoController : Controller
    {
        // GET: Metodo
        private MetodoAprendizaje objmetodo = new MetodoAprendizaje();

        public ActionResult Index()
        {
            return View(objmetodo.Listar());
        }

        public ActionResult Ver(int id)
        {
            return View(objmetodo.Obtener(id));
        }

        public ActionResult AgregarEditar(int id = 0)
        {
            return View(
                id == 0 ? new MetodoAprendizaje() //agregar un nuevo objeto
                    : objmetodo.Obtener(id)
            );
        }

        public ActionResult Guardar(MetodoAprendizaje metod)
        {
            if (ModelState.IsValid)
            {
                metod.Guardar();
                return Redirect("~/Metodo");
            }
            else
            {
                return View("~/Views/Metodo/AgregarEditar.cshtml", metod);
            }
        }

        public ActionResult Eliminar(int id)
        {
            objmetodo.id = id;
            objmetodo.Eliminar();
            return Redirect("~/Metodo/Index");
        }
    }
}