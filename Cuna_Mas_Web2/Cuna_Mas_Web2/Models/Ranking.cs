namespace Cuna_Mas_Web2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    using System.Data.Entity;
    using System.Linq;

    [Table("Ranking")]
    public partial class Ranking
    {
        public int id { get; set; }

        public int puntuacion { get; set; }

        public int fk_id_madre { get; set; }

        public int fk_id_padre { get; set; }

        public virtual Madre Madre { get; set; }


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

        public Ranking ObtenerPadreRanking(int id)
        {
            var objTipo = new Ranking();
            try
            {
                using (var db = new Model_CM())
                {
                    objTipo = db.Ranking
                        .SingleOrDefault(x => x.fk_id_padre == id);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return objTipo;
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

        public List<Ranking> Listar()
        {
            var objTipo = new List<Ranking>();
            try
            {
                using (var db = new Model_CM())
                {
                    //sentencia LINQ
                    objTipo = db.Ranking
                        .Include("Madre").ToList();
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
