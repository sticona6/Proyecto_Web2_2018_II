namespace Cuna_Mas_Web2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

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
    }
}
