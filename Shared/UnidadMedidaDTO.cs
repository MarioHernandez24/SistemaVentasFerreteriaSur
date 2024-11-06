using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerreteriaSur.Shared
{
    public class UnidadMedidaDTO
    {
        public int IdUnidad { get; set; }
        public string? NombreUnidad { get; set; }
        public string? Simbolo { get; set; }
        public string? Descripcion { get; set; }
        public string? TipoUnidad { get; set; }
        public DateTime? FechaCreacion { get; set; }
    }
}
