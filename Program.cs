using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ICL.Data;
using ICL.Interfaces;
using ICL.Repository;
using ICL.Business;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ICLContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ICLContext") ?? throw new InvalidOperationException("Connection string 'ICLContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IPedidoPostulanteRepository, PedidoPostulanteRepository>();
builder.Services.AddScoped<IPedidoPostulanteBusiness, PedidoPostulanteBusiness>();
builder.Services.AddScoped<IServicioRepository, ServicioRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseStaticFiles(); // ✅ Habilita archivos estáticos desde wwwroot

app.UseAuthorization();

app.MapControllers();

app.Run();
