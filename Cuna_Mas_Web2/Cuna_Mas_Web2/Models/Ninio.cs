namespace Cuna_Mas_Web2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Ninio")]
    public partial class Ninio
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Ninio()
        {
            DatosMedicos = new HashSet<DatosMedicos>();
            Racion = new HashSet<Racion>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(30)]
        public string nombre { get; set; }

        [Column(TypeName = "date")]
        public DateTime fecha_nacimiento { get; set; }

        [Required]
        [StringLength(1)]
        public string estado { get; set; }

        public int fk_id_cuidadora { get; set; }

        public int fk_id_padre { get; set; }

        public int? fk_id_metodo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DatosMedicos> DatosMedicos { get; set; }

        public virtual Madre Madre { get; set; }

        public virtual MetodoAprendizaje MetodoAprendizaje { get; set; }

        public virtual Padre Padre { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Racion> Racion { get; set; }
    }
}
