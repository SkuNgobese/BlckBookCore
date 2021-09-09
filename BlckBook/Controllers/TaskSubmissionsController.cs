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
    public class TaskSubmissionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TaskSubmissionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TaskSubmissions
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.TaskSubmissions.Include(t => t.Task);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: TaskSubmissions/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taskSubmission = await _context.TaskSubmissions
                .Include(t => t.Task)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (taskSubmission == null)
            {
                return NotFound();
            }

            return View(taskSubmission);
        }

        // GET: TaskSubmissions/Create
        public IActionResult Create()
        {
            ViewData["Id"] = new SelectList(_context.Tasks, "Id", "Description");
            return View();
        }

        // POST: TaskSubmissions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Content,SubmissionDate")] TaskSubmission taskSubmission)
        {
            if (ModelState.IsValid)
            {
                taskSubmission.Id = Guid.NewGuid();
                _context.Add(taskSubmission);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Id"] = new SelectList(_context.Tasks, "Id", "Description", taskSubmission.Id);
            return View(taskSubmission);
        }

        // GET: TaskSubmissions/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taskSubmission = await _context.TaskSubmissions.FindAsync(id);
            if (taskSubmission == null)
            {
                return NotFound();
            }
            ViewData["Id"] = new SelectList(_context.Tasks, "Id", "Description", taskSubmission.Id);
            return View(taskSubmission);
        }

        // POST: TaskSubmissions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Content,SubmissionDate")] TaskSubmission taskSubmission)
        {
            if (id != taskSubmission.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(taskSubmission);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TaskSubmissionExists(taskSubmission.Id))
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
            ViewData["Id"] = new SelectList(_context.Tasks, "Id", "Description", taskSubmission.Id);
            return View(taskSubmission);
        }

        // GET: TaskSubmissions/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taskSubmission = await _context.TaskSubmissions
                .Include(t => t.Task)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (taskSubmission == null)
            {
                return NotFound();
            }

            return View(taskSubmission);
        }

        // POST: TaskSubmissions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var taskSubmission = await _context.TaskSubmissions.FindAsync(id);
            _context.TaskSubmissions.Remove(taskSubmission);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TaskSubmissionExists(Guid id)
        {
            return _context.TaskSubmissions.Any(e => e.Id == id);
        }
    }
}
