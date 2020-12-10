using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Dominio_GerenciadorLivros.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace Projeto_MVC.Controllers
{
    public class CallAPIController : Controller
    {

        [HttpGet]
        public IActionResult Index() => View();
       

        [HttpPost]
        public async Task<IActionResult> Index(string Usuario , string Senha)
        {
            if((Usuario != "usuario") || (Senha != "senha"))
                return View((object)"Entre com usuario e senha");
            var tokenString = GenerateJSONWebToken();
            List<Livro> livro = new List<Livro>();
            using(var httpclient = new HttpClient())
            {
                httpclient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenString);
                using (var response = await httpclient.GetAsync("https://localhost:44376/api/livros"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    livro = JsonConvert.DeserializeObject<List<Livro>>(apiResponse);
                }
            }
            return View("Visualizacoes", livro);
        }

        private string GenerateJSONWebToken()
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("assessmentaspnetdoodio"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: "https://www.infnet.edu.br",
                audience: "https://www.infnet.edu.br",
                expires: DateTime.Now.AddDays(3),
                signingCredentials: credentials
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
