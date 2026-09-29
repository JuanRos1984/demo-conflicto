using ReservasApi.Modelos;
using ReservasApi.Servicios;

namespace ReservasApi.Endpoints;

public static class ReservasEndpoints
{
    public static void MapReservas(this WebApplication app)
    {
        app.MapGet("/reservas", (ServicioReservas servicio) => servicio.Listar());

        app.MapGet("/reservas/{id:int}", (int id, ServicioReservas servicio) =>
            servicio.BuscarPorId(id) is Reserva r ? Results.Ok(r) : Results.NotFound());

        app.MapPost("/reservas", (SolicitudReserva solicitud, ServicioReservas servicio) =>
        {
            var (reserva, error) = servicio.CrearReserva(solicitud);
            return error is null
                ? Results.Created($"/reservas/{reserva!.Id}", reserva)
                : Results.BadRequest(new { error });
        });
    }
}
