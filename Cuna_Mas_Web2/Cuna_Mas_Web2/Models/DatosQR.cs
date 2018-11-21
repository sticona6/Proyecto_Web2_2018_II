namespace Cuna_Mas_Web2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    using System.Data.Entity;
    using System.Linq;

    [Table("DatosQR")]
    public partial class DatosQR
    {
        public int id { get; set; }

        [StringLength(100)]
        public string qr { get; set; }

        [Column(TypeName = "date")]
        public DateTime fecha { get; set; }

        public int fk_id_racion { get; set; }

        public virtual Racion Racion { get; set; }

        public List<DatosQR> Listar()
        {
            var objTipo = new List<DatosQR>();
            try
            {
                using (var db = new Model_CM())
                {
                    objTipo = db.DatosQR.Include("Racion").ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return objTipo;
        }
        public DatosQR Obtener(int id)
        {
            var objTipo = new DatosQR();
            try
            {
                using (var db = new Model_CM())
                {
                    objTipo = db.DatosQR.Include("Racion")
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
