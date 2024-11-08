using FerreteriaSur.Client.Servicios.Contrato;
using FerreteriaSur.Shared;
using System.Net.Http.Json;

namespace FerreteriaSur.Client.Servicios.Implementacion
{
    public class UnidadService : IUnidadService
    {

        private readonly HttpClient _http;
        public UnidadService(HttpClient http)
        {
            _http = http;
        }
        public async Task<ResponseDTO<List<UnidadDTO>>> Lista()
        {
            var result = await _http.GetFromJsonAsync<ResponseDTO<List<UnidadDTO>>>("api/unidad/Lista");
            return result;
        }

        public async Task<ResponseDTO<UnidadDTO>> Crear(UnidadDTO entidad)
        {
            var result = await _http.PostAsJsonAsync("api/unidad/Guardar", entidad);
            var response = await result.Content.ReadFromJsonAsync<ResponseDTO<UnidadDTO>>();
            return response!;
        }

        public async Task<bool> Editar(UnidadDTO entidad)
        {
            var result = await _http.PutAsJsonAsync("api/unidad/Editar", entidad);
            var response = await result.Content.ReadFromJsonAsync<ResponseDTO<UnidadDTO>>();

            return response!.status;
        }

        public async Task<bool> Eliminar(int id)
        {
            var result = await _http.DeleteAsync($"api/unidad/Eliminar/{id}");
            var response = await result.Content.ReadFromJsonAsync<ResponseDTO<string>>();
            return response!.status;
        }
    }
}
