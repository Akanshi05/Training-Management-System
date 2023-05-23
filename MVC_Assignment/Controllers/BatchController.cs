using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC_Assignment.Context;
using MVC_Assignment.Models;

namespace MVC_Assignment.Controllers
{
    public class BatchController : Controller
    {
        private readonly TrainingDbContext _context;

        public BatchController(TrainingDbContext context)
        {
            _context = context;
        }

        // GET: Batch
        public async Task<IActionResult> Index()
        {
            var trainingDbContext = _context.Batches.Include(b => b.Course);
            return View(await trainingDbContext.ToListAsync());
        }

        // GET: Batch/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Batches == null)
            {
                return NotFound();
            }

            var batch = await _context.Batches
                .Include(b => b.Course)
                .FirstOrDefaultAsync(m => m.BatchId == id);
            if (batch == null)
            {
                return NotFound();
            }

            return View(batch);
        }

        // GET: Batch/Create
        public IActionResult Create()
        {
            ViewData["Courses"] = new SelectList(_context.Courses.ToList(), "CourseId", "CourseName");
            return View();
        }

        // POST: Batch/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BatchId,BatchName,Trainer,StartDate,CourseId")] Batch batch)
        {
            if (ModelState.IsValid)
            {
                _context.Add(batch);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CourseId"] = new SelectList(_context.Courses, "CourseId", "CourseId", batch.CourseId);
            return View(batch);
        }

        // GET: Batch/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Batches == null)
            {
                return NotFound();
            }

            var batch = await _context.Batches.FindAsync(id);
            if (batch == null)
            {
                return NotFound();
            }
            ViewData["CourseId"] = new SelectList(_context.Courses, "CourseId", "CourseId", batch.CourseId);
            return View(batch);
        }

        // POST: Batch/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BatchId,BatchName,Trainer,StartDate,CourseId")] Batch batch)
        {
            if (id != batch.BatchId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(batch);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BatchExists(batch.BatchId))
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
            ViewData["CourseId"] = new SelectList(_context.Courses, "CourseId", "CourseId", batch.CourseId);
            return View(batch);
        }

        // GET: Batch/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Batches == null)
            {
                return NotFound();
            }

            var batch = await _context.Batches
                .Include(b => b.Course)
                .FirstOrDefaultAsync(m => m.BatchId == id);
            if (batch == null)
            {
                return NotFound();
            }

            return View(batch);
        }

        // POST: Batch/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Batches == null)
            {
                return Problem("Entity set 'TrainingDbContext.Batches'  is null.");
            }
            var batch = await _context.Batches.FindAsync(id);
            if (batch != null)
            {
                _context.Batches.Remove(batch);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BatchExists(int id)
        {
          return (_context.Batches?.Any(e => e.BatchId == id)).GetValueOrDefault();
        }
    }
}
