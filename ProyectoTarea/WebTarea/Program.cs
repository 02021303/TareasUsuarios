using Data.Data;
using Data.Repositorios;
using Service.Servicios;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Data.Data.Identity;
using Microsoft.AspNetCore.Builder;


var builder = WebApplication.CreateBuilder(args);

// se agrega el dbcontext
builder.Services.AddDbContext<TareaDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("TareaDBConecction")));

// se agregan el repositorio y los servicios 
builder.Services.AddScoped<ITareaRepositorio, TareaRepositorio>();

builder.Services.AddScoped<ITareaServicio, TareaServicio>();

// Add services to the container.
builder.Services.AddRazorPages();

// Agregar identity al proyecto
builder.Services.AddIdentity<UsuarioAplicacion, IdentityRole>()
    .AddEntityFrameworkStores<TareaDbContext>()
    .AddDefaultTokenProviders()
    .AddDefaultUI();

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

// identity autorizacion y autenticacion
app.UseAuthentication();

app.UseAuthorization();

app.MapRazorPages()
    .RequireAuthorization();

// pagina inicio
app.MapGet("/", () =>
    Results.Redirect("/Tareas/Index"));

app.Run();
