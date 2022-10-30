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
    public class TrabalhosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TrabalhosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Trabalhos
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Trabalhos.Include(t => t.Atividade).Include(t => t.Usuario).Include(t => t.ValoHora);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Trabalhos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Trabalhos == null)
            {
                return NotFound();
            }

            var trabalho = await _context.Trabalhos
                .Include(t => t.Atividade)
                .Include(t => t.Usuario)
                .Include(t => t.ValoHora)
                .FirstOrDefaultAsync(m => m.IdTrabalho == id);
            if (trabalho == null)
            {
                return NotFound();
            }

            return View(trabalho);
        }

        // GET: Trabalhos/Create
        public IActionResult Create()
        {
            ViewData["AtividadeId"] = new SelectList(_context.Atividades, "IdAtividade", "Descricao");
            ViewData["CadastroId"] = new SelectList(_context.Usuarios, "IdCadastro", "ConfirmaSenha");
            ViewData["ValorHoraId"] = new SelectList(_context.ValorHoras, "IdValorHora", "IdValorHora");
            return View();
        }

        // POST: Trabalhos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTrabalho,CadastroId,AtividadeId,ValorHoraId")] Trabalho trabalho)
        {
            if (ModelState.IsValid)
            {
                _context.Add(trabalho);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AtividadeId"] = new SelectList(_context.Atividades, "IdAtividade", "Descricao", trabalho.AtividadeId);
            ViewData["CadastroId"] = new SelectList(_context.Usuarios, "IdCadastro", "ConfirmaSenha", trabalho.CadastroId);
            ViewData["ValorHoraId"] = new SelectList(_context.ValorHoras, "IdValorHora", "IdValorHora", trabalho.ValorHoraId);
            return View(trabalho);
        }

        // GET: Trabalhos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Trabalhos == null)
            {
                return NotFound();
            }

            var trabalho = await _context.Trabalhos.FindAsync(id);
            if (trabalho == null)
            {
                return NotFound();
            }
            ViewData["AtividadeId"] = new SelectList(_context.Atividades, "IdAtividade", "Descricao", trabalho.AtividadeId);
            ViewData["CadastroId"] = new SelectList(_context.Usuarios, "IdCadastro", "ConfirmaSenha", trabalho.CadastroId);
            ViewData["ValorHoraId"] = new SelectList(_context.ValorHoras, "IdValorHora", "IdValorHora", trabalho.ValorHoraId);
            return View(trabalho);
        }

        // POST: Trabalhos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTrabalho,CadastroId,AtividadeId,ValorHoraId")] Trabalho trabalho)
        {
            if (id != trabalho.IdTrabalho)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trabalho);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrabalhoExists(trabalho.IdTrabalho))
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
            ViewData["AtividadeId"] = new SelectList(_context.Atividades, "IdAtividade", "Descricao", trabalho.AtividadeId);
            ViewData["CadastroId"] = new SelectList(_context.Usuarios, "IdCadastro", "ConfirmaSenha", trabalho.CadastroId);
            ViewData["ValorHoraId"] = new SelectList(_context.ValorHoras, "IdValorHora", "IdValorHora", trabalho.ValorHoraId);
            return View(trabalho);
        }

        // GET: Trabalhos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Trabalhos == null)
            {
                return NotFound();
            }

            var trabalho = await _context.Trabalhos
                .Include(t => t.Atividade)
                .Include(t => t.Usuario)
                .Include(t => t.ValoHora)
                .FirstOrDefaultAsync(m => m.IdTrabalho == id);
            if (trabalho == null)
            {
                return NotFound();
            }

            return View(trabalho);
        }

        // POST: Trabalhos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Trabalhos == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Trabalhos'  is null.");
            }
            var trabalho = await _context.Trabalhos.FindAsync(id);
            if (trabalho != null)
            {
                _context.Trabalhos.Remove(trabalho);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TrabalhoExists(int id)
        {
          return _context.Trabalhos.Any(e => e.IdTrabalho == id);
        }
    }
}
