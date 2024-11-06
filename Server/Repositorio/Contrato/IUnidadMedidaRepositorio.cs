using FerreteriaSur.Server.Models;
using System.Linq.Expressions;

namespace FerreteriaSur.Server.Repositorio.Contrato
{
    public interface IUnidadMedidaRepositorio
    {
        Task<UnidadMedida> Obtener(Expression<Func<UnidadMedida, bool>> filtro = null);
        Task<UnidadMedida> Crear(UnidadMedida entidad);
        Task<bool> Editar(UnidadMedida entidad);
        Task<bool> Eliminar(UnidadMedida entidad);
        Task<IQueryable<UnidadMedida>> Consultar(Expression<Func<UnidadMedida, bool>> filtro = null);
    }
}
