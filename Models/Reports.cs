using System.ComponentModel.DataAnnotations.Schema;

namespace VeterinariaApi.Models;

// ====================================================
// IMPORTANTE: Los nombres de estas propiedades coinciden
// EXACTAMENTE con los alias de tus VISTAS SQL.
// NO LOS CAMBIES O DEJARÁ DE FUNCIONAR.
// ====================================================

// Mapeo de VW_OPORTUNIDADES_ADOPCION
public class OportunidadAdopcion
{
    public string Interesado { get; set; }
    public string Lo_Que_Busca { get; set; }
    public string Su_Casa { get; set; }
    public string Contacto { get; set; }
    public string Mascota_Disponible { get; set; }
    
    // En SQL están en minúsculas, aquí también:
    public string especie { get; set; } 
    public string raza { get; set; }
    public string sexo { get; set; }
    public decimal peso_actual { get; set; } // SQL es DECIMAL, C# debe ser decimal
    public string Detalles_Mascota { get; set; }
}

// Mapeo de VW_ESTADO_CUENTA_RESCATADOS
public class EstadoCuentaRescatado // Nota: Quité la 's' final para estandarizar
{
    public int id_mascota { get; set; } // SQL devuelve "id_mascota"
    public string alias { get; set; }
    public string estado_adopcion { get; set; }
    public decimal Total_Gastos_Medicos { get; set; }
    public decimal Total_Gastos_Refugio { get; set; }
    public decimal Total_Donaciones { get; set; }
    public decimal Saldo_Pendiente_Por_Cubrir { get; set; }
}

// Mapeo de VW_SEGUIMIENTO_VISITAS
public class SeguimientoVisita
{
    public int id_adopcion { get; set; } 
    public string Familia_Adoptante { get; set; }
    public string Mascota { get; set; }
    public DateTime fecha_visita { get; set; }
    public string Quien_Visito { get; set; }
    public string Resultado { get; set; }
    public string Estado_Visita { get; set; }
}

// Mapeo de VW_BONOS_VETERINARIO
public class BonoVeterinario
{
    // Asumiendo que la vista SQL devuelve: nombre, apellido, atenciones_bonificables...
    public string nombre { get; set; }
    public string apellido { get; set; }
    public int atenciones_bonificables { get; set; }
    public decimal total_bono_estimado { get; set; }
}

// Mapeo del reporte del Cursor (Tabla temporal interna)
public class ReporteAuditoria
{
    public string Mascota { get; set; }
    public decimal Gasto_Total { get; set; }
    public string Nivel_Alerta { get; set; }
}