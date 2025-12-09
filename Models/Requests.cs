namespace VeterinariaApi.Models;

// Para sp_RegistrarAdopcion
public record AdopcionRequest(int IdMascota, int IdPostulante, decimal Pago);

// Para sp_RegistrarMascotaCliente
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

// Para sp_RegistrarRescatado
public record MascotaRescatadaRequest(
    string Alias, 
    string Especie, 
    string Raza, 
    string Sexo, 
    string LugarRescate, 
    decimal Peso, 
    string Observaciones
);

// Para sp_RegistrarConsulta
public record ConsultaMedicaRequest(
    int IdMascota,
    int IdVeterinario,
    string Diagnostico,
    string Tratamiento,
    decimal Temperatura,
    decimal Costo,
    bool EsBonificable
);

// ... (Mantén los records que ya tenías y agrega estos abajo)

// Para sp_RegistrarPostulante
public record PostulanteRequest(
    string Nombre, 
    string Dni, 
    string Telefono, 
    string Email, 
    string Condiciones, 
    string Intereses
);

// Para sp_RegistrarAporte
public record AporteRequest(
    int IdMecenas,
    int? IdMascota, // Puede ser null
    decimal Monto,
    string MetodoPago,
    string Comprobante
);

// Para sp_RegistrarConsumoRefugio
public record ConsumoRefugioRequest(
    int IdMascota,
    int IdServicio,
    int Cantidad,
    string Observaciones
);

// Para sp_RegistrarVacunacion
public record VacunaRequest(
    int IdMascota,
    int IdVacuna,
    string Lote,
    string Veterinario
);

// Para sp_RegistrarClienteFamilia (Crear nueva familia)
public record ClienteFamiliaRequest(
    string ApellidoCabeza,
    string CuentaBancaria,
    string Direccion,
    string Telefono,
    string Email,
    string DniCabeza,
    string NombreCabeza
);

// Para sp_AgregarIntegrante (Agregar un hijo/abuelo a la familia)
public record IntegranteRequest(
    int IdCliente,
    string NombreCompleto,
    string Dni,
    string Rol // Ej: 'Hijo', 'Esposo'
);

// Para sp_ActualizarPeso (Historial de peso sin consulta médica)
public record PesoRequest(
    int IdMascota,
    decimal NuevoPeso,
    string EstadoNutricional // Ej: 'Obesidad', 'Normal'
);