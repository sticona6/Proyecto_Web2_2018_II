namespace Cuna_Mas_Web2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    using System.Data.Entity;
    using System.Linq;

    public partial class DatosMedicos
    {
        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string nombre { get; set; }

        public decimal altura { get; set; }

        public decimal peso { get; set; }

        [Required]
        [StringLength(20)]
        public string indice_nutricion { get; set; }

        [Column(TypeName = "date")]
        public DateTime fecha_revision { get; set; }

        public int fk_id_ninio { get; set; }

        public virtual Ninio Ninio { get; set; }

        public List<DatosMedicos> Listar()
        {
            var objTipo = new List<DatosMedicos>();
            try
            {
                using (var db = new Model_CM())
                {
                    objTipo = db.DatosMedicos.Include("Ninio").ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return objTipo;
        }
        public DatosMedicos Obtener(int id)
        {
            var objTipo = new DatosMedicos();
            try
            {
                using (var db = new Model_CM())
                {
                    objTipo = db.DatosMedicos.Include("Ninio")
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
