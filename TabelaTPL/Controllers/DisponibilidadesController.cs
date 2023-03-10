using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TabelaTPL.Context;
using TabelaTPL.Models;

namespace TabelaTPL.Controllers
{
    public class DisponibilidadesController : Controller
    {
        private readonly TabelaContext _context;

        public DisponibilidadesController(TabelaContext context)
        {
            _context = context;
        }

        // GET: Disponibilidades
        public async Task<IActionResult> Index(string voluntarioName)
        {
            if (!string.IsNullOrEmpty(voluntarioName))
            {
                var tabelaContext = _context.Disponibilidades.Include(d => d.Voluntarios).Where(d => d.Voluntarios.Name.Equals(voluntarioName));
                return View(await tabelaContext.ToListAsync());
            }
            else
            {
                return View(new List<Disponibilidade>());
            }
        }
        // GET: Disponibilidades/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Disponibilidades == null)
            {
                return NotFound();
            }

            var disponibilidade = await _context.Disponibilidades
                .Include(d => d.Voluntarios)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (disponibilidade == null)
            {
                return NotFound();
            }

            return View(disponibilidade);
        }

        // GET: Disponibilidades/Create
        public IActionResult Create()
        {
            ViewData["VoluntariosId"] = new SelectList(_context.Voluntarios, "Id", "Id");
            return View();
        }

        // POST: Disponibilidades/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Disponibilidades,VoluntariosId")] Disponibilidade disponibilidade)
        {
            if (ModelState.IsValid)
            {
                _context.Add(disponibilidade);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["VoluntariosId"] = new SelectList(_context.Voluntarios, "Id", "Id", disponibilidade.VoluntariosId);
            return View(disponibilidade);
        }

        // GET: Disponibilidades/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Disponibilidades == null)
            {
                return NotFound();
            }

            var disponibilidade = await _context.Disponibilidades.FindAsync(id);
            if (disponibilidade == null)
            {
                return NotFound();
            }
            ViewData["VoluntariosId"] = new SelectList(_context.Voluntarios, "Id", "Id", disponibilidade.VoluntariosId);
            return View(disponibilidade);
        }

        // POST: Disponibilidades/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Disponibilidades,VoluntariosId")] Disponibilidade disponibilidade)
        {
            if (id != disponibilidade.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(disponibilidade);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DisponibilidadeExists(disponibilidade.Id))
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
            ViewData["VoluntariosId"] = new SelectList(_context.Voluntarios, "Id", "Id", disponibilidade.VoluntariosId);
            return View(disponibilidade);
        }

        // GET: Disponibilidades/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Disponibilidades == null)
            {
                return NotFound();
            }

            var disponibilidade = await _context.Disponibilidades
                .Include(d => d.Voluntarios)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (disponibilidade == null)
            {
                return NotFound();
            }

            return View(disponibilidade);
        }

        // POST: Disponibilidades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Disponibilidades == null)
            {
                return Problem("Entity set 'TabelaContext.Disponibilidades'  is null.");
            }
            var disponibilidade = await _context.Disponibilidades.FindAsync(id);
            if (disponibilidade != null)
            {
                _context.Disponibilidades.Remove(disponibilidade);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DisponibilidadeExists(int id)
        {
          return _context.Disponibilidades.Any(e => e.Id == id);
        }
    }
}
