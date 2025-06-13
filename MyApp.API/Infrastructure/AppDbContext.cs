using Microsoft.EntityFrameworkCore;
using MyApp.API.Domain;
using System.Collections.Generic;

namespace MyApp.API.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Producto> Productos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<DetallePedido> DetallesPedido { get; set; }




        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }
}
