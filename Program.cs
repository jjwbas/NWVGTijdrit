using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using NWVGTijdrit;
using NWVGTijdrit.Data;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// Blazored LocalStorage voor data-opslag in de browser
builder.Services.AddBlazoredLocalStorage();

// Onze eigen DataService voor het beheren van tijdrit-data
builder.Services.AddScoped<DataService>();

await builder.Build().RunAsync();
