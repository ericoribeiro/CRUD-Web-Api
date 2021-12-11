using System.Linq;
using System.Threading.Tasks;
using api.Auth;
using api.EF;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly EFContext _context; 

        public AuthController(EFContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<dynamic>> Authenticate(Login login)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == login.UserName && x.Password == login.Password);

            if(user == null)
                return NotFound(new {menssage = "Usuário ou senha inválidos"});

            var token = TokenService.GenerateToken(user);

            user.Password = "";

            return new { user = user, token = token }; 
        }
    }
}