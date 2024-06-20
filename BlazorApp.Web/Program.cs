using BlazorShop.Web;
using BlazorShop.Web.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var baseUrl = "https://localhost:7237";
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(baseUrl) });

// MUDBLAZOR
builder.Services.AddMudServices();

// INTERFACE
builder.Services.AddScoped<IProdutoService, ProdutoService>();

await builder.Build().RunAsync();
