using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VeterinariaApi.Data;
using VeterinariaApi.Models;

namespace VeterinariaApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AdopcionesController(AppDbContext context) : ControllerBase
{
    [HttpPost("procesar-adopcion")]
    public async Task<IActionResult> ProcesarAdopcion([FromBody] AdopcionRequest req)
    {
        try
        {
            // Este SP contiene la TRANSACCIÓN (START TRANSACTION / COMMIT) y validaciones
            await context.Database.ExecuteSqlRawAsync(
                "CALL sp_RegistrarAdopcion({0}, {1}, {2})",
                req.IdMascota, req.IdPostulante, req.Pago
            );

            return Ok(new { mensaje = "Adopción procesada exitosamente." });
        }
        catch (Exception ex)
        {
            // El SP lanza error si la mascota no es rescatada o el estado no es correcto
            return BadRequest(new { error = ex.Message });
        }
    }

    [HttpGet("oportunidades-match")]
    public async Task<IActionResult> GetOportunidades()
    {
        // Lectura directa de la VISTA SQL
        var lista = await context.OportunidadesAdopcion.ToListAsync();
        return Ok(lista);
    }
}