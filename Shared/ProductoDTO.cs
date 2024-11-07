using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerreteriaSur.Shared
{
    public class ProductoDTO
    {
        public int IdProducto { get; set; }
        public string? Nombre { get; set; }
        public int? IdCategoria { get; set; }
        public string? DescripcionCategoria { get; set; }
        public int? Stock { get; set; }
        public decimal? Precio { get; set; }
        public string? Caracteristicas { get; set; }  // Nuevo campo
        public string? Detalle { get; set; }  // Nuevo campo
        public int? StockMinimo { get; set; }  // Nuevo campo
        public decimal? PrecioCompra { get; set; }  // Nuevo campo        
        public int? IdUnidad { get; set; }  // Nuevo campo

        public bool? EsActivo {
            get { return EsActivo = true; } set { } }

        public decimal? Ganancia { get { return Precio - PrecioCompra; } set { } }

        public decimal? PrecioVenta { get { return PrecioVenta = Precio; } set { } }  // Nuevo campo
    }
}
