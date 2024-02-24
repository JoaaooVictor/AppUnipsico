using AppUnipsico.Web;
using AppUnipsico.Web.Services.ImplWeb;
using AppUnipsico.Web.Services.InterfacesWeb;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var baseUrl = "https://localhost:7293";
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(baseUrl) });

builder.Services.AddScoped<IUsuarioServicoWeb, UsuarioServicoWeb>();

await builder.Build().RunAsync();
