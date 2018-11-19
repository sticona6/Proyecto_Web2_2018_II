namespace Cuna_Mas_Web2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    using System.Data.Entity;
    using System.Linq;

    [Table("Observacion")]
    public partial class Observacion
    {
        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string titulo { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string descripcion { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime fecha { get; set; }

        public int fk_id_madre_cuidadora { get; set; }

        public virtual Madre Madre { get; set; }

        public List<Observacion> Listar()
        {
            var objTipo = new List<Observacion>();
            try
            {
                using (var db = new Model_CM())
                {
                    objTipo = db.Observacion.Include("Madre").ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return objTipo;
        }
        public Observacion Obtener(int id)
        {
            var objTipo = new Observacion();
            try
            {
                using (var db = new Model_CM())
                {
                    objTipo = db.Observacion.Include("Madre")
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
