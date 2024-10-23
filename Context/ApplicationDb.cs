using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

//Esto se usa para manejar las tablas para el login y todo eso, que ya viene definido en la libreria
public class ApplicationDb : IdentityDbContext<ApplicationUser>
{
    public ApplicationDb(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
}