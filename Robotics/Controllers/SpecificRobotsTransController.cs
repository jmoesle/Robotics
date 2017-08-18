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
    public class SpecificRobotsTransController : Controller
    {
        private readonly RoboticsContext _context;

        public SpecificRobotsTransController(RoboticsContext context)
        {
            _context = context;
        }

        // GET: SpecificRobotsTrans
        public async Task<IActionResult> Index()
        {
            var roboticsContext = _context.SpecificRobotsTrans
                .Include(s => s.LanguageNavigation)
                .Include(s => s.SpecificrobotsNavigation);
            return View(await roboticsContext.ToListAsync());
        }

        // GET: SpecificRobotsTrans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var specificRobotsTrans = await _context.SpecificRobotsTrans
                .Include(s => s.LanguageNavigation)
                .Include(s => s.SpecificrobotsNavigation) //.ThenInclude(sr => sr.SpecificRobotsInRelation).ThenInclude(srr => srr.Branches)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (specificRobotsTrans == null)
            {
                return NotFound();
            }

            return View(specificRobotsTrans);
        }

        // GET: SpecificRobotsTrans/Create
        public IActionResult Create(int specificrobots)
        {
            ViewData["Language"] = new SelectList(_context.Languages, "Id", "Code");
            SpecificRobotsTrans specificrobotstrans = new SpecificRobotsTrans();
            specificrobotstrans.Specificrobots = specificrobots;
              ViewData["Specificrobots"] = specificrobots;
            return View(specificrobotstrans);
        }

        public IActionResult CreateTranslation(int specificrobots)
        {
           return RedirectToAction("Create", "SpecificRobotsTrans", new { specificrobots = specificrobots });
        }



        // POST: SpecificRobotsTrans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Specificrobots,Language")] SpecificRobotsTrans specificRobotsTrans)
        {
            if (ModelState.IsValid)
            {
                _context.Add(specificRobotsTrans);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["Language"] = new SelectList(_context.Languages, "Id", "Code", specificRobotsTrans.Language);
            ViewData["Specificrobots"] = new SelectList(_context.SpecificRobots, "Id", "Id", specificRobotsTrans.Specificrobots);
            return View(specificRobotsTrans);
        }

        // GET: SpecificRobotsTrans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var specificRobotsTrans = await _context.SpecificRobotsTrans.SingleOrDefaultAsync(m => m.Id == id);
            if (specificRobotsTrans == null)
            {
                return NotFound();
            }
            ViewData["Language"] = new SelectList(_context.Languages, "Id", "Code", specificRobotsTrans.Language);
            ViewData["Specificrobots"] = new SelectList(_context.SpecificRobots, "Id", "Id", specificRobotsTrans.Specificrobots);
            return View(specificRobotsTrans);
        }

        // POST: SpecificRobotsTrans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Specificrobots,Language")] SpecificRobotsTrans specificRobotsTrans)
        {
            if (id != specificRobotsTrans.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(specificRobotsTrans);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SpecificRobotsTransExists(specificRobotsTrans.Id))
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
            ViewData["Language"] = new SelectList(_context.Languages, "Id", "Code", specificRobotsTrans.Language);
            ViewData["Specificrobots"] = new SelectList(_context.SpecificRobots, "Id", "Id", specificRobotsTrans.Specificrobots);
            return View(specificRobotsTrans);
        }

        // GET: SpecificRobotsTrans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var specificRobotsTrans = await _context.SpecificRobotsTrans
                .Include(s => s.LanguageNavigation)
                .Include(s => s.SpecificrobotsNavigation)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (specificRobotsTrans == null)
            {
                return NotFound();
            }

            return View(specificRobotsTrans);
        }

        // POST: SpecificRobotsTrans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var specificRobotsTrans = await _context.SpecificRobotsTrans.SingleOrDefaultAsync(m => m.Id == id);
            _context.SpecificRobotsTrans.Remove(specificRobotsTrans);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool SpecificRobotsTransExists(int id)
        {
            return _context.SpecificRobotsTrans.Any(e => e.Id == id);
        }
    }
}
