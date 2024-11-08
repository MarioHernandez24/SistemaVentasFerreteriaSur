
using FerreteriaSur.Client.Utilidades;

namespace FerreteriaSur.Client.Servicios.Contrato
{
    public interface ICategoriaService
    {
        Task<ResponseDTO<List<CategoriaDTO>>> Lista();       
        Task<ResponseDTO<CategoriaDTO>> Crear(CategoriaDTO entidad);
        Task<bool> Editar(CategoriaDTO entidad);
        Task<bool> Eliminar(int id);
    }
}
