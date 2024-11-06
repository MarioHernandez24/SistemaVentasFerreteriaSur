using Microsoft.EntityFrameworkCore;
using FerreteriaSur.Server.Models;
using FerreteriaSur.Server.Repositorio.Contrato;
using System.Linq.Expressions;

namespace FerreteriaSur.Server.Repositorio.Implementacion
{
    public class UnidadMedidaRepositorio : IUnidadMedidaRepositorio
    {
        private readonly DbventaBlazorContext _dbContext;

        public UnidadMedidaRepositorio(DbventaBlazorContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IQueryable<UnidadMedida>> Consultar(Expression<Func<UnidadMedida, bool>> filtro = null)
        {
            IQueryable<UnidadMedida> queryEntidad = filtro == null ? _dbContext.UnidadMedidas : _dbContext.UnidadMedidas.Where(filtro);
            return queryEntidad;
        }

        public async Task<UnidadMedida> Crear(UnidadMedida entidad)
        {
            try
            {
                _dbContext.Set<UnidadMedida>().Add(entidad);
                await _dbContext.SaveChangesAsync();
                return entidad;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Editar(UnidadMedida entidad)
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

        public async Task<bool> Eliminar(UnidadMedida entidad)
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

        public async Task<UnidadMedida> Obtener(Expression<Func<UnidadMedida, bool>> filtro = null)
        {
            try
            {
                return await _dbContext.UnidadMedidas.Where(filtro).FirstOrDefaultAsync();
            }
            catch
            {
                throw;
            }
        }
    }
}
