using Microsoft.EntityFrameworkCore;
using FerreteriaSur.Server.Models;
using FerreteriaSur.Server.Repositorio.Contrato;
using System.Linq.Expressions;

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

        public async Task<Categoria> Crear(Categoria entidad)
        {
            try
            {
                _dbContext.Set<Categoria>().Add(entidad);
                await _dbContext.SaveChangesAsync();
                return entidad;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Editar(Categoria entidad)
        {
            try
            {
                _dbContext.Update(entidad);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Eliminar(Categoria entidad)
        {
            try
            {
                _dbContext.Remove(entidad);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
        }

        public async Task<Categoria> Obtener(Expression<Func<Categoria, bool>> filtro = null)
        {
            try
            {
                return await _dbContext.Categoria.Where(filtro).FirstOrDefaultAsync();
            }
            catch
            {
                throw;
            }
        }
    }
}
