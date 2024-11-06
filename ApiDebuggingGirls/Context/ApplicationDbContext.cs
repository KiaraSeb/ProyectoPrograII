using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

// Contexto de base de datos que incluye tablas de Identity y entidades personalizadas
public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Clase> Clases { get; set; }
    public DbSet<Unidad> Unidades { get; set; }  // Asegúrate de que Unidad esté definida como entidad
}
