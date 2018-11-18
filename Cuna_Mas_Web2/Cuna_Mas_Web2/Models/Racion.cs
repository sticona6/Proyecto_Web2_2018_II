namespace Cuna_Mas_Web2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    using System.Data.Entity;
    using System.Linq;

    [Table("Racion")]
    public partial class Racion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Racion()
        {
            DatosQR = new HashSet<DatosQR>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string desayuno { get; set; }

        [Required]
        [StringLength(50)]
        public string refrigerio { get; set; }

        [Required]
        [StringLength(50)]
        public string almuerzo { get; set; }

        [Required]
        [StringLength(50)]
        public string postre { get; set; }

        [Column(TypeName = "date")]
        public DateTime fecha { get; set; }

        [Required]
        [StringLength(1)]
        public string estado { get; set; }

        public int fk_id_ninio { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DatosQR> DatosQR { get; set; }

        public virtual Ninio Ninio { get; set; }

        public List<Racion> Listar()
        {
            var objTipo = new List<Racion>();
            try
            {
                using (var db = new Model_CM())
                {
                    objTipo = db.Racion.Include("Ninio").ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return objTipo;
        }
        public Racion Obtener(int id)
        {
            var objTipo = new Racion();
            try
            {
                using (var db = new Model_CM())
                {
                    objTipo = db.Racion.Include("Ninio")
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
