using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor;
using MudBlazor.Services;
using SimWars.Client;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddMudServices(configuration => {
	configuration.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.BottomRight;
	configuration.SnackbarConfiguration.HideTransitionDuration = 100;
	configuration.SnackbarConfiguration.ShowTransitionDuration = 100;
	configuration.SnackbarConfiguration.VisibleStateDuration = 3000;
	configuration.SnackbarConfiguration.ShowCloseIcon = false;
});

builder.Services.AddHttpClient("SimWars.ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
    .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

// Supply HttpClient instances that include access tokens when making requests to the server project
builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("SimWars.ServerAPI"));

builder.Services.AddApiAuthorization();

await builder.Build().RunAsync();
