using FerreteriaSur.Server.Models;
using System.Linq.Expressions;


namespace FerreteriaSur.Server.Repositorio.Contrato
{
    public interface IUnidadRepositorio
    {
        Task<List<Unidad>> Lista();
        Task<Unidad> Obtener(Expression<Func<Unidad, bool>> filtro = null);
        Task<Unidad> Crear(Unidad entidad);
        Task<bool> Editar(Unidad entidad);
        Task<bool> Eliminar(Unidad entidad);
        Task<IQueryable<Unidad>> Consultar(Expression<Func<Unidad, bool>> filtro = null);
    }
}
