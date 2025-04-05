using Model;
using Model.DTO.v1;
using BlazorAppPreWeb.Servicios.Contrato;
using System.Net.Http.Json;

namespace BlazorAppPreWeb.Servicios.Implementacion
{
    public class Tipo_DocumentoServicio : ITIpo_DocumentoServicio
    {
        private readonly HttpClient _httpTipdoc;
        public Tipo_DocumentoServicio(HttpClient httpTipdoc)
        {
            _httpTipdoc = httpTipdoc;
        }
        public async Task<DTO_Response<List<DTO_Tipo_Documento_Obten>>> Obten()
        {
            return await _httpTipdoc.GetFromJsonAsync<DTO_Response<List<DTO_Tipo_Documento_Obten>>>("api/v1/Tipo_Documento/Obten");
        }

    }
}
