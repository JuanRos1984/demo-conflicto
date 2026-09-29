using ReservasApi.Endpoints;
using ReservasApi.Servicios;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<ServicioReservas>();
builder.Services.AddSingleton<ServicioDemo>();

var app = builder.Build();

app.MapGet("/", () => "API de reservas de canchas");
app.MapReservas();

app.Run();
