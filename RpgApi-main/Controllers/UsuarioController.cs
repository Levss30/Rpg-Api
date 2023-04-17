using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RpgApi.Data;
using RpgApi.Models;

namespace RpgApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly DataContext _context;

        public UsuariosController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("GetUser")]
        public async Task<IActionResult> Get(Usuario u)
        {
            try
            {
                Usuario? uRetornado = await _context.Usuarios
                    .FirstOrDefaultAsync(x => x.Username == u.Username && x.Email == u.Email);

                if (uRetornado == null)
                    throw new Exception("Usuário não encontrado");

                return Ok(uRetornado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}