using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.JSInterop;
using PersonalWebsite;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// Continue app initialization
// Build the service provider
var host = builder.Build();

var jsRuntime = host.Services.GetRequiredService<IJSRuntime>();

// Call a JavaScript function using IJSRuntime (example)
await jsRuntime.InvokeVoidAsync("console.log", "Base href set at runtime!");

await host.RunAsync();