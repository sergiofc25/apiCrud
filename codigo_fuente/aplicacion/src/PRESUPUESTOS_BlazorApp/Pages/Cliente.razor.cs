using Microsoft.AspNetCore.Components;
using Model;
using Model.DTO.v1;
using Model.Entitie;
using PRESUPUESTOS_BlazorApp.HttpRepository;

namespace PRESUPUESTOS_BlazorApp.Pages;
public partial class Cliente
{
    private readonly int RegistroPagina = 10;

    private readonly ClienteParameters _Parameters = new();

    private bool Cargando;

    private string searchTerm;

    private int TotalPagina;

    [Inject] public IHttpClienteRepository Repository { get; set; }

    [Inject] public NavigationManager NavigationManager { get; set; }

    private List<Ent_Cliente> Lst_Cliente { get; set; } = new();

    protected override async Task OnInitializedAsync()
    {
        await Obten_Paginado(RegistroPagina, 1, searchTerm);
    }

    //private async Task Obten_Paginado(int RegistroPagina, int NumeroPagina, string PorNombre)
    //{
    //    Cargando = true;

    //    _Parameters.RegistroPagina = RegistroPagina;
    //    _Parameters.NumeroPagina = NumeroPagina;
    //    _Parameters.SearchTerm = PorNombre;

    //    var response = await Repository.Obten_Paginado(_Parameters);

    //    if (response != null)
    //    {
    //        Lst_Cliente = response.Cuerpo;
    //        TotalPagina = response.MetaData.TotalPagina;
    //    }

    //    Cargando = false;
    //}
    private async Task Obten_Paginado(int RegistroPagina, int NumeroPagina, string PorNombre)
    {
        Cargando = true;
        Console.WriteLine("Obteniendo datos...");

        _Parameters.RegistroPagina = RegistroPagina;
        _Parameters.NumeroPagina = NumeroPagina;
        _Parameters.SearchTerm = PorNombre;

        var response = await Repository.Obten_Paginado(_Parameters);

        if (response != null)
        {
            Lst_Cliente = response.Cuerpo;
            TotalPagina = response.MetaData.TotalPagina;
        }
        else
        {
            Console.WriteLine("No se obtuvieron datos.");
        }

        Cargando = false;
    }

    private void Btn_Nuevo_Cliente_Click()
    {
        NavigationManager.NavigateTo("/Cliente/ClienteCrea");
    }

    private async Task PageChanged(int PaginaSeleccionada)
    {
        await Obten_Paginado(RegistroPagina, PaginaSeleccionada, searchTerm);
    }

    private async Task OnSearch(string PorNombre)
    {
        searchTerm = PorNombre;

        await Obten_Paginado(RegistroPagina, 1, searchTerm);
    }
}
