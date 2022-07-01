using AdministracionPagos.Aplicacion.ServicioDefinicion;
using AdministracionPagos.Aplicacion.ServicioImplementacion;
using AdministracionPagos.Dominio.RepositorioDefinicion;
using AdministracionPagos.Infraestructura.Contexto;
using AdministracionPagos.Infraestructura.RepositorioImplementacion;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//Inyectar la conexion a base de datos
builder.Services.AddDbContext<AdministracionPagosContexto>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddTransient<IClienteRepositorio, ClienteRepositorio>();
builder.Services.AddTransient<IPagoRepositorio, PagoRepositorio>();

builder.Services.AddTransient<IClienteServicio, ClienteServicio>();
builder.Services.AddTransient<IPagoServicio, PagoServicio>();


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
