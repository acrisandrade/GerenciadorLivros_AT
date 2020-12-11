using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Dominio_GerenciadorLivros.Models;
using Dominio_GerenciadorLivros.Token;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Projeto_MVC.Data;

namespace Projeto_MVC.Controllers
{
    //[Authorize] 
    public class AutoresController : Controller
    {
        // GET: Autors
        public async Task<IActionResult> Index()
        { 
            List<Autor> ListaAutores = new List<Autor>();
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token.GerarToken);
                using (var response = await httpClient.GetAsync("https://localhost:44376/api/autores/"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    ListaAutores = JsonConvert.DeserializeObject<List<Autor>>(apiResponse);
                }
            }
            return View(ListaAutores);
        }

        // GET: Autors/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            var autor = new Autor();
            using(var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token.GerarToken);
                using (var reponse = await httpClient.GetAsync("https://localhost:44376/api/autores/" + id))
                {
                    string apiResponse = await reponse.Content.ReadAsStringAsync();
                    autor = JsonConvert.DeserializeObject<Autor>(apiResponse);
                }
            }
            return View(autor);
        }

        // GET: Autors/Create
        public ViewResult Create() => View();

        // POST: Autors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Autor autor)
        {
            Autor autores = new Autor();
            using(var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(autor), Encoding.UTF8, "application/json");
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token.GerarToken);
                using (var response = await httpClient.PostAsync("https://localhost:44376/api/autores/", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    autores = JsonConvert.DeserializeObject<Autor>(apiResponse);
                }
            }
            return RedirectToAction(nameof(Details), new { id = autores.Id });
        }

        // GET: Autors/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            Autor autor = new Autor();
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token.GerarToken);
                using (var response = await httpClient.GetAsync("https://localhost:44376/api/autores/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    autor = JsonConvert.DeserializeObject<Autor>(apiResponse);
                }
            }
            return View(autor);
        }

        // POST: Autors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit( Autor autor)
        {
            Autor autorEdit = new Autor();
            using(var httpClient = new HttpClient())
            {
                var content = new MultipartFormDataContent();
                content.Add(new StringContent(autor.Id.ToString()), "Id");
                content.Add(new StringContent(autor.Nome.ToString()), "Nome");
                content.Add(new StringContent(autor.Sobrenome.ToString()), "Sobrenome");
                content.Add(new StringContent(autor.Email.ToString()), "Email");
                // content.Add(new StringContent(autor.Livros.ToString()), "Livros");

                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token.GerarToken);
                using (var response = await httpClient.PutAsync("https://localhost:44376/api/autores/", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    autorEdit = JsonConvert.DeserializeObject<Autor>(apiResponse);
                }
            }
            return RedirectToAction(nameof(Details), new { id = autorEdit.Id });
            
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token.GerarToken);
                using (var response = await  httpClient.DeleteAsync("https://localhost:44376/api/autores/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
                return RedirectToAction(nameof(Create));
            }
            
        }
    }
}
