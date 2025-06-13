using MyApp.API.Domain;
using MyApp.API.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace MyApp.API.Services
{
    public class PedidoService
    {
        private readonly AppDbContext _context;

        public PedidoService(AppDbContext context) => _context = context;

        public async Task<List<Pedido>> GetAllAsync() => await _context.Pedidos.ToListAsync();
        public async Task<Pedido?> GetByIdAsync(int id) => await _context.Pedidos.FindAsync(id);
        public async Task<Pedido> CreateAsync(Pedido pedido)
        {
            _context.Pedidos.Add(pedido);
            await _context.SaveChangesAsync();
            return pedido;
        }
        public async Task<Pedido?> UpdateAsync(int id, Pedido pedido)
        {
            var existing = await _context.Pedidos.FindAsync(id);
            if (existing == null) return null;

            existing.Fecha = pedido.Fecha;
            existing.UsuarioId = pedido.UsuarioId;
            await _context.SaveChangesAsync();
            return existing;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Pedidos.FindAsync(id);
            if (entity == null) return false;

            _context.Pedidos.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
