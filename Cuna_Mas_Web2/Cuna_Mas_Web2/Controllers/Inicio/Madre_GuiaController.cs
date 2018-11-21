using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Cuna_Mas_Web2.Models;
using Cuna_Mas_Web2.Filters;

namespace Cuna_Mas_Web2.Controllers.Inicio
{
    public class Madre_GuiaController : Controller
    {
        Cuna_Mas_Web2.Models.Usuario usuario = new Cuna_Mas_Web2.Models.Usuario().Obtener(Cuna_Mas_Web2.Models.SessionHelper.GetUser());

        private Madre madre = new Madre();
        private Reunion reunion = new Reunion();
        
        // GET: Madre_Guia
        public ActionResult Index()
        {
            string vComite = "";
            foreach (var item in madre.Listar())
            {
                if (usuario.id.Equals(item.id))
                {
                    vComite = item.comite;
                }
            }

            ViewBag.madreguia = madre.ListaMadreGuia();
            ViewBag.reunion = reunion.Listar();
            ViewBag.madrecuidadora = madre.ListaMadreCuidadora(vComite);
            return View();
        }
    }
}