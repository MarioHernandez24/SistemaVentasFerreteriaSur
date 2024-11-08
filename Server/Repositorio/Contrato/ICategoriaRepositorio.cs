using FerreteriaSur.Server.Models;
using System.Linq.Expressions;

namespace FerreteriaSur.Server.Repositorio.Contrato
{
    public interface ICategoriaRepositorio
    {
        Task<List<Categoria>> Lista();
        Task<Categoria> Crear(Categoria entidad);

        Task<Categoria> Obtener(Expression<Func<Categoria, bool>> filtro = null);

        Task<bool> Editar(Categoria entidad);
        Task<bool> Eliminar(Categoria entidad);
    }
}
