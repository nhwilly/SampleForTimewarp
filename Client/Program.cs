using BlazorState;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using SampleForTimewarp.Client;
using System.Reflection;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddBlazorState
(
    (aOptions) =>
        aOptions.Assemblies =
        new Assembly[]
        {
            typeof(Program).GetTypeInfo().Assembly,
        }
);

await builder.Build().RunAsync();
