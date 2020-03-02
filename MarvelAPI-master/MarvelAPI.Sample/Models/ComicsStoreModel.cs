using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MarvelAPI.Sample.Models
{
    public class ComicsStoreModel
    {
        public bool Check { get; set; }

        public int IdProducto { get; set; }

        public int Codigo { get; set; }

        public int IdInventario { get; set; }

        public string NombreInventario { get; set; }

        public int IdSucursal { get; set; }

        public string NombreSucursal { get; set; }

        public string Ubicacion { get; set; }

        public string TituloComic { get; set; }

        public string Formato { get; set; }

        public int NumPaginas { get; set; }
    }
}