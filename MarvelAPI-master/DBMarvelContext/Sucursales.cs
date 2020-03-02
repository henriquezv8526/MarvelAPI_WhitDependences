namespace DBMarvelContext
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Sucursales
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sucursales()
        {
            Inventarios = new HashSet<Inventarios>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdSucursal { get; set; }

        [Required]
        [StringLength(500)]
        public string Nombre { get; set; }

        [Required]
        public string Ubicacion { get; set; }

        [Required]
        [StringLength(500)]
        public string Telefonos { get; set; }

        public int? IdUsuarioAlta { get; set; }

        public DateTime? FCreacion { get; set; }

        public DateTime? FModificacion { get; set; }

        public bool Activo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Inventarios> Inventarios { get; set; }

        public virtual Usuarios Usuarios { get; set; }
    }
}
