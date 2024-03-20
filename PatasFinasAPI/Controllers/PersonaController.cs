using Microsoft.AspNetCore.Mvc;
using PatasFinasAPI.Models;
using System.Reflection.Metadata;

namespace PatasFinasAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonaController : Controller
    {
        private readonly db_Patas_FinasContext BD;

        public PersonaController(db_Patas_FinasContext context)
        {
            BD = context;
        }

        [HttpGet]
        public IEnumerable<Persona> ListaDePersonas()
        {
            return BD.Personas.ToList();
        }

        [HttpGet("{id}", Name = "ObtenerPersona")]
        public IActionResult obtenerPersona(int id)
        {
            var persona = BD.Personas.FirstOrDefault(person => person.IdPersona == id);

            if(persona == null)
            {
                return NotFound("El Id proporsionado "+id+" no existe");
            }
            return Ok(persona);
        }

        [HttpPost()]
        public IActionResult AddPersona([FromBody] Persona pPersona)
        {
            if (ModelState.IsValid)
            {
                var verifica = BD.Personas.FirstOrDefault(person => person.Correo == pPersona.Correo);
                if(verifica != null)
                {
                    return Conflict("Mi socio este correo ya esta registrado");
                }
                BD.Personas.Add(pPersona);
                BD.SaveChanges();

                return new CreatedAtRouteResult("Nuevos Datos Agregados", new { id = pPersona }, pPersona);
            }
            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        public IActionResult ModificarPersona([FromBody] Persona pPersona, int id)
        {
            if(pPersona.IdPersona != id)
            {
                return BadRequest("El codigo proporcionado " + id + " no se encuentra");
            }
            BD.Entry(pPersona).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            BD.SaveChanges();

            return Ok("Datos Modificados");
        }

        [HttpDelete("{id}")]
        public IActionResult BorrarPersona(int id)
        {
            var persona = BD.Personas.FirstOrDefault(person => person.IdPersona == id);

            if (persona == null)
            {
                return NotFound("El ID proporcionado "+id+" no existe");
            }
            BD.Personas.Remove(persona);
            BD.SaveChanges();

            return Ok(persona);
        }
    }
}
