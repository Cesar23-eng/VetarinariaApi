namespace VeterinariaApi.Models;

// Mapeo de VW_OPORTUNIDADES_ADOPCION
public class OportunidadAdopcion
{
    public string Interesado { get; set; }
    public string Lo_Que_Busca { get; set; }
    public string Contacto { get; set; }
    public string Mascota_Disponible { get; set; }
    public string Especie { get; set; }
    public string Detalles_Mascota { get; set; }
}

// Mapeo de VW_ESTADO_CUENTA_RESCATADOS
public class EstadoCuentaRescatado
{
    public int Id_Mascota { get; set; }
    public string Alias { get; set; }
    public string Estado_Adopcion { get; set; }
    public decimal Total_Gastos_Medicos { get; set; }
    public decimal Total_Gastos_Refugio { get; set; }
    public decimal Total_Donaciones { get; set; }
    public decimal Saldo_Pendiente_Por_Cubrir { get; set; }
}

// Mapeo del reporte del Cursor (Tabla temporal)
public class ReporteAuditoria
{
    public string Mascota { get; set; }
    public decimal Gasto_Total { get; set; }
    public string Nivel_Alerta { get; set; }
}

// ... (Mantén lo anterior)

// Mapeo de VW_SEGUIMIENTO_VISITAS
public class SeguimientoVisita
{
    // El nombre de la propiedad debe coincidir con la columna de la vista
    public int Id_Adopcion { get; set; } 
    public string Familia_Adoptante { get; set; }
    public string Mascota { get; set; }
    public DateTime Fecha_Visita { get; set; }
    public string Quien_Visito { get; set; }
    public string Resultado { get; set; }
    public string Estado_Visita { get; set; }
}