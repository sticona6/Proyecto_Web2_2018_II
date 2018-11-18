namespace Cuna_Mas_Web2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MetodoAprendizaje")]
    public partial class MetodoAprendizaje
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MetodoAprendizaje()
        {
            Ninio = new HashSet<Ninio>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(30)]
        public string nombre { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string descripcion { get; set; }

        [Required]
        [StringLength(15)]
        public string rango_edad { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string procedimiento { get; set; }

        [Required]
        [StringLength(1)]
        public string estado { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ninio> Ninio { get; set; }
    }
}
