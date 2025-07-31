using API_Productos.Data;
using API_Productos.ProductoMappers;
using API_Productos.Repositorio;
using API_Productos.Repositorio.IRepositorio;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AplicationDbContext>(opciones => 
    opciones.UseSqlServer(builder.Configuration.GetConnectionString("conexionSql"))
);

builder.Services.AddScoped<IProductorepositorio, ProductoRepositorio>();

// Agregar AutoMapper
builder.Services.AddAutoMapper(typeof(ProductosMappers));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
