using Axios.Data;
using Axios.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Axios.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TareaController : ControllerBase
    {
        private readonly AxiosContext _context;
        public TareaController(AxiosContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Tarea>>> GetTareas()
        {
            return Ok(await _context.Tareas.ToListAsync());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetTareaById(int id)
        {
            var tarea = await _context.Tareas.FindAsync(id);
            if (tarea == null)
                return NotFound();
            return Ok(tarea);
        }
        [HttpPost]
        public async Task<ActionResult<Tarea>> AddTarea(Tarea NuevaTarea)
        {
            if (NuevaTarea == null)
                return BadRequest();

            _context.Tareas.Add(NuevaTarea);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTareaById), new { id = NuevaTarea.Id_Tarea }, NuevaTarea);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTarea(int id, Tarea TareaActualizada)
        {
            var tarea = await _context.Tareas.FindAsync(id);
            if (tarea == null)
                return NotFound();

            tarea.Id_Tarea = TareaActualizada.Id_Tarea;
            tarea.Titulo = TareaActualizada.Titulo;
            tarea.Descripcion = TareaActualizada.Descripcion;
            tarea.Fecha_Limite = TareaActualizada.Fecha_Limite;
            tarea.Hora = TareaActualizada.Hora;
            tarea.ID_Usuario = TareaActualizada.ID_Usuario;
            tarea.ID_Alarma = TareaActualizada.ID_Alarma;

            await _context.SaveChangesAsync();

            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> BorrarTarea (int id)
        {
            var tarea = await _context.Tareas.FindAsync(id);
            if (tarea == null)
                return NotFound();

            _context.Tareas.Remove(tarea);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
