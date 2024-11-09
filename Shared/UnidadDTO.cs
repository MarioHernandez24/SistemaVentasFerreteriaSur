using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerreteriaSur.Shared
{
    public class UnidadDTO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdUnidad { get; set; } = 0;
        public string? Nombre { get; set; }

        public string? Simbolo { get; set; }
        public bool EsActivo { get; set; }  = true;

        public string? Descripcion { get; set; }
        public DateTime? FechaCreacion { get; set; } = DateTime.Now;

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
