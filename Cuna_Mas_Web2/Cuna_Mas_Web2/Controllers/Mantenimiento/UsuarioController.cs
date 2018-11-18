﻿using System;
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
            return View();
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

        public ActionResult Guardar(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                usuario.Guardar();
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