namespace Cuna_Mas_Web2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Ranking")]
    public partial class Ranking
    {
        public int id { get; set; }

        public int puntuacion { get; set; }

        public int fk_id_madre { get; set; }

        public virtual Madre Madre { get; set; }
    }
}
