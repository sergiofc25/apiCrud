using Model.DTO.v1;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace BlazorAppPreWeb.Pages.Cliente
{
    public partial class ClienteObtenNombre
    {
        public List<DTO_Cliente_Obten_Nombre> clientes { get; set; } = new List<DTO_Cliente_Obten_Nombre>();
        public DTO_Cliente_Obten_Nombre selectedCliente { get; set; }
        protected override async Task OnInitializedAsync()
        {
            var token = await localStorage.GetItemAsync<string>("authToken");
            if (string.IsNullOrEmpty(token))
            {
                NavigationManager.NavigateTo("/login");
                return;
            }

            await GetClientes();
        }
        private async Task GetClientes()
        {
            try
            {
                var client = ClientFactory.CreateClient("ApiPRESUPUESTOS");

                // Agregar el token de autorización a la solicitud actual
                var token = await localStorage.GetItemAsync<string>("authToken");
                if (token != null)
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                }

                var response = await client.GetAsync("api/v1/Cliente/Obten_Nombre");
                Console.WriteLine($"Response Status: {response.StatusCode}");
                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Response Body: {responseBody}");
                    var result = JsonConvert.DeserializeObject<DTO_Response<List<DTO_Cliente_Obten_Nombre>>>(responseBody);
                    if (result != null && result.IsSuccessful)
                    {
                        clientes = result.Data;
                        Console.WriteLine($"Clientes Count: {clientes.Count}");
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
