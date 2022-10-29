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
    public class ValorHorasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ValorHorasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ValorHoras
        public async Task<IActionResult> Index()
        {
              return View(await _context.ValorHoras.ToListAsync());
        }

        // GET: ValorHoras/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ValorHoras == null)
            {
                return NotFound();
            }

            var valorHora = await _context.ValorHoras
                .FirstOrDefaultAsync(m => m.IdValorHora == id);
            if (valorHora == null)
            {
                return NotFound();
            }

            return View(valorHora);
        }

        // GET: ValorHoras/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ValorHoras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdValorHora,Valor")] ValorHora valorHora)
        {
            if (ModelState.IsValid)
            {
                _context.Add(valorHora);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(valorHora);
        }

        // GET: ValorHoras/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ValorHoras == null)
            {
                return NotFound();
            }

            var valorHora = await _context.ValorHoras.FindAsync(id);
            if (valorHora == null)
            {
                return NotFound();
            }
            return View(valorHora);
        }

        // POST: ValorHoras/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdValorHora,Valor")] ValorHora valorHora)
        {
            if (id != valorHora.IdValorHora)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(valorHora);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ValorHoraExists(valorHora.IdValorHora))
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
            return View(valorHora);
        }

        // GET: ValorHoras/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ValorHoras == null)
            {
                return NotFound();
            }

            var valorHora = await _context.ValorHoras
                .FirstOrDefaultAsync(m => m.IdValorHora == id);
            if (valorHora == null)
            {
                return NotFound();
            }

            return View(valorHora);
        }

        // POST: ValorHoras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ValorHoras == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ValorHoras'  is null.");
            }
            var valorHora = await _context.ValorHoras.FindAsync(id);
            if (valorHora != null)
            {
                _context.ValorHoras.Remove(valorHora);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ValorHoraExists(int id)
        {
          return _context.ValorHoras.Any(e => e.IdValorHora == id);
        }
    }
}
