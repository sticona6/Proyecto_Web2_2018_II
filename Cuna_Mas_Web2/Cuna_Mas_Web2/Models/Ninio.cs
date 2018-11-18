namespace Cuna_Mas_Web2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    using System.Data.Entity;
    using System.Linq;

    [Table("Ninio")]
    public partial class Ninio
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Ninio()
        {
            DatosMedicos = new HashSet<DatosMedicos>();
            Racion = new HashSet<Racion>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(30)]
        public string nombre { get; set; }

        [Column(TypeName = "date")]
        public DateTime fecha_nacimiento { get; set; }

        [Required]
        [StringLength(1)]
        public string estado { get; set; }

        public int fk_id_cuidadora { get; set; }

        public int fk_id_padre { get; set; }

        public int? fk_id_metodo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DatosMedicos> DatosMedicos { get; set; }

        public virtual Madre Madre { get; set; }

        public virtual MetodoAprendizaje MetodoAprendizaje { get; set; }

        public virtual Padre Padre { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Racion> Racion { get; set; }

        public List<Ninio> Listar()
        {
            var objTipo = new List<Ninio>();
            try
            {
                using (var db = new Model_CM())
                {
                    objTipo = db.Ninio.Include("Madre")
                                      .Include("Padre")
                                      .Include("MetodoAprendizaje")
                                      .ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return objTipo;
        }
        public Ninio Obtener(int id)
        {
            var objTipo = new Ninio();
            try
            {
                using (var db = new Model_CM())
                {
                    objTipo = db.Ninio.Include("Madre")
                                      .Include("Padre")
                                      .Include("MetodoAprendizaje")
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

    }
}
