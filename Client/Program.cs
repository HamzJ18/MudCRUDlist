using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using MudCRUDlist.Client;
using MudCRUDlist.Client.Services;
using MudCRUDlist.Client.Services.Interface;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddScoped(sp => new HttpClient{ BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

//builder.Services.AddScoped(sp => new HttpClient 
//{ BaseAddress = new Uri($"{builder.HostEnvironment.BaseAddress}api/") });
builder.Services.AddScoped<IUserTableService, UserTableService>();
builder.Services.AddMudServices();


builder.Services.AddAuthorizationCore();

await builder.Build().RunAsync();