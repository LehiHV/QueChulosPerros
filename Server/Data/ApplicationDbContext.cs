using Microsoft.EntityFrameworkCore;
using QueChulosPerros.Shared.Model;

namespace QueChulosPerros.Server.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Cita> Citas { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Mascota> Mascotas {  get; set; } 
        public DbSet<Trabajador> Trabajadores { get; set; }
    }
}
