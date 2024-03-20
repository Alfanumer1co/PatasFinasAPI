using Microsoft.AspNetCore.Mvc;
using PatasFinasAPI.Models;

namespace PatasFinasAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductoController : Controller
    {
        private readonly db_Patas_FinasContext BD;
        public ProductoController(db_Patas_FinasContext context)
        {
            BD = context;
        }

        [HttpGet]
        public IEnumerable<Producto> ListaDeProductos()
        {
            return BD.Productos.ToList();
        }

        [HttpGet("{id}", Name = "ObtenerProducto")]
        public  IActionResult obtenerProducto(int id)
        {
            var producto = BD.Productos.FirstOrDefault(pro => pro.IdProducto == id);

            if(producto == null)
            {
                return NotFound("No se encontro el Producto con el ID => " + id);
            }
            return Ok(producto);
        }

        [HttpPost()]
        public IActionResult AddProducto([FromBody] Producto pProducto)
        {
            if (ModelState.IsValid)
            {
                BD.Productos.Add(pProducto);
                BD.SaveChanges();

                return new CreatedAtRouteResult("Producto Creado", new { id = pProducto }, pProducto);
            }
            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        public IActionResult ModificarProducto([FromBody] Producto pProducto, int id)
        {
            if(pProducto.IdProducto != id)
            {
                return BadRequest("Mi loco este codigo "+id+" no esta registrado");
            }
            BD.Entry(pProducto).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            BD.SaveChanges();

            return Ok("Producto Modificado");
        }

        [HttpDelete("{id}")]
        public IActionResult EliminarProducto(int id)
        {
            var producto = BD.Productos.FirstOrDefault(prod => prod.IdProducto == id);

            if( producto == null)
            {
                return NotFound("El id proporcionado "+id+" no existe");
            }
            BD.Productos.Remove(producto);
            BD.SaveChanges();

            return Ok(producto);
        }
    }
}
