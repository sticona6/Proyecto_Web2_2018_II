namespace Cuna_Mas_Web2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Padre")]
    public partial class Padre
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Padre()
        {
            Ninio = new HashSet<Ninio>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(30)]
        public string nombrePadre { get; set; }

        [Required]
        [StringLength(30)]
        public string nombreMadre { get; set; }

        [StringLength(30)]
        public string apoderado { get; set; }

        [Required]
        [StringLength(9)]
        public string telefono { get; set; }

        [Required]
        [StringLength(30)]
        public string direccion { get; set; }

        [Required]
        [StringLength(1)]
        public string estado { get; set; }

        public int fk_id_usuario { get; set; }

        public int fk_id_madre { get; set; }

        public int? fk_id_reunion { get; set; }

        public virtual Madre Madre { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ninio> Ninio { get; set; }

        public virtual Reunion Reunion { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
