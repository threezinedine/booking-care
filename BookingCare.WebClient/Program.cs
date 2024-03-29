using Blazored.LocalStorage;
using BookingCare.Components.AuthStateProvider;
using BookingCare.Components.Services.RequestService;
using BookingCare.Components.Services.StorageService;
using BookingCare.Components.Services.ToastService;
using BookingCare.Components.ViewModels;
using BookingCare.WebClient;
using BookingCare.WebClient.Services.StorageService;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddBlazoredLocalStorage();
//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7074/api") });
builder.Services.AddBlazorBootstrap();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
builder.Services.AddScoped<RequestService>();
builder.Services.AddScoped<IStorageService, RealStorageService>();
builder.Services.AddLocalization();
builder.Services.AddScoped<LoginViewModel>();
builder.Services.AddScoped<UserManagementViewModel>();
builder.Services.AddScoped<ToastService>();
builder.Services.AddScoped<IndexViewModel>();
builder.Services.AddScoped<DoctorViewModel>();
builder.Services.AddScoped<DoctorManagementViewModel>();
builder.Services.AddScoped<BookingViewModel>();

await builder.Build().RunAsync();
