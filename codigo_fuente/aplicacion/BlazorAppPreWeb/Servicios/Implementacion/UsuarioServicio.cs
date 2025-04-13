using Model;
using Model.DTO.v1;
using BlazorAppPreWeb.Servicios.Contrato;
using System.Net.Http.Json;

namespace BlazorAppPreWeb.Servicios.Implementacion
{
    public class UsuarioServicio: IUsuarioServicio
    {
        private readonly HttpClient _httpClient;
        public UsuarioServicio(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<DTO_Response<List<DTO_Usuario_Obten_Paginado>>> Obten_Paginado(ClienteParameters parameters)
        {
            return await _httpClient.GetFromJsonAsync<DTO_Response<List<DTO_Usuario_Obten_Paginado>>>("api/v1/Usuario/Obten_Paginado");
        }
        public async Task<DTO_Response<List<DTO_Usuario_Obten_x_Correo>>> Obten_x_Correo()
        {
            return await _httpClient.GetFromJsonAsync<DTO_Response<List<DTO_Usuario_Obten_x_Correo>>>("api/v1/Usuario/Obten_Usuario_Logeado");
        }
    }
}
