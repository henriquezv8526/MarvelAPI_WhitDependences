using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MarvelAPI.Sample.Models
{
    public class SucursalesModel
    {
        public int IdSucursal { get; set; }

        public string Nombre { get; set; }

        public string Ubicacion { get; set; }

        public string Telefonos { get; set; }

        public int? IdUsuarioAlta { get; set; }

        public string FCreacion { get; set; }

        public string FModificacion { get; set; }

        public bool Activo { get; set; }
    }
}