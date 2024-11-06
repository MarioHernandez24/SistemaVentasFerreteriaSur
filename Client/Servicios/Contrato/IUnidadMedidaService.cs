using System.Linq.Expressions;

namespace FerreteriaSur.Client.Servicios.Contrato
{
    public interface IUnidadMedidaService
    {
        Task<ResponseDTO<List<UnidadMedidaDTO>>> Lista();
        Task<ResponseDTO<UnidadMedidaDTO>> Crear(UnidadMedidaDTO entidad);
        Task<bool> Editar(UnidadMedidaDTO entidad);
        Task<bool> Eliminar(int id);
    }
}
