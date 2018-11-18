namespace Cuna_Mas_Web2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Madre")]
    public partial class Madre
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Madre()
        {
            Ninio = new HashSet<Ninio>();
            Observacion = new HashSet<Observacion>();
            Padre = new HashSet<Padre>();
            Ranking = new HashSet<Ranking>();
            Reunion = new HashSet<Reunion>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(30)]
        public string nombre { get; set; }

        [Required]
        [StringLength(30)]
        public string apellido { get; set; }

        [Required]
        [StringLength(2)]
        public string edad { get; set; }

        public int horas { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string obserbaciones { get; set; }

        [StringLength(20)]
        public string comite { get; set; }

        [Required]
        [StringLength(1)]
        public string estado { get; set; }

        public int fk_id_usuario { get; set; }

        public virtual Usuario Usuario { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ninio> Ninio { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Observacion> Observacion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Padre> Padre { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ranking> Ranking { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Reunion> Reunion { get; set; }
    }
}
