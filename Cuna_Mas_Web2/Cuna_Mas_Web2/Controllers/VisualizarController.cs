using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Cuna_Mas_Web2.Models;

namespace Cuna_Mas_Web2.Controllers
{
    public class VisualizarController : Controller
    {
        // GET: Visualizar
        private Ninio ninios = new Ninio();
        private Reunion reunion = new Reunion();

        public ActionResult Index()
        {
            ViewBag.ninio = ninios.Listar();
            ViewBag.reunion = reunion.Listar();
            return View();
        }


        public ActionResult MadreJefa()
        {
            //usuario logeado
            Usuario usu = new Usuario().Obtener(SessionHelper.GetUser());

            //cantidad de niños en el programa
            List<DatosMedicos> objninio = new DatosMedicos().Listar();
            ViewBag.cantNinios = objninio.Count;

            //cantidad de madres en el programa
            //List<Madre> madre = new Madre().Listar();
            //ViewBag.madres = madre.Count;

            //cantidad de padres en el programa
            //List<Padre> padres = new Padre().Listar();

            int cuidadora = 0, guia = 0, familia = 0;

            List<Usuario> usuarios = new Usuario().Listar();
            foreach (var item in usuarios)
            {
                if (item.tipo.Contains("Cuidadora"))
                {
                    cuidadora++;
                }
                else if (item.tipo.Contains("Guia"))
                {
                    guia++;
                }
                else if (item.tipo.Contains("Familia"))
                {
                    familia++;
                }
            }

            ViewBag.cuidadoras = cuidadora;
            ViewBag.guias = guia;
            ViewBag.familias = familia;

            return View();
        }
    }
}