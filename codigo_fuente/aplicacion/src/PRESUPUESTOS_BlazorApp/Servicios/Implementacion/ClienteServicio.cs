using Model;
using Model.DTO.v1;
using PRESUPUESTOS_BlazorApp.Servicios.Contrato;
using System.Net.Http.Json;

namespace PRESUPUESTOS_BlazorApp.Servicios.Implementacion
{
    public class ClienteServicio: IClienteServicio
    {
        private readonly HttpClient _httpClient;
        public ClienteServicio(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<DTO_Response<List<DTO_Cliente_Obten_Paginado>>> Obten_Paginado(ClienteParameters parameters)
        {
            return await _httpClient.GetFromJsonAsync<DTO_Response<List<DTO_Cliente_Obten_Paginado>>>("api/v1/Cliente/Obten_Paginado");
        }
    }
}
