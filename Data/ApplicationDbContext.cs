using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using appejemplo2.Models;//agrgado

namespace appejemplo2.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)//constructor
        : base(options)
    {
    }
    public DbSet<appejemplo2.Models.Contacto> DataContacto { get; set; }
    public DbSet<appejemplo2.Models.Producto> DataProducto { get; set; }
    public DbSet<appejemplo2.Models.Proforma> DataProforma { get; set; }
    public DbSet<appejemplo2.Models.Pago> DataPago { get; set; }
    public DbSet<appejemplo2.Models.Pedido> DataPedido { get; set; }
    public DbSet<appejemplo2.Models.DetallePedido> DataDetallePedido { get; set; }
     public DbSet<appejemplo2.Models.Reserva> DataReserva { get; set; }
}
