using Microsoft.EntityFrameworkCore;
using MyApp.API.Infrastructure;
using MyApp.API.Services;

namespace MyApp.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Servicios
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();



            // Configurar DB en memoria
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseInMemoryDatabase("MiBaseDatos"));

            // Registrar servicio
            builder.Services.AddScoped<UsuarioService>();
            builder.Services.AddScoped<ProductoService>();
            builder.Services.AddScoped<CategoriaService>();
            builder.Services.AddScoped<PedidoService>();
            builder.Services.AddScoped<DetallePedidoService>();


            var app = builder.Build();

            // Swagger
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}
