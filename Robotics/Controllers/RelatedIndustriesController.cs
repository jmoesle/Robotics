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
    public class RelatedIndustriesController : Controller
    {
        private readonly RoboticsContext _context;

        public RelatedIndustriesController(RoboticsContext context)
        {
            _context = context;    
        }

        // GET: RelatedIndustries
        public async Task<IActionResult> Index()
        {
            var roboticsContext = _context.RelatedIndustries.Include(r => r.Industry1Navigation).Include(r => r.Industry2Navigation);
            return View(await roboticsContext.ToListAsync());
        }

        // GET: RelatedIndustries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var relatedIndustries = await _context.RelatedIndustries
                .Include(r => r.Industry1Navigation)
                .Include(r => r.Industry2Navigation)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (relatedIndustries == null)
            {
                return NotFound();
            }

            return View(relatedIndustries);
        }

        // GET: RelatedIndustries/Create
        public IActionResult Create()
        {
            ViewData["Industry1"] = new SelectList(_context.Industries, "Id", "Id");
            ViewData["Industry2"] = new SelectList(_context.Industries, "Id", "Id");
            return View();
        }

        // POST: RelatedIndustries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Industry1,Industry2")] RelatedIndustries relatedIndustries)
        {
            if (ModelState.IsValid)
            {
                _context.Add(relatedIndustries);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["Industry1"] = new SelectList(_context.Industries, "Id", "Id", relatedIndustries.Industry1);
            ViewData["Industry2"] = new SelectList(_context.Industries, "Id", "Id", relatedIndustries.Industry2);
            return View(relatedIndustries);
        }

        // GET: RelatedIndustries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var relatedIndustries = await _context.RelatedIndustries.SingleOrDefaultAsync(m => m.Id == id);
            if (relatedIndustries == null)
            {
                return NotFound();
            }
            ViewData["Industry1"] = new SelectList(_context.Industries, "Id", "Id", relatedIndustries.Industry1);
            ViewData["Industry2"] = new SelectList(_context.Industries, "Id", "Id", relatedIndustries.Industry2);
            return View(relatedIndustries);
        }

        // POST: RelatedIndustries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Industry1,Industry2")] RelatedIndustries relatedIndustries)
        {
            if (id != relatedIndustries.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(relatedIndustries);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RelatedIndustriesExists(relatedIndustries.Id))
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
            ViewData["Industry1"] = new SelectList(_context.Industries, "Id", "Id", relatedIndustries.Industry1);
            ViewData["Industry2"] = new SelectList(_context.Industries, "Id", "Id", relatedIndustries.Industry2);
            return View(relatedIndustries);
        }

        // GET: RelatedIndustries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var relatedIndustries = await _context.RelatedIndustries
                .Include(r => r.Industry1Navigation)
                .Include(r => r.Industry2Navigation)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (relatedIndustries == null)
            {
                return NotFound();
            }

            return View(relatedIndustries);
        }

        // POST: RelatedIndustries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var relatedIndustries = await _context.RelatedIndustries.SingleOrDefaultAsync(m => m.Id == id);
            _context.RelatedIndustries.Remove(relatedIndustries);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool RelatedIndustriesExists(int id)
        {
            return _context.RelatedIndustries.Any(e => e.Id == id);
        }
    }
}
