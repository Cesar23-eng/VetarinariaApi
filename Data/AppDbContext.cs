using Microsoft.EntityFrameworkCore;
using VeterinariaApi.Models;

namespace VeterinariaApi.Data;

public class AppDbContext : DbContext
{
    public DbSet<SeguimientoVisita> SeguimientoVisitas { get; set; }
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    // DbSets solo para lectura (Vistas)
    public DbSet<OportunidadAdopcion> OportunidadesAdopcion { get; set; }
    public DbSet<EstadoCuentaRescatado> EstadosCuenta { get; set; }
    public DbSet<ReporteAuditoria> AuditoriaAlertas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configuramos las Vistas como entidades sin llave primaria (Keyless)
        modelBuilder.Entity<OportunidadAdopcion>().HasNoKey().ToView("VW_OPORTUNIDADES_ADOPCION");
        modelBuilder.Entity<EstadoCuentaRescatado>().HasNoKey().ToView("VW_ESTADO_CUENTA_RESCATADOS");
        
        // Esta entidad no tiene vista fija, se llena via SP, así que la definimos sin llave
        modelBuilder.Entity<ReporteAuditoria>().HasNoKey();
        modelBuilder.Entity<SeguimientoVisita>().HasNoKey().ToView("VW_SEGUIMIENTO_VISITAS");
    }
}