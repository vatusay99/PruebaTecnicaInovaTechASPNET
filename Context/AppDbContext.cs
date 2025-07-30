using Microsoft.EntityFrameworkCore;
using ProductosApiRest.Models;

namespace ProductosApiRest.Context
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
            
        }

        public DbSet<Producto> Producto { get; set; } = null!;
    }
}
