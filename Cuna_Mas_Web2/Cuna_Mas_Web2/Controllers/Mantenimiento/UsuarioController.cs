using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Cuna_Mas_Web2.Models;
using Cuna_Mas_Web2.Filters;

namespace Cuna_Mas_Web2.Controllers.Mantenimiento
{
    public class UsuarioController : Controller
    {
        private Usuario usuario = new Usuario();
        // GET: Usuario
        public ActionResult Index()
        {
            return View(usuario.Listar());
        }

        public ActionResult Ver(int id)
        {
            return View(usuario.Obtener(id));
        }

        public ActionResult AgregarEditar(int id = 0)
        {
            return View(
                id == 0 ? new Usuario() //agregar un nuevo objeto
                : usuario.Obtener(id)
                );
        }
        [HttpPost]
        public ActionResult Guardar(string imagen,HttpPostedFileBase foto, Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                var photoName = "";
                photoName = imagen;
                var fullPath = Server.MapPath(@"~/Uploads/" + photoName);

                if (System.IO.File.Exists(fullPath))
                {
                    System.IO.File.Delete(fullPath);
                }

                usuario.Guardar(foto);
                return Redirect("~/Usuario");
            }
            else
            {
                return View("~/Views/Usuario/AgregarEditar.cshtml", usuario);
            }
        }

        public ActionResult Eliminar(int id)
        {
            usuario.id = id;
            usuario.Eliminar();
            return Redirect("~/Usuario");
        }
    }
}