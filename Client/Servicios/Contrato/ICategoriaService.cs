
namespace FerreteriaSur.Client.Servicios.Contrato
{
    public interface ICategoriaService
    {
        Task<ResponseDTO<List<CategoriaDTO>>> Lista();
    }
}
