using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Dominio_GerenciadorLivros.Models;
using Dominio_GerenciadorLivros.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Projeto_MVC.Data;
using Projeto_MVC.Models;


namespace Projeto_MVC.Controllers
{
    public class LivrosController : Controller
    {
        /* private readonly ApplicationDbContext _context;

         public LivrosController(ApplicationDbContext context)
         {
             _context = context;
         }*/

        // GET: Livros
        public async Task<IActionResult> Index()
        {
            List<LivrosViewModel> ListaLivros = new List<LivrosViewModel>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44376/api/Livros/"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    ListaLivros = JsonConvert.DeserializeObject<List<LivrosViewModel>>(apiResponse);
                }
            }
            return View(ListaLivros);
        }

        // GET: Livros/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            var livro = new LivrosViewModel();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44376/api/Livros/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    livro = JsonConvert.DeserializeObject<LivrosViewModel>(apiResponse);
                }
            }
            return View(livro);
        }

        // GET: Livros/Create
        public ViewResult Create() => View();

        // POST: Livros/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LivrosViewModel livro)
        {
           LivrosViewModel livros = new LivrosViewModel();
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(livro), Encoding.UTF8, "application/json");
                using (var response = await httpClient.PostAsync("https://localhost:44376/api/livros/", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    livros = JsonConvert.DeserializeObject<LivrosViewModel>(apiResponse);
                }
            }
            return RedirectToAction(nameof(Details), new { id = livros.Id });
        }
    

        // GET: Livros/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            LivrosViewModel livros = new LivrosViewModel();
            using(var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44376/api/Livros/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    livros = JsonConvert.DeserializeObject<LivrosViewModel>(apiResponse);
                }
            }
            return View(livros);
        }

        // POST: Livros/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(LivrosViewModel livro)
        {
            LivrosViewModel livroEdit = new LivrosViewModel();
            using(var httpClient = new HttpClient())
            {
                var content = new MultipartFormDataContent();
                content.Add(new StringContent(livro.Id.ToString()), "Id");
                content.Add(new StringContent(livro.Titulo.ToString()), "Titulo");
                content.Add(new StringContent(livro.ISBN.ToString()), "ISBN");
                content.Add(new StringContent(livro.Ano.ToString()), "Ano");

                using (var response = await httpClient.PutAsync("https://localhost:44376/api/Livros/", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    livroEdit = JsonConvert.DeserializeObject<LivrosViewModel>(apiResponse);
                }
            }
            return RedirectToAction(nameof(Details), new { id = livroEdit.Id });
        }

     
        public async Task<IActionResult> Delete(Guid id)
        {
            using(var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync("https://localhost:44376/api/Livros/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
                return RedirectToAction(nameof(Index));
            }
            
        }

       
    }
}
