using Microsoft.EntityFrameworkCore;
using FerreteriaSur.Server.Models;
using FerreteriaSur.Server.Repositorio.Contrato;

namespace FerreteriaSur.Server.Repositorio.Implementacion
{
    public class RolRepositorio : IRolRepositorio
    {
        private readonly DbventaBlazorContext _dbContext;

        public RolRepositorio(DbventaBlazorContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Rol>> Lista()
        {
            try
            {
                return await _dbContext.Rols.ToListAsync();
            }
            catch
            {
                throw;
            }
        }
    }
}
