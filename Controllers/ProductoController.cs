using Microsoft.AspNetCore.Mvc;
using MiApi.Models;

namespace MiApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductosController : ControllerBase
    {
        private static List<Producto> productos = new()
        {
            new Producto { Id = 1, Nombre = "Laptop", Precio = 1200 },
            new Producto { Id = 2, Nombre = "Mouse", Precio = 25 }
        };

        [HttpGet]
        public ActionResult<IEnumerable<Producto>> Get()
        {
            return Ok(productos);
        }

        [HttpGet("{id}")]
        public ActionResult<Producto> GetById(int id)
        {
            var producto = productos.FirstOrDefault(p => p.Id == id);
            if (producto == null) return NotFound();
            return Ok(producto);
        }

        [HttpPost]
        public ActionResult<Producto> Create(Producto producto)
        {
            producto.Id = productos.Max(p => p.Id) + 1;
            productos.Add(producto);
            return CreatedAtAction(nameof(GetById), new { id = producto.Id }, producto);
        }
    }
}
