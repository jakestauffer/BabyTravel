using BabyTravel.UI.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BabyTravel.Api.Client;
using Radzen;
using Microsoft.AspNetCore.Components.Authorization;
using BabyTravel.UI.Client.Auth;
using BabyTravel.UI.Client.Helpers;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped<CookieHandler>();

builder.Services
    .AddHttpClient<ICalculateClient, CalculateClient>(client =>
    client.BaseAddress = new Uri(builder.Configuration["ApiUrl"]!))
    .AddHttpMessageHandler<CookieHandler>();

builder.Services
    .AddHttpClient<IUserClient, UserClient>(client => client.BaseAddress = new Uri(builder.Configuration["ApiUrl"]!))
    .AddHttpMessageHandler<CookieHandler>();

builder.Services
    .AddHttpClient<IBabyClient, BabyClient>(client => client.BaseAddress = new Uri(builder.Configuration["ApiUrl"]!))
    .AddHttpMessageHandler<CookieHandler>();

builder.Services
    .AddHttpClient<ITripClient, TripClient>(client => client.BaseAddress = new Uri(builder.Configuration["ApiUrl"]!))
    .AddHttpMessageHandler<CookieHandler>();

builder.Services.AddScoped<CalculationHelper>();

builder.Services.AddScoped<NotificationService>();

builder.Services.AddAuthorizationCore();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<CustomAuthStateProvider>();
builder.Services.AddScoped<AuthenticationStateProvider>(sp => sp.GetRequiredService<CustomAuthStateProvider>());

builder.Services.AddRadzenComponents();

await builder.Build().RunAsync();
