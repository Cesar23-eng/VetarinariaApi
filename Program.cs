using Microsoft.EntityFrameworkCore;
using VeterinariaApi.Data; // <--- AHORA ESTO DEJARÁ DE ESTAR GRIS

var builder = WebApplication.CreateBuilder(args);

// =========================================================================
// 1. CONFIGURACIÓN DE CORS (CRÍTICO PARA FLUTTER WEB)
// =========================================================================
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFlutterDev", policy =>
    {
        policy.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

// =========================================================================
// 2. CONEXIÓN A BASE DE DATOS (¡ESTO ES LO QUE TE FALTABA!)
// =========================================================================
// Sin esto, la aplicación no sabe qué es AppDbContext y falla con Error 500
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
// =========================================================================

// 3. Agregar servicios estándar (Controladores y Swagger)
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// =========================================================================
// 4. PIPELINE DE LA APLICACIÓN (ORDEN IMPORTANTE)
// =========================================================================

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection(); // <--- Mantenlo comentado para evitar líos de SSL local

// ¡ACTIVAR CORS ANTES DE AUTH Y CONTROLADORES!
app.UseCors("AllowFlutterDev");

app.UseAuthorization();

app.MapControllers();

app.Run();