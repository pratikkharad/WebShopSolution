using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Mvc.Formatters;
using Newtonsoft.Json;
using Shop.Infrastructure.DbContext;
using System.Text.Json;
using WebShop.UI.StartupExtensions;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.ConfigureServices(builder.Configuration);

builder.Services.AddSingleton<DapperDBContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
// Forcefull push the application HTTPS request
app.UseHsts(); // This is rquired middleware with UseHttpsRedirection

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(WebShop.UI.StartupExtensions.EndpointRouteBuilderExtensions.ConfigureEndpoints);


    

app.Run();
