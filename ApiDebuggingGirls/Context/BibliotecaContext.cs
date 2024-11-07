using Microsoft.EntityFrameworkCore;

public class BibliotecaContext : DbContext
{ 
    public DbSet<Clase> Clases { get; set; }
    public DbSet<Persona> Personas { get; set; }
    public DbSet<Especialidad> Especialidades { get; set; }
    public DbSet<Unidad> Unidades { get; set; }

    public BibliotecaContext(DbContextOptions<BibliotecaContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configuración para Clase
        modelBuilder.Entity<Clase>(entity =>
        {
            entity.Property(c => c.Nombre)
                .IsRequired()
                .HasMaxLength(100);
        });

        // Configuración para Persona
        modelBuilder.Entity<Persona>(entity =>
        {
            entity.Property(p => p.Nombre)
                .IsRequired()
                .HasMaxLength(100);
            entity.Property(p => p.Apellido)
                .IsRequired()
                .HasMaxLength(100);
            entity.Property(p => p.Email)
                .IsRequired()
                .HasMaxLength(100);
        });

        // Configuración para Especialidad
        modelBuilder.Entity<Especialidad>(entity =>
        {
            entity.HasKey(e => e.EspecialidadId); // Define Id como clave primaria
            entity.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(100);
            entity.Property(e => e.Tipo) // Cambia de Descripcion a Tipo
                .IsRequired(false)
                .HasMaxLength(200);
        });

        // Configuración para Unidad
        modelBuilder.Entity<Unidad>(entity =>
        {
            entity.Property(u => u.Nombre)
                .IsRequired()
                .HasMaxLength(100);
            entity.Property(u => u.Descripcion)
                .IsRequired(false)
                .HasMaxLength(200);
        });
    }
}
