using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Projeto_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        [HttpPost]
        public ActionResult Login(Login usuario)
        {
            if (usuario.Usuario == "Usuario" && usuario.Senha == "123456")
            {
                var token = GenerateJSONWebToken();

                return Ok(token);
            }
            else
            {
                return BadRequest();
            }
        }

        private string GenerateJSONWebToken()
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("assessmentaspnetdoodio"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: "https://www.infnet.edu.br",
                audience: "https://www.infnet.edu.br",
                expires: DateTime.Now.AddHours(3),
                signingCredentials: credentials
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
