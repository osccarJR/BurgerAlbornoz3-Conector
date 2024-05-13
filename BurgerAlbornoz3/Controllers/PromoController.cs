using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BurgerAlbornoz3.Data;
using BurgerAlbornoz3.Models;

namespace BurgerAlbornoz3.Controllers
{
    public class PromoController : Controller
    {
        private readonly BurgerAlbornoz3Context _context;

        public PromoController(BurgerAlbornoz3Context context)
        {
            _context = context;
        }

        // GET: Promo
        public async Task<IActionResult> Index()
        {
            var burgerAlbornoz3Context = _context.Promo.Include(p => p.Burger);
            return View(await burgerAlbornoz3Context.ToListAsync());
        }

        // GET: Promo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var promo = await _context.Promo
                .Include(p => p.Burger)
                .FirstOrDefaultAsync(m => m.PromId == id);
            if (promo == null)
            {
                return NotFound();
            }

            return View(promo);
        }

        // GET: Promo/Create
        public IActionResult Create()
        {
            ViewData["BurgerID"] = new SelectList(_context.Burger, "BurgerId", "Name");
            return View();
        }

        // POST: Promo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PromId,Descripcion,FechaPromo,BurgerID")] Promo promo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(promo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BurgerID"] = new SelectList(_context.Burger, "BurgerId", "Name", promo.BurgerID);
            return View(promo);
        }

        // GET: Promo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var promo = await _context.Promo.FindAsync(id);
            if (promo == null)
            {
                return NotFound();
            }
            ViewData["BurgerID"] = new SelectList(_context.Burger, "BurgerId", "Name", promo.BurgerID);
            return View(promo);
        }

        // POST: Promo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PromId,Descripcion,FechaPromo,BurgerID")] Promo promo)
        {
            if (id != promo.PromId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(promo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PromoExists(promo.PromId))
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
            ViewData["BurgerID"] = new SelectList(_context.Burger, "BurgerId", "Name", promo.BurgerID);
            return View(promo);
        }

        // GET: Promo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var promo = await _context.Promo
                .Include(p => p.Burger)
                .FirstOrDefaultAsync(m => m.PromId == id);
            if (promo == null)
            {
                return NotFound();
            }

            return View(promo);
        }

        // POST: Promo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var promo = await _context.Promo.FindAsync(id);
            if (promo != null)
            {
                _context.Promo.Remove(promo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PromoExists(int id)
        {
            return _context.Promo.Any(e => e.PromId == id);
        }
    }
}
