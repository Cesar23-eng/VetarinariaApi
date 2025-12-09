using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VeterinariaApi.Data;
using VeterinariaApi.Models;

namespace VeterinariaApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GestionController(AppDbContext context) : ControllerBase // Primary Constructor (.NET 9)
{
    [HttpPost("mascota-cliente")]
    public async Task<IActionResult> RegistrarMascotaCliente([FromBody] MascotaClienteRequest req)
    {
        // LLAMADA DIRECTA AL SP: sp_RegistrarMascotaCliente
        await context.Database.ExecuteSqlRawAsync(
            "CALL sp_RegistrarMascotaCliente({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7})",
            req.IdCliente, req.Alias, req.Especie, req.Raza, req.Sexo, req.FechaNacimiento, req.Peso, req.Color
        );

        return Ok(new { mensaje = "Mascota registrada correctamente vía SP" });
    }

    [HttpPost("mascota-rescatada")]
    public async Task<IActionResult> RegistrarRescatado([FromBody] MascotaRescatadaRequest req)
    {
        // LLAMADA DIRECTA AL SP: sp_RegistrarRescatado
        await context.Database.ExecuteSqlRawAsync(
            "CALL sp_RegistrarRescatado({0}, {1}, {2}, {3}, {4}, {5}, {6})",
            req.Alias, req.Especie, req.Raza, req.Sexo, req.LugarRescate, req.Peso, req.Observaciones
        );

        return Ok(new { mensaje = "Rescate registrado correctamente vía SP" });
    }
    
    [HttpPost("consulta-medica")]
    public async Task<IActionResult> RegistrarConsulta([FromBody] ConsultaMedicaRequest req)
    {
        // LLAMADA DIRECTA AL SP: sp_RegistrarConsulta
        await context.Database.ExecuteSqlRawAsync(
            "CALL sp_RegistrarConsulta({0}, {1}, {2}, {3}, {4}, {5}, {6})",
            req.IdMascota, req.IdVeterinario, req.Diagnostico, req.Tratamiento, req.Temperatura, req.Costo, req.EsBonificable
        );
        return Ok(new { mensaje = "Consulta registrada vía SP" });
    }
    [HttpPost("postulante")]
    public async Task<IActionResult> RegistrarPostulante([FromBody] PostulanteRequest req)
    {
        await context.Database.ExecuteSqlRawAsync(
            "CALL sp_RegistrarPostulante({0}, {1}, {2}, {3}, {4}, {5})",
            req.Nombre, req.Dni, req.Telefono, req.Email, req.Condiciones, req.Intereses
        );
        return Ok(new { mensaje = "Postulante registrado." });
    }

    [HttpPost("aporte-mecenas")]
    public async Task<IActionResult> RegistrarAporte([FromBody] AporteRequest req)
    {
        await context.Database.ExecuteSqlRawAsync(
            "CALL sp_RegistrarAporte({0}, {1}, {2}, {3}, {4})",
            req.IdMecenas, req.IdMascota, req.Monto, req.MetodoPago, req.Comprobante
        );
        return Ok(new { mensaje = "Donación registrada." });
    }

    [HttpPost("consumo-refugio")]
    public async Task<IActionResult> RegistrarConsumo([FromBody] ConsumoRefugioRequest req)
    {
        await context.Database.ExecuteSqlRawAsync(
            "CALL sp_RegistrarConsumoRefugio({0}, {1}, {2}, {3})",
            req.IdMascota, req.IdServicio, req.Cantidad, req.Observaciones
        );
        return Ok(new { mensaje = "Gasto de refugio registrado." });
    }

    [HttpPost("vacunacion")]
    public async Task<IActionResult> RegistrarVacuna([FromBody] VacunaRequest req)
    {
        await context.Database.ExecuteSqlRawAsync(
            "CALL sp_RegistrarVacunacion({0}, {1}, {2}, {3})",
            req.IdMascota, req.IdVacuna, req.Lote, req.Veterinario
        );
        return Ok(new { mensaje = "Vacuna registrada." });
    }
    // ... (Tus otros métodos POST siguen aquí) ...

    // CONECTA: sp_RegistrarClienteFamilia
    [HttpPost("cliente-familia")]
    public async Task<IActionResult> RegistrarFamilia([FromBody] ClienteFamiliaRequest req)
    {
        await context.Database.ExecuteSqlRawAsync(
            "CALL sp_RegistrarClienteFamilia({0}, {1}, {2}, {3}, {4}, {5}, {6})",
            req.ApellidoCabeza, req.CuentaBancaria, req.Direccion, req.Telefono, req.Email, req.DniCabeza, req.NombreCabeza
        );
        return Ok(new { mensaje = "Familia y Cabeza de familia registrados exitosamente." });
    }

    // CONECTA: sp_AgregarIntegrante
    [HttpPost("integrante-familia")]
    public async Task<IActionResult> AgregarIntegrante([FromBody] IntegranteRequest req)
    {
        await context.Database.ExecuteSqlRawAsync(
            "CALL sp_AgregarIntegrante({0}, {1}, {2}, {3})",
            req.IdCliente, req.NombreCompleto, req.Dni, req.Rol
        );
        return Ok(new { mensaje = "Integrante agregado a la familia." });
    }

    // CONECTA: sp_ActualizarPeso
    [HttpPost("actualizar-peso")]
    public async Task<IActionResult> ActualizarPeso([FromBody] PesoRequest req)
    {
        await context.Database.ExecuteSqlRawAsync(
            "CALL sp_ActualizarPeso({0}, {1}, {2})",
            req.IdMascota, req.NuevoPeso, req.EstadoNutricional
        );
        return Ok(new { mensaje = "Peso actualizado e historial generado." });
    }
}