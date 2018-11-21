namespace Cuna_Mas_Web2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    
    using System.Linq;
    using System.Data.Entity;
    using System.Web;
    using System.Data.Entity.Validation;
    using System.IO;

    [Table("Usuario")]
    public partial class Usuario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Usuario()
        {
            Madre = new HashSet<Madre>();
            Padre = new HashSet<Padre>();
        }

        public int id { get; set; }

        [Column("usuario")]
        [Required]
        [StringLength(20)]
        public string usuario1 { get; set; }

        [Required]
        [StringLength(100)]
        public string clave { get; set; }

        [Required]
        [StringLength(30)]
        public string tipo { get; set; }

        [Required]
        [StringLength(1)]
        public string estado { get; set; }

        [StringLength(100)]
        public string imagen { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Madre> Madre { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Padre> Padre { get; set; }
        
        
        //METHOD VALIDATE LOGIN
        public ResponseModel ValidarLogin(string Usuario, string Passwaord)
        {
            var rm = new ResponseModel();

            try
            {
                using (var db = new Model_CM())
                {
                    Passwaord = HashHelper.MD5(Passwaord);
                    var usuario = db.Usuario
                                            .Where(x => x.usuario1 == Usuario)
                                            .SingleOrDefault(x => x.clave == Passwaord);
                    if (usuario != null)
                    {
                        if (usuario.estado.Equals("A"))
                        {
                            SessionHelper.AddUserToSession(usuario.id.ToString());
                            rm.SetResponse(true);
                        }
                        else
                        {
                            rm.SetResponse(false, "Usuario deshabilitado consulte con el Administrador...");
                        }
                    }
                    else
                    {
                        rm.SetResponse(false, "Usuario o Password incorrectos...");
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return rm;
        }

        public List<Usuario> Listar()
        {
            var objTipo = new List<Usuario>();
            try
            {
                using (var db = new Model_CM())
                {
                    //sentencia LINQ
                    objTipo = db.Usuario.Include("Madre").Include("Padre").ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return objTipo;
        }

        public Usuario Obtener(int id)
        {
            var objTipo = new Usuario();
            try
            {
                using (var db = new Model_CM())
                {
                    objTipo = db.Usuario.Include("Madre")
                        .Include("Padre")
                        .SingleOrDefault(x => x.id == id);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return objTipo;
        }
        public void Guardar(HttpPostedFileBase Foto)
        {
            try
            {
                using (var db = new Model_CM())
                {
                    if (this.id > 0)
                    {
                        if (Foto != null)
                        {
                            const int size = 1024 * 1024 * 5;
                            var filtroextension = new[] { ".jpg", ".jpeg", ".png", ".gif" };
                            var extensiones = Path.GetExtension(Foto.FileName);

                            if (filtroextension.Contains(extensiones) && (Foto.ContentLength <= size))
                            {
                                this.imagen = id + "_" + DateTime.Now.ToString("MM-dd-yy_H.mm.ss") + this.imagen + extensiones;
                                if (File.Exists(HttpContext.Current.Server.MapPath("~/Uploads/" + imagen)))
                                {
                                    File.Delete(HttpContext.Current.Server.MapPath("~/Uploads/" + imagen));
                                }
                                Foto.SaveAs(HttpContext.Current.Server.MapPath("~/Uploads/" + imagen));
                            }

                            this.clave = HashHelper.MD5(clave);

                            db.Entry(this).State = EntityState.Modified;
                        }
                    }
                    else
                    {
                        if (Foto != null)
                        {
                            const int size = 1024 * 1024 * 5;
                            var filtroextension = new[] { ".jpg", ".jpeg", ".png", ".gif" };
                            var extensiones = Path.GetExtension(Foto.FileName);

                            if (filtroextension.Contains(extensiones) && (Foto.ContentLength <= size))
                            {
                                this.imagen = id + "_" + DateTime.Now.ToString("MM-dd-yy_H.mm.ss") + this.imagen + extensiones;
                                if (File.Exists(HttpContext.Current.Server.MapPath("~/Uploads/" + imagen)))
                                {
                                    File.Delete(HttpContext.Current.Server.MapPath("~/Uploads/" + imagen));
                                }
                                Foto.SaveAs(HttpContext.Current.Server.MapPath("~/Uploads/" + imagen));
                            }

                            this.clave = HashHelper.MD5(clave);

                            db.Entry(this).State = EntityState.Added;
                        }
                    }
                    db.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void Eliminar()
        {
            try
            {
                using (var db = new Model_CM())
                {
                    db.Entry(this).State = EntityState.Deleted;
                    db.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        
    }
}
