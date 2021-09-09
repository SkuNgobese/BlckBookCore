using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BlckBook.Data;
using BlckBook.Models;

namespace BlckBook.Controllers
{
    public class StreamsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StreamsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Streams
        public async Task<IActionResult> Index()
        {
            return View(await _context.Streams.ToListAsync());
        }

        // GET: Streams/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stream = await _context.Streams
                .FirstOrDefaultAsync(m => m.Id == id);
            if (stream == null)
            {
                return NotFound();
            }

            return View(stream);
        }

        // GET: Streams/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Streams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Stream stream)
        {
            if (ModelState.IsValid)
            {
                stream.Id = Guid.NewGuid();
                _context.Add(stream);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(stream);
        }

        // GET: Streams/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stream = await _context.Streams.FindAsync(id);
            if (stream == null)
            {
                return NotFound();
            }
            return View(stream);
        }

        // POST: Streams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name")] Stream stream)
        {
            if (id != stream.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stream);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StreamExists(stream.Id))
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
            return View(stream);
        }

        // GET: Streams/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stream = await _context.Streams
                .FirstOrDefaultAsync(m => m.Id == id);
            if (stream == null)
            {
                return NotFound();
            }

            return View(stream);
        }

        // POST: Streams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var stream = await _context.Streams.FindAsync(id);
            _context.Streams.Remove(stream);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StreamExists(Guid id)
        {
            return _context.Streams.Any(e => e.Id == id);
        }
    }
}
