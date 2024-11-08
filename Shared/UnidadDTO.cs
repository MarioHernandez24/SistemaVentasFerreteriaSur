using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerreteriaSur.Shared
{
    public class UnidadDTO
    {
        public int IdUnidad { get; set; }
        public string? Nombre { get; set; }

        public string? Simbolo { get; set; }
        public bool EsActivo
        {
            get { return EsActivo = true; }
            set { }
        }

        public override bool Equals(object o)
        {
            var other = o as UnidadDTO;
            return other?.IdUnidad == IdUnidad;
        }
        public override int GetHashCode() => IdUnidad.GetHashCode();
        public override string ToString()
        {
            return Nombre;
        }
    }
}
