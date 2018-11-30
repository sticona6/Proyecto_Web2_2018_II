using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Cuna_Mas_Web2.Models;

namespace Cuna_Mas_Web2.Controllers.Inicio
{
    public class Padre_FamiliaController : Controller
    {
        // GET: Padre_Familia
        //usuario
        private Usuario usu = new Usuario().Obtener(SessionHelper.GetUser());

        private Padre papa = new Padre();
        private Ninio ninio = new Ninio();


        public ActionResult Index()
        {
            Padre padre = papa.ObtenerPapa(usu.id);

            List<Reunion> reuniones = new Reunion().Listar();

            List<Reunion> reunionPadre = new List<Reunion>();

            foreach (var item in reuniones)
            {
                if (item.id == padre.fk_id_reunion)
                {
                    reunionPadre.Add(item);
                }
            }
            
            

            ViewBag.Padre = padre;
            ViewBag.ReunionPadre = reunionPadre.ToList();
            ViewBag.Ninios = ninio.Listar();
            return View();
        }
    }
}