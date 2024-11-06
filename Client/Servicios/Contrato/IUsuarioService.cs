using FerreteriaSur.Client.Utilidades;

namespace FerreteriaSur.Client.Servicios.Contrato
{
    public interface IUsuarioService
    {
        Task<ResponseDTO<List<UsuarioDTO>>> Lista();
        Task<ResponseDTO<UsuarioDTO>> IniciarSesion(UsuarioLogin request);
        Task<ResponseDTO<UsuarioDTO>> Crear(UsuarioDTO entidad);
        Task<bool> Editar(UsuarioDTO entidad);
        Task<bool> Eliminar(int id);
    }
}
