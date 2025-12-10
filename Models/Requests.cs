namespace VeterinariaApi.Models;

// ====================================================
// ESTOS SON LOS DATOS QUE FLUTTER DEBE ENVIAR EN JSON
// ====================================================

// 1. Para Adopciones
public record AdopcionRequest(
    int IdMascota,
    int IdPostulante,
    decimal Pago
);

// 2. Para Mascotas (Cliente y Rescatada)
public record MascotaClienteRequest(
    int IdCliente, 
    string Alias, 
    string Especie, 
    string Raza, 
    string Sexo, 
    DateTime FechaNacimiento, 
    decimal Peso, 
    string Color
);

public record MascotaRescatadaRequest(
    string Alias, 
    string Especie, 
    string Raza, 
    string Sexo, 
    string LugarRescate, 
    decimal Peso, 
    string Observaciones
);

// 3. Para Clínica (Consultas y Vacunas)
public record ConsultaMedicaRequest(
    int IdMascota,
    int IdVeterinario,
    string Diagnostico,
    string Tratamiento,
    decimal Temperatura,
    decimal Costo,
    bool EsBonificable
);

public record VacunaRequest(
    int IdMascota,
    int IdVacuna,
    string Lote,
    string Veterinario
);

// 4. Para Gestión Diaria
public record PostulanteRequest(
    string Nombre, 
    string Dni, 
    string Telefono, 
    string Email, 
    string Condiciones, 
    string Intereses
);

public record AporteRequest(
    int IdMecenas,
    int? IdMascota, // Puede ser null
    decimal Monto,
    string MetodoPago,
    string Comprobante
);

public record ConsumoRefugioRequest(
    int IdMascota,
    int IdServicio,
    int Cantidad,
    string Observaciones
);

// 5. Para Gestión de Familias y Peso
public record ClienteFamiliaRequest(
    string ApellidoCabeza,
    string CuentaBancaria,
    string Direccion,
    string Telefono,
    string Email,
    string DniCabeza,
    string NombreCabeza
);

public record IntegranteRequest(
    int IdCliente,
    string NombreCompleto,
    string Dni,
    string Rol 
);

public record PesoRequest(
    int IdMascota,
    decimal NuevoPeso,
    string EstadoNutricional 
);