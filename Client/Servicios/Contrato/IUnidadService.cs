namespace FerreteriaSur.Client.Servicios.Contrato
{
    public interface IUnidadService
    {
        Task<ResponseDTO<List<UnidadDTO>>> Lista();
        Task<ResponseDTO<UnidadDTO>> Crear(UnidadDTO entidad);
        Task<bool> Editar(UnidadDTO entidad);
        Task<bool> Eliminar(int id);
    }
}
