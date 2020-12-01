using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio_GerenciadorLivros.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Projeto_MVC.Data;

namespace Projeto_MVC.Controllers
{
    public class AutoresController : Controller
    {
        // GET: Autors
        public async Task<IActionResult> Index()
        {
            return View();
        }

        // GET: Autors/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            

            return View(autor);
        }

        // GET: Autors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Autors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Sobrenome,Email,DataNascimento")] Autor autor)
        {
            
            return View(autor);
        }

        // GET: Autors/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            
            return View(autor);
        }

        // POST: Autors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Nome,Sobrenome,Email,DataNascimento")] Autor autor)
        {
           
            return View(autor);
        }

        // GET: Autors/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            

            return View(autor);
        }

        // POST: Autors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            
        }

        private bool AutorExists(Guid id)
        {
            return ;
        }
    }
}
