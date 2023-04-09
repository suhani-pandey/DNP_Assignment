// using BlazorWasm.Auth;

using BlazorWasm.Auth;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using BlazorWasm.Data;
// using BlazorWasm.Services;
// using BlazorWasm.Services.Http;
using HttpClient.ClientInterface;
using HTTPClient.Implementation;
using HTTPClient.Implementation;
using Microsoft.AspNetCore.Components.Authorization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddScoped(sp => new System.Net.Http.HttpClient { BaseAddress = new Uri("https://localhost:7150") });
builder.Services.AddScoped<IUserService, UserHttpClient>();
builder.Services.AddScoped<IForumService, ForumHttpClient>();
// builder.Services.AddScoped<IAuthService, JwtAuthService>();

 builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthProvider>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();