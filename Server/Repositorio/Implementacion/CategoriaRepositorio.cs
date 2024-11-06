using Microsoft.EntityFrameworkCore;
using FerreteriaSur.Server.Models;
using FerreteriaSur.Server.Repositorio.Contrato;

namespace FerreteriaSur.Server.Repositorio.Implementacion
{
    public class CategoriaRepositorio : ICategoriaRepositorio
    {
        private readonly DbventaBlazorContext _dbContext;

        public CategoriaRepositorio(DbventaBlazorContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Categoria>> Lista()
        {
            try
            {
                return await _dbContext.Categoria.ToListAsync();
            }
            catch
            {
                throw;
            }
        }
    }
}
