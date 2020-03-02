using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MarvelAPI.Sample.Models
{
    public class ListComicsDetailModel
    {
        public int Id { get; set; }
        public string Imagen { get; set; }

        public string Nombre { get; set; }

        public string Volumen { get; set; }

        public string FechaLanzamiento { get; set; }

        public int Paginas { get; set; }

        public string Descripcion { get; set; }

        public int CountCharacter { get; set; }

        public List<int> LstCharacterId { get; set; }
    }
}