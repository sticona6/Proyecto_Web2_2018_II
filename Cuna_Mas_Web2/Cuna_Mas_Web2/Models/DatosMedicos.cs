namespace Cuna_Mas_Web2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

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
    }
}
