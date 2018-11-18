namespace Cuna_Mas_Web2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

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

        [Column(TypeName = "date")]
        public DateTime fecha { get; set; }

        public int fk_id_madre_cuidadora { get; set; }

        public virtual Madre Madre { get; set; }
    }
}
