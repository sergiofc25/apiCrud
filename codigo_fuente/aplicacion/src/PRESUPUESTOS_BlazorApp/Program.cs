using Blazored.LocalStorage;
using Blazored.Modal;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using PRESUPUESTOS_BlazorApp;
using PRESUPUESTOS_BlazorApp.HttpRepository;
using PRESUPUESTOS_BlazorApp.Pages;
using System.Net.Http.Headers;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient("ApiPRESUPUESTOS", httpClient =>
{
    httpClient.BaseAddress = new Uri("https://localhost:7196/");
    //httpClient.BaseAddress = new Uri("http://sergiofc25-001-site1.qtempurl.com/api/v1");
});


builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddMudServices();
builder.Services.AddMudBlazorDialog();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddAuthorizationCore();
builder.Services.AddBlazoredModal();

await builder.Build().RunAsync();
