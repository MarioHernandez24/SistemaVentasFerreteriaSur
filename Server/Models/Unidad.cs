using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FerreteriaSur.Server.Models
{
    public class Unidad
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdUnidad { get; set; } = 0; // Este será el campo de clave primaria
        public string? Nombre { get; set; }
        public string? Simbolo { get; set; }
        public string? Descripcion { get; set; }
        public bool? EsActivo { get; set; } = true;
        public DateTime? FechaCreacion { get; set; } = DateTime.Now;

        // relacion con producto
        public virtual ICollection<Producto> Productos { get; } = new List<Producto>();

    }
}
