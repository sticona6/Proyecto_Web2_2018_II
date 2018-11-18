namespace Cuna_Mas_Web2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

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
    }
}
