using Axios.Data;
using Axios.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Axios.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlarmaController : ControllerBase
    {
        private readonly AxiosContext _context;
        public AlarmaController(AxiosContext context) 
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Alarma>>> GetAlarmas()
        {
            return await _context.Alarmas.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Alarma>> GetAlarmaById(int id)
        {
            var alarma = await _context.Alarmas.FindAsync(id);
            if (alarma == null)
                return NotFound();
            return Ok(alarma);
        }
        [HttpPost]
        public async Task<ActionResult<Alarma>> AddAlarma(Alarma NuevaAlarma)
        {
            if (NuevaAlarma == null)
                return BadRequest();

            _context.Alarmas.Add(NuevaAlarma);
            await _context.SaveChangesAsync();  

            return CreatedAtAction(nameof(GetAlarmaById), new { id = NuevaAlarma.Id_Alarma }, NuevaAlarma);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAlarma(int id, Alarma AlarmaActualizada)
        {
            var alarma = await _context.Alarmas.FindAsync(id);
            if (alarma == null)
                return NotFound();

            alarma.Id_Alarma = AlarmaActualizada.Id_Alarma;
            alarma.Nombre = AlarmaActualizada.Nombre;
            alarma.Ruta = AlarmaActualizada.Ruta;

            await _context.SaveChangesAsync();

            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> BorrarAlarma (int id)
        {
            var alarma = await _context.Alarmas.FindAsync(id);
            if (alarma == null)
                return NotFound();

            _context.Alarmas.Remove(alarma);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
