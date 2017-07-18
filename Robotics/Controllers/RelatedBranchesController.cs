using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Robotics.Models;

namespace Robotics.Controllers
{
    public class RelatedBranchesController : Controller
    {
        private readonly RoboticsContext _context;

        public RelatedBranchesController(RoboticsContext context)
        {
            _context = context;    
        }

        // GET: RelatedBranches
        public async Task<IActionResult> Index()
        {
            var roboticsContext = _context.RelatedBranches.Include(r => r.Industry1Navigation).Include(r => r.Industry2Navigation);
            return View(await roboticsContext.ToListAsync());
        }

        // GET: RelatedBranches/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var relatedBranches = await _context.RelatedBranches
                .Include(r => r.Industry1Navigation)
                .Include(r => r.Industry2Navigation)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (relatedBranches == null)
            {
                return NotFound();
            }

            return View(relatedBranches);
        }

        // GET: RelatedBranches/Create
        public IActionResult Create()
        {
            ViewData["Industry1"] = new SelectList(_context.Branches, "Id", "Id");
            ViewData["Industry2"] = new SelectList(_context.Branches, "Id", "Id");
            return View();
        }

        // POST: RelatedBranches/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Industry1,Industry2")] RelatedBranches relatedBranches)
        {
            if (ModelState.IsValid)
            {
                _context.Add(relatedBranches);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["Industry1"] = new SelectList(_context.Branches, "Id", "Id", relatedBranches.Industry1);
            ViewData["Industry2"] = new SelectList(_context.Branches, "Id", "Id", relatedBranches.Industry2);
            return View(relatedBranches);
        }

        // GET: RelatedBranches/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var relatedBranches = await _context.RelatedBranches.SingleOrDefaultAsync(m => m.Id == id);
            if (relatedBranches == null)
            {
                return NotFound();
            }
            ViewData["Industry1"] = new SelectList(_context.Branches, "Id", "Id", relatedBranches.Industry1);
            ViewData["Industry2"] = new SelectList(_context.Branches, "Id", "Id", relatedBranches.Industry2);
            return View(relatedBranches);
        }

        // POST: RelatedBranches/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Industry1,Industry2")] RelatedBranches relatedBranches)
        {
            if (id != relatedBranches.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(relatedBranches);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RelatedBranchesExists(relatedBranches.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            ViewData["Industry1"] = new SelectList(_context.Branches, "Id", "Id", relatedBranches.Industry1);
            ViewData["Industry2"] = new SelectList(_context.Branches, "Id", "Id", relatedBranches.Industry2);
            return View(relatedBranches);
        }

        // GET: RelatedBranches/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var relatedBranches = await _context.RelatedBranches
                .Include(r => r.Industry1Navigation)
                .Include(r => r.Industry2Navigation)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (relatedBranches == null)
            {
                return NotFound();
            }

            return View(relatedBranches);
        }

        // POST: RelatedBranches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var relatedBranches = await _context.RelatedBranches.SingleOrDefaultAsync(m => m.Id == id);
            _context.RelatedBranches.Remove(relatedBranches);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool RelatedBranchesExists(int id)
        {
            return _context.RelatedBranches.Any(e => e.Id == id);
        }
    }
}
