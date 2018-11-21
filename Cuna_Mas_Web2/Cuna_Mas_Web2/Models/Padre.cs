namespace Cuna_Mas_Web2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    using System.Data.Entity;
    using System.Linq;

    [Table("Padre")]
    public partial class Padre
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Padre()
        {
            Ninio = new HashSet<Ninio>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(30)]
        public string nombrePadre { get; set; }

        [Required]
        [StringLength(30)]
        public string nombreMadre { get; set; }

        [StringLength(30)]
        public string apoderado { get; set; }

        [Required]
        [StringLength(9)]
        public string telefono { get; set; }

        [Required]
        [StringLength(30)]
        public string direccion { get; set; }

        [Required]
        [StringLength(1)]
        public string estado { get; set; }

        public int fk_id_usuario { get; set; }

        public int fk_id_madre { get; set; }

        public int? fk_id_reunion { get; set; }

        public virtual Madre Madre { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ninio> Ninio { get; set; }

        public virtual Reunion Reunion { get; set; }

        public virtual Usuario Usuario { get; set; }

        public List<Padre> Listar()
        {
            var objTipo = new List<Padre>();
            try
            {
                using (var db = new Model_CM())
                {
                    objTipo = db.Padre.Include("Madre").Include("Usuario").Include("Reunion").ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return objTipo;
        }
        public Padre Obtener(int id)
        {
            var objTipo = new Padre();
            try
            {
                using (var db = new Model_CM())
                {
                    objTipo = db.Padre.Include("Madre")
                        .Where(x => x.id == id)
                        .SingleOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return objTipo;
        }

        public Padre ObtenerPapa(int id)
        {
            var objTipo = new Padre();
            try
            {
                using (var db = new Model_CM())
                {
                    objTipo = db.Padre.Include("Madre")
                        .Where(x => x.fk_id_usuario == id)
                        .SingleOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return objTipo;
        }

        public void Guardar()
        {
            try
            {
                using (var db = new Model_CM())
                {
                    if (this.id > 0)
                    {
                        db.Entry(this).State = EntityState.Modified;
                    }
                    else
                    {
                        db.Entry(this).State = EntityState.Added;
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
        public List<Padre> ListarPadre(string vComite)
        {
            string Activo = "A";
            var objTipo = new List<Padre>();
            try
            {
                using (var db = new Model_CM())
                {
                    if (!vComite.Equals(""))
                    {
                    objTipo = db.Padre.Include("Madre")
                                      .Include("Usuario")  
                                      .Where(x=>x.Madre.comite.Equals(vComite) && x.estado.Equals(Activo))
                                      .ToList();
                    }
                    else {
                        List<Padre>  lPadre = new List<Padre>();
                        objTipo = lPadre.ToList();
                }
            }
            }
            catch (Exception)
            {
                throw;
            }
            return objTipo;
        }

    }
}
