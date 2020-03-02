namespace DBMarvelContext
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Inventarios
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Inventarios()
        {
            Productos = new HashSet<Productos>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdInventario { get; set; }

        public int IdSucursal { get; set; }

        [Required]
        [StringLength(50)]
        public string Codigo { get; set; }

        [Required]
        public string Descripcion { get; set; }

        public int? IdUsuarioAlta { get; set; }

        public DateTime? FCreacion { get; set; }

        public DateTime? FModificacion { get; set; }

        public bool Activo { get; set; }

        public virtual Sucursales Sucursales { get; set; }

        public virtual Usuarios Usuarios { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Productos> Productos { get; set; }
    }
}
