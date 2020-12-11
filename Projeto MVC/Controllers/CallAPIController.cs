using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Dominio_GerenciadorLivros.Models;
using Dominio_GerenciadorLivros.Token;
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
        public async Task<IActionResult> Index(Login log)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(log), Encoding.UTF8, "application/json");
            using (var httpclient = new HttpClient())
            {
                using (var response = await httpclient.PostAsync("https://localhost:44376/api/Usuario", content))
                {
                    if (!response.IsSuccessStatusCode)
                    {
                        return Unauthorized();
                    }

                    string apiResponse = await response.Content.ReadAsStringAsync();
                    Token.GerarToken = apiResponse;
                }
            }
            return RedirectToAction("Index", "Livros");
        }

    }
}
