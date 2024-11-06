using FerreteriaSur.Server.Models;

namespace FerreteriaSur.Server.Repositorio.Contrato
{
    public interface ICategoriaRepositorio
    {
        Task<List<Categoria>> Lista();
    }
}
