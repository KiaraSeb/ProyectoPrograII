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
            entity.ToTable("Personas"); // Asegura que Persona mapee a la tabla "Personas"
            entity.Property(p => p.Nombre)
                .IsRequired()
                .HasMaxLength(100);
            
            // Relación con Unidad
            entity.HasOne(p => p.Unidad) // Cada persona pertenece a una unidad
                .WithMany(u => u.Personas) // Cada unidad tiene muchas personas
                .HasForeignKey(p => p.UnidadId); // Clave foránea UnidadId
        });

        // Configuración para Especialidad
        modelBuilder.Entity<Especialidad>(entity =>
        {
            entity.HasKey(e => e.EspecialidadId); 
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

            // Configuración de la relación con Persona (ya configurada en Persona)
            entity.HasMany(u => u.Personas)  // Relación uno a muchos con Persona
                .WithOne(p => p.Unidad) // Cada Persona pertenece a una Unidad
                .HasForeignKey(p => p.UnidadId); // Clave foránea en Persona (UnidadId)
        });
    }
}
