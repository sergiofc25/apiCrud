//using Blazored.LocalStorage;
//using Blazored.Modal;
//using BlazorAppPreWeb;
//using Microsoft.AspNetCore.Components.Web;
//using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
//using MudBlazor.Services;

//var builder = WebAssemblyHostBuilder.CreateDefault(args);
//builder.RootComponents.Add<App>("#app");
//builder.RootComponents.Add<HeadOutlet>("head::after");


//builder.Services.AddHttpClient("ApiPRESUPUESTOS", httpClient =>
//{
//    httpClient.BaseAddress = new Uri("https://localhost:7196/");
//    //httpClient.BaseAddress = new Uri("https://apiprueba.runasp.net");
//});

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

//builder.Services.AddMudServices();
//builder.Services.AddMudBlazorDialog();
//builder.Services.AddBlazoredLocalStorage();
//builder.Services.AddAuthorizationCore();
//builder.Services.AddBlazoredModal();

//await builder.Build().RunAsync();
using Blazored.LocalStorage;
using Blazored.Modal;
using BlazorAppPreWeb;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using MudBlazor;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Configuración de HttpClient para API
builder.Services.AddHttpClient("ApiPRESUPUESTOS", httpClient =>
{
    //httpClient.BaseAddress = new Uri("https://localhost:7196/");
    httpClient.BaseAddress = new Uri("https://apiprueba.runasp.net");
});

// HttpClient para recursos locales
builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
});

// Configuración de MudBlazor (versión 6.9.0+ para .NET 9)
builder.Services.AddMudServices(config =>
{
    config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.BottomRight;
    config.PopoverOptions.ThrowOnDuplicateProvider = false; // Elimina advertencia de popover duplicado
});

// Eliminar esta línea redundante (ya está incluida en AddMudServices)
// builder.Services.AddMudBlazorDialog();

// Configuración de Blazored
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddBlazoredModal();

// Autenticación (si la usas)
builder.Services.AddAuthorizationCore();

await builder.Build().RunAsync();