using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.WebUtilities;
using Model;
using Model.DTO.v1;
using Model.Entitie;

namespace PRESUPUESTOS_BlazorApp.HttpRepository
{
    public class HttpClienteRepository : IHttpClienteRepository
    {
        private readonly HttpClient _httpClient;
        private readonly ILocalStorageService _localStorage;
        private readonly JsonSerializerOptions _options;

        public HttpClienteRepository(HttpClient httpClient, ILocalStorageService localStorage)
        {
            _httpClient = httpClient;
            _localStorage = localStorage;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        public async Task<PagingResponse<Ent_Cliente>> Obten_Paginado(ClienteParameters parameters)
        {
            var queryStringParam = new Dictionary<string, string>
            {
                ["NumeroPagina"] = parameters.NumeroPagina.ToString(),
                ["RegistroPagina"] = parameters.RegistroPagina.ToString(),
                ["PorNombre"] = parameters.SearchTerm ?? ""
            };
            using var response =
                await _httpClient.GetAsync(
                    QueryHelpers.AddQueryString("api/v1/Cliente", queryStringParam));

            if (response.IsSuccessStatusCode)
            {
                var Metadata =
                    JsonSerializer.Deserialize<MetaData>(response.Headers.GetValues("X-Pagination").First(), _options);

                var Cuerpo = await response.Content.ReadAsStreamAsync();

                var pagingResponse = new PagingResponse<Ent_Cliente>
                {
                    Cuerpo = await JsonSerializer.DeserializeAsync<List<Ent_Cliente>>(Cuerpo, _options),
                    MetaData = Metadata
                };

                return pagingResponse;
            }

            return null;
        }
    }
}
