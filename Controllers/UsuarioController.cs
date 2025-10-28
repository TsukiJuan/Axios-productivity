using System.Threading;
using Axios.Data;
using Axios.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Axios.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly AxiosContext _context;
        public UsuarioController(AxiosContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Usuario>>> GetUsuarios()
        {
            return Ok(await _context.Usuarios.ToListAsync());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetUsuarioById(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
                return NotFound();
            return Ok(usuario);
        }
        [HttpPost]
        public async Task<ActionResult<Usuario>> AddUsuario(Usuario NuevoUsuario)
        {
            if (NuevoUsuario == null)
                return BadRequest();


            _context.Usuarios.Add(NuevoUsuario);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUsuarioById), new { id = NuevoUsuario.Id_Usuario }, NuevoUsuario);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUsuario(int id, Usuario UsuarioActualizado)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
                return NotFound();

            usuario.Id_Usuario = UsuarioActualizado.Id_Usuario;
            usuario.Nombre = UsuarioActualizado.Nombre;
            usuario.Correo = UsuarioActualizado.Correo;
            usuario.Contraseña = UsuarioActualizado.Contraseña;

            await _context.SaveChangesAsync();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> BorrarUsuario (int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
                return NotFound();

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
