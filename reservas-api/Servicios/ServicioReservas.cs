using ReservasApi.Modelos;

namespace ReservasApi.Servicios;

public class ServicioReservas
{
    private const int MaxHoras = 2;

    private readonly List<Reserva> _reservas = new();
    private int _siguienteId = 1;

    public IReadOnlyList<Reserva> Listar() => _reservas;

    public Reserva? BuscarPorId(int id) => _reservas.FirstOrDefault(r => r.Id == id);

    public (Reserva? Reserva, string? Error) CrearReserva(SolicitudReserva s)
    {
        if (string.IsNullOrWhiteSpace(s.Cancha) || string.IsNullOrWhiteSpace(s.Cliente))
            return (null, "La cancha y el cliente son obligatorios.");

        if (s.Horas < 1 || s.Horas > MaxHoras)
            return (null, $"La reserva debe durar entre 1 y {MaxHoras} horas.");

        var fin = s.Inicio.AddHours(s.Horas);
        bool choca = _reservas.Any(r => r.Cancha == s.Cancha
                                     && s.Inicio < r.Inicio.AddHours(r.Horas)
                                     && r.Inicio < fin);
        if (choca)
            return (null, "La cancha ya está reservada en ese horario.");

        var reserva = new Reserva(_siguienteId++, s.Cancha, s.Cliente, s.Inicio, s.Horas);
        _reservas.Add(reserva);
        return (reserva, null);
    }
}
