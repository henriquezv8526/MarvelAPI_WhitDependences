namespace DBMarvelContext
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Productos
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdProducto { get; set; }

        public int IdInventario { get; set; }

        [Required]
        [StringLength(50)]
        public string Codigo { get; set; }

        [Required]
        public string Descripcion { get; set; }

        public int? IdUsuarioAlta { get; set; }

        public DateTime? FCreacion { get; set; }

        public DateTime? FModificacion { get; set; }

        public bool Activo { get; set; }

        public virtual Inventarios Inventarios { get; set; }

        public virtual Usuarios Usuarios { get; set; }
    }
}
