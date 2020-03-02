using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DBMarvelContext
{
    public class ComicsStore
    {
        public int IdProducto { get; set; }

        public string Codigo { get; set; }

        public int IdInventario { get; set; }

        public string NombreInventario { get; set; }

        public int IdSucursal { get; set; }

        public string NombreSucursal { get; set; }

        public string Ubicacion { get; set; }

        
    }
}