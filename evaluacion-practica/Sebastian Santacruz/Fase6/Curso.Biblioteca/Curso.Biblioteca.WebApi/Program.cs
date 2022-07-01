using Curso.Biblioteca.Aplicacion.ServicioImpl;
using Curso.Biblioteca.Aplicacion.ServicioInterfaz;
using Curso.Biblioteca.Dominio.RepositorioInterfaz;
using Curso.Biblioteca.Infraestructura.Context;
using Curso.Biblioteca.Infraestructura.RepositorioImpl;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//Añadir Contexto
builder.Services.AddDbContext<BibliotecaContext>();

//Añadir inyeccion dependencias

builder.Services.AddTransient<IEditorialRepositorio, EditorialRepositorio>();
builder.Services.AddTransient<ILibroRepositorio,LibroRepositorio>();
builder.Services.AddTransient<IAutorRepositorio,AutorRepositorio>();
builder.Services.AddTransient<IAutorServicio, AutorServicio>();
builder.Services.AddTransient<ILibroServicio,LibroServicio>();
builder.Services.AddTransient<IEditorialServicio,EditorialServicio>();

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
