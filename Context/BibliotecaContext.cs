using Microsoft.EntityFrameworkCore;;

public class ConquistadoresContext : DbContext
{
    public DbSet<Persona> Personas { get; set; }
    public DbSet<Unidad> Unidades { get; set; }
    public DbSet<Especialidad> Especialidades { get; set; }
    public DbSet<Rol> Roles { get; set; }

    public ConquistadoresContext(DbContextOptions<ConquistadoresContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configuración para el modelo Persona
        modelBuilder.Entity<Persona>(entity =>
        {
            entity.Property(p => p.Nombre).IsRequired().HasMaxLength(100);
            entity.Property(p => p.Tipo).IsRequired().HasMaxLength(50);
            
            // Relación entre Persona y Especialidades (uno a muchos)
            entity.HasMany(p => p.EspecialidadesTerminadas)
                  .WithMany()
                  .UsingEntity(j => j.ToTable("PersonaEspecialidades"));
        });

        // Configuración para el modelo Unidad
        modelBuilder.Entity<Unidad>(entity =>
        {
            entity.Property(u => u.Nombre).IsRequired().HasMaxLength(100);
            entity.Property(u => u.Clase).IsRequired().HasMaxLength(50);

            // Relación de Unidad con Personas (Conquistadores y Consejeros)
            entity.HasMany(u => u.Conquistadores)
                  .WithMany(p => p.Unidades)
                  .UsingEntity(j => j.ToTable("UnidadConquistadores"));

            entity.HasMany(u => u.Consejeros)
                  .WithMany(p => p.Unidades)
                  .UsingEntity(j => j.ToTable("UnidadConsejeros"));

            // Relación uno a uno para el director de la Unidad
            entity.HasOne(u => u.Director)
                  .WithMany()
                  .HasForeignKey("DirectorId"); // Director es una persona
        });

        // Configuración para el modelo Especialidad
        modelBuilder.Entity<Especialidad>(entity =>
        {
            entity.Property(e => e.Nombre).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Tipo).IsRequired().HasMaxLength(50);
        });

        // Configuración para el modelo Rol
        modelBuilder.Entity<Rol>(entity =>
        {
            entity.Property(r => r.Nombre).IsRequired().HasMaxLength(50);
        });

        // Relación entre Personas y Roles
        modelBuilder.Entity<Persona>()
            .HasOne(p => p.Rol)
            .WithMany()
            .HasForeignKey("RolId"); // Cada persona puede tener un rol
    }
}
