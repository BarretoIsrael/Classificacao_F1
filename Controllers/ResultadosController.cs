using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Classificacao_F1.Data;
using Classificacao_F1.Models;

namespace Classificacao_F1.Controllers
{
    public class ResultadosController : Controller
    {
        private readonly ClassificacaoContext _context;

        public ResultadosController(ClassificacaoContext context)
        {
            _context = context;
        }

        // GET: Resultados
        public async Task<IActionResult> Index()
        {
            return View(await _context.Resultado.ToListAsync());
        }

        // GET: Resultados/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resultado = await _context.Resultado
                .FirstOrDefaultAsync(m => m.Id == id);
            if (resultado == null)
            {
                return NotFound();
            }

            return View(resultado);
        }

        // GET: Resultados/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Resultados/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Equipe,Posicao_Grid,Pontuacão")] Resultado resultado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(resultado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(resultado);
        }

        // GET: Resultados/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resultado = await _context.Resultado.FindAsync(id);
            if (resultado == null)
            {
                return NotFound();
            }
            return View(resultado);
        }

        // POST: Resultados/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Equipe,Posicao_Grid,Pontuacão")] Resultado resultado)
        {
            if (id != resultado.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(resultado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ResultadoExists(resultado.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(resultado);
        }

        // GET: Resultados/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resultado = await _context.Resultado
                .FirstOrDefaultAsync(m => m.Id == id);
            if (resultado == null)
            {
                return NotFound();
            }

            return View(resultado);
        }

        // POST: Resultados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var resultado = await _context.Resultado.FindAsync(id);
            _context.Resultado.Remove(resultado);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ResultadoExists(int id)
        {
            return _context.Resultado.Any(e => e.Id == id);
        }
    }
}
