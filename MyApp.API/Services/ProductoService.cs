using MyApp.API.Domain;
using MyApp.API.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace MyApp.API.Services
{
    public class ProductoService
    {
        private readonly AppDbContext _context;

        public ProductoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Producto>> GetAllAsync() => await _context.Productos.ToListAsync();

        public async Task<Producto?> GetByIdAsync(int id) => await _context.Productos.FindAsync(id);

        public async Task<Producto> CreateAsync(Producto producto)
        {
            _context.Productos.Add(producto);
            await _context.SaveChangesAsync();
            return producto;
        }

        public async Task<Producto?> UpdateAsync(int id, Producto producto)
        {
            var existing = await _context.Productos.FindAsync(id);
            if (existing == null) return null;

            existing.Nombre = producto.Nombre;
            existing.Precio = producto.Precio;
            existing.CategoriaId = producto.CategoriaId;
            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto == null) return false;
            _context.Productos.Remove(producto);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
