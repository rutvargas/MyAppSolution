using MyApp.API.Domain;
using MyApp.API.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace MyApp.API.Services
{
    public class DetallePedidoService
    {
        private readonly AppDbContext _context;

        public DetallePedidoService(AppDbContext context) => _context = context;

        public async Task<List<DetallePedido>> GetAllAsync() => await _context.DetallesPedido.ToListAsync();
        public async Task<DetallePedido?> GetByIdAsync(int id) => await _context.DetallesPedido.FindAsync(id);
        public async Task<DetallePedido> CreateAsync(DetallePedido detalle)
        {
            _context.DetallesPedido.Add(detalle);
            await _context.SaveChangesAsync();
            return detalle;
        }
        public async Task<DetallePedido?> UpdateAsync(int id, DetallePedido detalle)
        {
            var existing = await _context.DetallesPedido.FindAsync(id);
            if (existing == null) return null;

            existing.PedidoId = detalle.PedidoId;
            existing.ProductoId = detalle.ProductoId;
            existing.Cantidad = detalle.Cantidad;
            await _context.SaveChangesAsync();
            return existing;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.DetallesPedido.FindAsync(id);
            if (entity == null) return false;

            _context.DetallesPedido.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
