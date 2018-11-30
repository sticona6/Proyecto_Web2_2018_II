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
        private Padre padre = new Padre();
        private Ranking rank = new Ranking();
        private Madre mama = new Madre();

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

            List<Ranking> objRanking = rank.Listar();

            var madreRank = from item in objRanking
                            group item by item.fk_id_madre into totalRank
                            select new
                            {
                                id_madre = totalRank.Key,
                                totalPuntuacion = totalRank.Sum(x => x.puntuacion)
                            }; 

            //ViewBag.Rank = madreRank.OrderByDescending(x=>x.totalPuntuacion).Take(1).ToList();
            var aux = madreRank.OrderByDescending(x => x.totalPuntuacion).Take(1);
            
            foreach (var item in aux)
            {
                ViewBag.Mama = mama.Obtener(item.id_madre);
                ViewBag.puntos = item.totalPuntuacion;
            }

            ViewBag.cuidadoras = cuidadora;
            ViewBag.guias = guia;
            ViewBag.familias = familia;

            // ViewBag para los Partial View
            ViewBag.Reuniones = reunion.Listar();
            ViewBag.Padres = padre.Listar();

            return View();
        }
    }
}