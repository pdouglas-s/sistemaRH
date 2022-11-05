using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using sistemaRH.Models;

namespace sistemaRH.Controllers
{
    public class AtividadesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AtividadesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Atividades
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Atividades.Include(a => a.ValorHora);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Atividades/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Atividades == null)
            {
                return NotFound();
            }

            var atividade = await _context.Atividades
                .Include(a => a.ValorHora)
                .FirstOrDefaultAsync(m => m.IdAtividade == id);
            if (atividade == null)
            {
                return NotFound();
            }

            return View(atividade);
        }

        // GET: Atividades/Create
        public IActionResult Create()
        {
            ViewData["IdValor"] = new SelectList(_context.ValorHoras, "IdValorHora", "IdValorHora");
            return View();
        }

        // POST: Atividades/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdAtividade,Descricao,Nivel,IdValor")] Atividade atividade)
        {
            if (ModelState.IsValid)
            {
                _context.Add(atividade);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdValor"] = new SelectList(_context.ValorHoras, "IdValorHora", "IdValorHora", atividade.IdValor);
            return View(atividade);
        }

        // GET: Atividades/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Atividades == null)
            {
                return NotFound();
            }

            var atividade = await _context.Atividades.FindAsync(id);
            if (atividade == null)
            {
                return NotFound();
            }
            ViewData["IdValor"] = new SelectList(_context.ValorHoras, "IdValorHora", "IdValorHora", atividade.IdValor);
            return View(atividade);
        }

        // POST: Atividades/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdAtividade,Descricao,Nivel,IdValor")] Atividade atividade)
        {
            if (id != atividade.IdAtividade)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(atividade);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AtividadeExists(atividade.IdAtividade))
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
            ViewData["IdValor"] = new SelectList(_context.ValorHoras, "IdValorHora", "IdValorHora", atividade.IdValor);
            return View(atividade);
        }

        // GET: Atividades/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Atividades == null)
            {
                return NotFound();
            }

            var atividade = await _context.Atividades
                .Include(a => a.ValorHora)
                .FirstOrDefaultAsync(m => m.IdAtividade == id);
            if (atividade == null)
            {
                return NotFound();
            }

            return View(atividade);
        }

        // POST: Atividades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Atividades == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Atividades'  is null.");
            }
            var atividade = await _context.Atividades.FindAsync(id);
            if (atividade != null)
            {
                _context.Atividades.Remove(atividade);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AtividadeExists(int id)
        {
          return _context.Atividades.Any(e => e.IdAtividade == id);
        }
    }
}
