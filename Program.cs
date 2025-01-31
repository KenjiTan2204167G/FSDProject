using TRUMPet.Components;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TRUMPet.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContextFactory<TRUMPetContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("TRUMPetContext") ?? throw new InvalidOperationException("Connection string 'TRUMPetContext' not found.")));

builder.Services.AddQuickGridEntityFrameworkAdapter();
builder.Services.AddScoped<HttpClient>();
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
    app.UseMigrationsEndPoint();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
