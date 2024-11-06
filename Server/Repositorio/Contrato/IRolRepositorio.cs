using FerreteriaSur.Server.Models;

namespace FerreteriaSur.Server.Repositorio.Contrato
{
    public interface IRolRepositorio
    {
        Task<List<Rol>> Lista();
    }
}
