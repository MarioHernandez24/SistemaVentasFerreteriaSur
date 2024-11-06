
using System.Net.Http.Json;

namespace FerreteriaSur.Client.Servicios.Implementacion
{
    public class UnidadMedidaService : IUnidadMedidaService
    {
        private readonly HttpClient _http;
        public UnidadMedidaService(HttpClient http)
        {
            _http = http;
        }

        public async Task<ResponseDTO<UnidadMedidaDTO>> Crear(UnidadMedidaDTO entidad)
        {
            var result = await _http.PostAsJsonAsync("api/unidadmedida/Guardar", entidad);
            var response = await result.Content.ReadFromJsonAsync<ResponseDTO<UnidadMedidaDTO>>();
            return response!;
        }

        public async Task<bool> Editar(UnidadMedidaDTO entidad)
        {
            var result = await _http.PutAsJsonAsync("api/unidadmedida/Editar", entidad);
            var response = await result.Content.ReadFromJsonAsync<ResponseDTO<bool>>();

            return response!.status;
        }

        public async Task<bool> Eliminar(int id)
        {
            var result = await _http.DeleteAsync($"api/unidadmedida/Eliminar/{id}");
            var response = await result.Content.ReadFromJsonAsync<ResponseDTO<string>>();
            return response!.status;
        }

        public async Task<ResponseDTO<List<UnidadMedidaDTO>>> Lista()
        {
            var result = await _http.GetFromJsonAsync<ResponseDTO<List<UnidadMedidaDTO>>>("api/unidadmedida/Lista");
            return result!;
        }
    }
}
