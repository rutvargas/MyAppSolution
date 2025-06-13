using Microsoft.AspNetCore.Mvc;
using MyApp.API.Domain;
using MyApp.API.Services;

namespace MyApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductosController : ControllerBase
    {
        private readonly ProductoService _service;

        public ProductosController(ProductoService service) => _service = service;

        [HttpGet] public async Task<IActionResult> Get() => Ok(await _service.GetAllAsync());
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var item = await _service.GetByIdAsync(id);
            return item == null ? NotFound() : Ok(item);
        }
        [HttpPost]
        public async Task<IActionResult> Post(Producto producto)
        {
            var nuevo = await _service.CreateAsync(producto);
            return CreatedAtAction(nameof(Get), new { id = nuevo.Id }, nuevo);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Producto producto)
        {
            var actualizado = await _service.UpdateAsync(id, producto);
            return actualizado == null ? NotFound() : Ok(actualizado);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var eliminado = await _service.DeleteAsync(id);
            return eliminado ? NoContent() : NotFound();
        }
    }
}
