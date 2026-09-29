# API de reservas de canchas

Repositorio de demostración de Programación III para la sesión de resolución de conflictos.

## Ejecutar

```
dotnet run
```

La API queda en http://localhost:5080. El archivo `reservas.http` trae peticiones listas para
probar desde VS Code con la extensión REST Client.

## Endpoints

| Método | Ruta | Qué hace |
|---|---|---|
| GET | /reservas | Lista las reservas |
| GET | /reservas/{id} | Busca una reserva |
| POST | /reservas | Crea una reserva |
