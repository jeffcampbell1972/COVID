using COVID.ApiClient.Interfaces;
using COVID.ApiClient.Models;
using COVID.ApiClient.Services;
using COVID.Component.Models;
using COVID.Web.Interfaces;
using COVID.Web.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddTelerikBlazor();

builder.Services.AddScoped<IApiClientService<StateSummary>, StatesApiClientService>();
builder.Services.AddScoped<IStatesInfoApiClientService, StatesInfoApiClientService>();

builder.Services.AddScoped<IComponenentService<CasesPageVM>, CasesPageComponentService>();
builder.Services.AddScoped<IComponenentService<StatesPageVM>, StatesPageComponentService>();

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
