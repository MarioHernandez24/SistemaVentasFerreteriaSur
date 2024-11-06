using System;

namespace FerreteriaSur.Server.Models;

public partial class UnidadMedida
{
    public int IdUnidad { get; set; }
    public string? NombreUnidad { get; set; }
    public string? Simbolo { get; set; }
    public string? Descripcion { get; set; }
    public string? TipoUnidad { get; set; }
    public DateTime? FechaCreacion { get; set; }
    public virtual ICollection<Producto> Productos { get; } = new List<Producto>();
}
