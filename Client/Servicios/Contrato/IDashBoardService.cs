namespace FerreteriaSur.Client.Servicios.Contrato
{
    public interface IDashBoardService
    {
        Task<ResponseDTO<DashBoardDTO>> Resumen();
    }
}
