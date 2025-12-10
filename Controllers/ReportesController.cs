using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VeterinariaApi.Data;

namespace VeterinariaApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReportesController(AppDbContext context) : ControllerBase
{
    [HttpGet("finanzas-rescatados")]
    public async Task<IActionResult> GetEstadoCuentas()
    {
        // Consume la Vista: VW_ESTADO_CUENTA_RESCATADOS
        var reporte = await context.EstadosCuenta.ToListAsync();
        return Ok(reporte);
    }

    [HttpGet("auditoria-alertas")]
    public async Task<IActionResult> GetAuditoriaConCursor()
    {
        // Este endpoint es especial: Llama al PROCEDURE que usa CURSORES
        // y devuelve el resultado de la tabla temporal interna.
        var resultado = await context.AuditoriaAlertas
            .FromSqlRaw("CALL sp_GenerarReporteAuditoria()")
            .ToListAsync();

        return Ok(resultado);
    }
    [HttpGet("seguimiento-visitas")]
    public async Task<IActionResult> GetVisitas()
    {
        // Consume la Vista: VW_SEGUIMIENTO_VISITAS
        var lista = await context.SeguimientoVisitas.ToListAsync();
        return Ok(lista);
    }
    // 4. Reporte de Bonos a Pagar (Nuevo Requisito)
    [HttpGet("pagos-bonificaciones")]
    public async Task<IActionResult> GetBonos()
    {
        try
        {
            var reporte = await context.BonosVeterinarios.ToListAsync();
            return Ok(reporte);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { error = "Error calculando bonos", detalle = ex.Message });
        }
    }
}
