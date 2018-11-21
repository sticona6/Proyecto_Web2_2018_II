namespace Cuna_Mas_Web2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    using System.Data.Entity;
    using System.Linq;

    [Table("Madre")]
    public partial class Madre
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Madre()
        {
            Ninio = new HashSet<Ninio>();
            Observacion = new HashSet<Observacion>();
            Padre = new HashSet<Padre>();
            Ranking = new HashSet<Ranking>();
            Reunion = new HashSet<Reunion>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(30)]
        public string nombre { get; set; }

        [Required]
        [StringLength(30)]
        public string apellido { get; set; }

        [Required]
        [StringLength(2)]
        public string edad { get; set; }

        public int horas { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string obserbaciones { get; set; }

        [StringLength(20)]
        public string comite { get; set; }

        [Required]
        [StringLength(1)]
        public string estado { get; set; }

        public int fk_id_usuario { get; set; }

        public virtual Usuario Usuario { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ninio> Ninio { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Observacion> Observacion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Padre> Padre { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ranking> Ranking { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Reunion> Reunion { get; set; }

        public List<Madre> Listar()
        {
            var objTipo = new List<Madre>();
            try
            {
                using (var db = new Model_CM())
                {
                    objTipo = db.Madre.Include("Usuario").ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return objTipo;
        }
        public Madre Obtener(int id)
        {
            var objTipo = new Madre();
            try
            {
                using (var db = new Model_CM())
                {
                    objTipo = db.Madre.Include("Usuario")
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
        public List<Madre> ListaMadreGuia()
        {
            var objTipo = new List<Madre>();
            try
            {
                using (var db = new Model_CM())
                {
                    objTipo = db.Madre.Include("Usuario")
                                      .Where(x=>x.Usuario.tipo.Equals("Madre Guia"))
                                      .ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return objTipo;
        }
        public List<Madre> ListaMadreCuidadora(string vComite)
        {
            string Activo = "A";

            var objTipo = new List<Madre>();
            try
            {
                using (var db = new Model_CM())
                {
                    if (!vComite.Equals(""))
                    {
                            objTipo = db.Madre.Include("Usuario")
                                      .Where(x => x.Usuario.tipo.Equals("Madre Cuidadora") && x.comite.Equals(vComite) && x.estado.Equals(Activo))
                                      .ToList();
                    }
                    else {
                        List<Madre> lMadre = new List<Madre>();
                        objTipo = lMadre.ToList();
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
