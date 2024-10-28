using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OlallaJessica_ExamenP1.Models;

namespace OlallaJessica_ExamenP1.Controllers
{
    public class OlallasController : Controller
    {
        private readonly OlallaJessica_ExamenP1Context _context;

        public OlallasController(OlallaJessica_ExamenP1Context context)
        {
            _context = context;
        }

        // GET: Olallas
        public async Task<IActionResult> Index()
        {
            var olallaJessica_ExamenP1Context = _context.Olalla.Include(o => o.celular);
            return View(await olallaJessica_ExamenP1Context.ToListAsync());
        }

        // GET: Olallas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var olalla = await _context.Olalla
                .Include(o => o.celular)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (olalla == null)
            {
                return NotFound();
            }

            return View(olalla);
        }

        // GET: Olallas/Create
        public IActionResult Create()
        {
            ViewData["CelularId"] = new SelectList(_context.Set<Celular>(), "Id", "Modelo");
            return View();
        }

        // POST: Olallas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Estatura,Mascota,Nacimiento,CelularId")] Olalla olalla)
        {
            if (ModelState.IsValid)
            {
                _context.Add(olalla);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CelularId"] = new SelectList(_context.Set<Celular>(), "Id", "Modelo", olalla.CelularId);
            return View(olalla);
        }

        // GET: Olallas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var olalla = await _context.Olalla.FindAsync(id);
            if (olalla == null)
            {
                return NotFound();
            }
            ViewData["CelularId"] = new SelectList(_context.Set<Celular>(), "Id", "Modelo", olalla.CelularId);
            return View(olalla);
        }

        // POST: Olallas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Estatura,Mascota,Nacimiento,CelularId")] Olalla olalla)
        {
            if (id != olalla.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(olalla);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OlallaExists(olalla.Id))
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
            ViewData["CelularId"] = new SelectList(_context.Set<Celular>(), "Id", "Modelo", olalla.CelularId);
            return View(olalla);
        }

        // GET: Olallas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var olalla = await _context.Olalla
                .Include(o => o.celular)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (olalla == null)
            {
                return NotFound();
            }

            return View(olalla);
        }

        // POST: Olallas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var olalla = await _context.Olalla.FindAsync(id);
            if (olalla != null)
            {
                _context.Olalla.Remove(olalla);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OlallaExists(int id)
        {
            return _context.Olalla.Any(e => e.Id == id);
        }
    }
}
