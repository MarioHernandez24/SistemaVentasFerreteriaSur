using System.Linq.Expressions;

namespace FerreteriaSur.Client.Servicios.Contrato
{
    public interface IProductoService
    {
        Task<ResponseDTO<List<ProductoDTO>>> Lista();
        Task<ResponseDTO<ProductoDTO>> Crear(ProductoDTO entidad);
        Task<bool> Editar(ProductoDTO entidad);
        Task<bool> Eliminar(int id);
    }
}
