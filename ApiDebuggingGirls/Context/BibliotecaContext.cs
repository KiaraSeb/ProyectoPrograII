using Microsoft.EntityFrameworkCore;

public class BibliotecaContext : DbContext
{ 
    public DbSet<Clase> Clases { get; set; }
    public DbSet<Persona> Personas { get; set; }
    public DbSet<Especialidad> Especialidades { get; set; }
    public DbSet<Unidad> Unidades { get; set; }
    public DbSet<PersonaEspecialidad> PersonaEspecialidades { get; set; } // Agregar DbSet para PersonaEspecialidad

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
        });

        // Configuración para PersonaEspecialidad (relación muchos a muchos)
        modelBuilder.Entity<PersonaEspecialidad>(entity =>
        {
            entity.ToTable("PersonaEspecialidad"); // Asegura que mapee a la tabla "PersonaEspecialidad"
            entity.HasKey(pe => new { pe.PersonaId, pe.EspecialidadId }); // Define clave primaria compuesta

            // Configura las relaciones de clave foránea
            entity.HasOne<Persona>()
                .WithMany() // Asocia con la tabla Persona
                .HasForeignKey(pe => pe.PersonaId)
                .OnDelete(DeleteBehavior.Cascade); // Borra en cascada si es necesario

            entity.HasOne<Especialidad>()
                .WithMany() // Asocia con la tabla Especialidad
                .HasForeignKey(pe => pe.EspecialidadId)
                .OnDelete(DeleteBehavior.Cascade); // Borra en cascada si es necesario
        });
        
        modelBuilder.Entity<PersonaEspecialidad>(entity =>
        {
            entity.ToTable("PersonaEspecialidad"); // Mapea a la tabla "PersonaEspecialidad"
            
            entity.HasKey(pe => new { pe.PersonaId, pe.EspecialidadId }); // Define clave primaria compuesta

            entity.HasOne(pe => pe.Persona)
                .WithMany(p => p.PersonaEspecialidades) // Relación con Persona
                .HasForeignKey(pe => pe.PersonaId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(pe => pe.Especialidad)
                .WithMany(e => e.PersonaEspecialidades) // Relación con Especialidad
                .HasForeignKey(pe => pe.EspecialidadId)
                .OnDelete(DeleteBehavior.Cascade);
        });

    }
}
