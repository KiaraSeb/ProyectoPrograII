using Microsoft.EntityFrameworkCore;

public class BibliotecaContext:DbContext
{
  public DbSet<Conquistador> Conquistadores {get; set;}
  public DbSet<Club> Clubs {get; set;}
  public DbSet<Unidad> Unidades {get; set;}

    public BibliotecaContext(DbContextOptions<BibliotecaContext> options) : base(options)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Conquistador>(entity =>
        {
          entity.Property(a => a.Nombre).IsRequired().HasMaxLength(100);
          entity.Property(a => a.Apellido).IsRequired().HasMaxLength(100);
        }
        );

        modelBuilder.Entity<Club>(entity =>
        {
          entity.Property(l => l.Titulo).IsRequired();
          entity.Property(l => l.Paginas).IsRequired();
          entity.Property(l => l.Ano).IsRequired();
          entity.Property(l => l.Url_Portada).IsRequired(false);

           entity.HasOne(l => l.Conquistador)
           .WithMany(a => a.Clubs)
           .HasForeignKey(l => l.ConquistadorId).IsRequired();

           entity.HasMany(l => l.Unidads)
           .WithMany(t => t.Clubs)
           .UsingEntity(j => j.ToTable("ClubUnidad") );
           
        }       
        );

        modelBuilder.Entity<Unidad>(entity => 
        {
          entity.Property(t => t.Nombre).IsRequired().HasMaxLength(50);
        }
        );

      

    }

} 