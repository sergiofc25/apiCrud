using Model.DTO.v1;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace BlazorAppPreWeb.Pages.Cliente
{
    public partial class Tipo_DocumentoObtenNombre
    {
        public List<DTO_Tipo_Documento_Obten> documentos { get; set; } = new List<DTO_Tipo_Documento_Obten>();
        public DTO_Tipo_Documento_Obten selectedDocumento { get; set; }
        protected override async Task OnInitializedAsync()
        {

            await GetDocumento();
        }
        private async Task GetDocumento()
        {
            try
            {
                var documento = ClientFactory.CreateClient("ApiPRESUPUESTOS");

                var response = await documento.GetAsync("api/v1/Tipo_Documento/Obten");
                Console.WriteLine($"Response Status: {response.StatusCode}");
                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Response Body: {responseBody}");
                    var result = JsonConvert.DeserializeObject<DTO_Response<List<DTO_Tipo_Documento_Obten>>>(responseBody);
                    if (result != null && result.IsSuccessful)
                    {
                        documentos = result.Data;
                        Console.WriteLine($"Documento Count: {documentos.Count}");
                    }
                    else
                    {
                        Console.WriteLine("Response not successful or no data.");
                    }
                    StateHasChanged();
                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}
