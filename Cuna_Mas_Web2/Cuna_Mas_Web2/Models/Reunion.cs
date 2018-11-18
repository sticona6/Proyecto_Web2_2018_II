namespace Cuna_Mas_Web2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Reunion")]
    public partial class Reunion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Reunion()
        {
            Padre = new HashSet<Padre>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(30)]
        public string nombre { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string descripcion { get; set; }

        [Required]
        [StringLength(30)]
        public string importancia { get; set; }

        [Required]
        [StringLength(30)]
        public string fecha { get; set; }

        [Required]
        [StringLength(1)]
        public string estado { get; set; }

        public int id_madre { get; set; }

        public virtual Madre Madre { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Padre> Padre { get; set; }
    }
}
