using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Ramto;
using Ramto.Lib.OS;
using Ramto.Modelos.Custom;
using System.Net.Http;
using System.Net.Http.Json;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
using var httpClient = new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) };


// Se lee el archivo Json del que se obtienen valores 
SettingsValuesClient.CurrentApiValues = await httpClient.GetFromJsonAsync<ApiValues>("settings.json");

await builder.Build().RunAsync();
