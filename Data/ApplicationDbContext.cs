using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using appejemplo2.Models;

namespace appejemplo2.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)//constructor
        : base(options)
    {
    }
     public DbSet<appejemplo2.Models.Contacto> DataContacto { get; set; }
}
