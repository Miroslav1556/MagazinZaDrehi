using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MagazinZaDrehi.Data;

namespace MagazinZaDrehi.Controllers
{
    public class ArticulsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ArticulsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Articuls
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Articul.Include(a => a.Category);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Articuls/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var articul = await _context.Articul
                .Include(a => a.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (articul == null)
            {
                return NotFound();
            }

            return View(articul);
        }

        // GET: Articuls/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "Id");
            return View();
        }

        // POST: Articuls/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CatalogId,Name,CategoryId,Size,Description,Sex,Age,Photo,Price,OrderDate")] Articul articul)
        {
            if (ModelState.IsValid)
            {
                _context.Add(articul);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "Id", articul.CategoryId);
            return View(articul);
        }

        // GET: Articuls/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var articul = await _context.Articul.FindAsync(id);
            if (articul == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "Id", articul.CategoryId);
            return View(articul);
        }

        // POST: Articuls/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CatalogId,Name,CategoryId,Size,Description,Sex,Age,Photo,Price,OrderDate")] Articul articul)
        {
            if (id != articul.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(articul);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArticulExists(articul.Id))
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
            ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "Id", articul.CategoryId);
            return View(articul);
        }

        // GET: Articuls/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var articul = await _context.Articul
                .Include(a => a.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (articul == null)
            {
                return NotFound();
            }

            return View(articul);
        }

        // POST: Articuls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var articul = await _context.Articul.FindAsync(id);
            _context.Articul.Remove(articul);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArticulExists(int id)
        {
            return _context.Articul.Any(e => e.Id == id);
        }
    }
}
