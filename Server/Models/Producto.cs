using System;
using System.Collections.Generic;

namespace FerreteriaSur.Server.Models;

public partial class Producto
{
    public int IdProducto { get; set; }

    public string? Nombre { get; set; }

    public int? IdCategoria { get; set; }

    public int? Stock { get; set; }

    public decimal? Precio { get; set; }

    public bool? EsActivo { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public string? Caracteristicas { get; set; }  // Nuevo campo
    public string? Detalle { get; set; }  // Nuevo campo
    public int? StockMinimo { get; set; }  // Nuevo campo
    public decimal? Ganancia { get; set; }  // Nuevo campo
    public decimal? PrecioCompra { get; set; }  // Nuevo campo
    public decimal? PrecioVenta { get; set; }  // Nuevo campo
    public int? IdUnidad { get; set; }  // Nuevo campo

    public virtual ICollection<DetalleVenta> DetalleVenta { get; } = new List<DetalleVenta>();

    public virtual Categoria? IdCategoriaNavigation { get; set; }  

}
