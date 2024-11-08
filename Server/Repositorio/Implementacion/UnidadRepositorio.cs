using Microsoft.EntityFrameworkCore;
using FerreteriaSur.Server.Models;
using FerreteriaSur.Server.Repositorio.Contrato;
using System.Linq.Expressions;

namespace FerreteriaSur.Server.Repositorio.Implementacion
{
    public class UnidadRepositorio : IUnidadRepositorio
    {
        private readonly DbventaBlazorContext _dbContext;

        public UnidadRepositorio(DbventaBlazorContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IQueryable<Unidad>> Consultar(Expression<Func<Unidad, bool>> filtro = null)
        {
            IQueryable<Unidad> queryEntidad = filtro == null ? _dbContext.Unidad : _dbContext.Unidad.Where(filtro);
            return queryEntidad;
        }

        public async Task<Unidad> Crear(Unidad entidad)
        {
            try
            {
                _dbContext.Set<Unidad>().Add(entidad);
                await _dbContext.SaveChangesAsync();
                return entidad;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Editar(Unidad entidad)
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

        public async Task<bool> Eliminar(Unidad entidad)
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

        public async Task<List<Unidad>> Lista()
        {
            try
            {
                return await _dbContext.Unidad.ToListAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<Unidad> Obtener(Expression<Func<Unidad, bool>> filtro = null)
        {
            try
            {
                return await _dbContext.Unidad.Where(filtro).FirstOrDefaultAsync();
            }
            catch
            {
                throw;
            }
        }
    }
}
