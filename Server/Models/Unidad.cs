namespace FerreteriaSur.Server.Models
{
    public class Unidad
    {
        public int? IdUnidad { get; set; } // Este será el campo de clave primaria
        public string? Nombre { get; set; }
        public string? Simbolo { get; set; }
        public string? Descripcion { get; set; }
        public bool? EsActivo { get; set; }
        public DateTime? FechaCreacion { get; set; }

        // relacion con producto
        public virtual ICollection<Producto> Productos { get; } = new List<Producto>();

    }
}
