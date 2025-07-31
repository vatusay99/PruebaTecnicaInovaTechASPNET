using API_Productos.Modelos;
using Microsoft.EntityFrameworkCore;

namespace API_Productos.Data
{
    public class AplicationDbContext: DbContext
    {
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options): base(options){}

        // <pasar todos las entidades
        public DbSet<Producto> Productos { get; set; }
    }
}
