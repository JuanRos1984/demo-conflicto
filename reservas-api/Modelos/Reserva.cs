namespace ReservasApi.Modelos;

public record Reserva(int Id, string Cancha, string Cliente, DateTime Inicio, int Horas);

public record SolicitudReserva(string Cancha, string Cliente, DateTime Inicio, int Horas);
