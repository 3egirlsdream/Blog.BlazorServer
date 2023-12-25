using LinqToDB.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Hosting.StaticWebAssets;
using MudBlazor.Services;
using BlogBlazorServer;
using BlogBlazorServer.Data;
using BlogBlazorServer.DbConnection;

var builder = WebApplication.CreateBuilder(args);
Services = builder.Services;

StaticWebAssetsLoader.UseStaticWebAssets(builder.Environment, builder.Configuration);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

//builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddMudServices();
DataConnection.DefaultSettings = new Linq2dbSettings(builder.Configuration);

builder.Services.AddCors(options =>
            options.AddPolicy("any", builder =>
            builder.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin()));
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
app.UseAntiforgery();

app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode()
                .AddInteractiveWebAssemblyRenderMode();

app.Run();

app.UseCors("any");

public partial class Program
{
    public static IServiceCollection Services;

}