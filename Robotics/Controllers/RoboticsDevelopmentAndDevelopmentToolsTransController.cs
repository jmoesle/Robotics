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
    public class RoboticsDevelopmentAndDevelopmentToolsTransController : Controller
    {
        private readonly RoboticsContext _context;

        public RoboticsDevelopmentAndDevelopmentToolsTransController(RoboticsContext context)
        {
            _context = context;    
        }

        // GET: RoboticsDevelopmentAndDevelopmentToolsTrans
        public async Task<IActionResult> Index()
        {
            var roboticsContext = _context.RoboticsDevelopmentAndDevelopmentToolsTrans.Include(r => r.LanguageNavigation).Include(r => r.RoboticsdevelopmentanddevelopmenttoolsNavigation);
            return View(await roboticsContext.ToListAsync());
        }

        // GET: RoboticsDevelopmentAndDevelopmentToolsTrans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roboticsDevelopmentAndDevelopmentToolsTrans = await _context.RoboticsDevelopmentAndDevelopmentToolsTrans
                .Include(r => r.LanguageNavigation)
                .Include(r => r.RoboticsdevelopmentanddevelopmenttoolsNavigation)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (roboticsDevelopmentAndDevelopmentToolsTrans == null)
            {
                return NotFound();
            }

            return View(roboticsDevelopmentAndDevelopmentToolsTrans);
        }

        // GET: RoboticsDevelopmentAndDevelopmentToolsTrans/Create
        public IActionResult Create()
        {
            ViewData["Language"] = new SelectList(_context.Languages, "Id", "Code");
            ViewData["Roboticsdevelopmentanddevelopmenttools"] = new SelectList(_context.RoboticsDevelopmentAndDevelopmentTools, "Id", "Id");
            return View();
        }

        // POST: RoboticsDevelopmentAndDevelopmentToolsTrans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int RoboticsDevelopmentAndDevelopmentTools, [Bind("Id,Name,Description,Roboticsdevelopmentanddevelopmenttools,Language")] RoboticsDevelopmentAndDevelopmentToolsTrans roboticsDevelopmentAndDevelopmentToolsTrans)
        {
            if (ModelState.IsValid)
            { 
                if (RoboticsDevelopmentAndDevelopmentTools == 0) { RoboticsDevelopmentAndDevelopmentTools entry = new RoboticsDevelopmentAndDevelopmentTools(); _context.Add(entry); roboticsDevelopmentAndDevelopmentToolsTrans.Roboticsdevelopmentanddevelopmenttools = entry.Id; }

            _context.Add(roboticsDevelopmentAndDevelopmentToolsTrans);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["Language"] = new SelectList(_context.Languages, "Id", "Code", roboticsDevelopmentAndDevelopmentToolsTrans.Language);
            ViewData["Roboticsdevelopmentanddevelopmenttools"] = new SelectList(_context.RoboticsDevelopmentAndDevelopmentTools, "Id", "Id", roboticsDevelopmentAndDevelopmentToolsTrans.Roboticsdevelopmentanddevelopmenttools);
            return View(roboticsDevelopmentAndDevelopmentToolsTrans);
        }

        // GET: RoboticsDevelopmentAndDevelopmentToolsTrans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roboticsDevelopmentAndDevelopmentToolsTrans = await _context.RoboticsDevelopmentAndDevelopmentToolsTrans.SingleOrDefaultAsync(m => m.Id == id);
            if (roboticsDevelopmentAndDevelopmentToolsTrans == null)
            {
                return NotFound();
            }
            ViewData["Language"] = new SelectList(_context.Languages, "Id", "Code", roboticsDevelopmentAndDevelopmentToolsTrans.Language);
            ViewData["Roboticsdevelopmentanddevelopmenttools"] = new SelectList(_context.RoboticsDevelopmentAndDevelopmentTools, "Id", "Id", roboticsDevelopmentAndDevelopmentToolsTrans.Roboticsdevelopmentanddevelopmenttools);
            return View(roboticsDevelopmentAndDevelopmentToolsTrans);
        }

        // POST: RoboticsDevelopmentAndDevelopmentToolsTrans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Roboticsdevelopmentanddevelopmenttools,Language")] RoboticsDevelopmentAndDevelopmentToolsTrans roboticsDevelopmentAndDevelopmentToolsTrans)
        {
            if (id != roboticsDevelopmentAndDevelopmentToolsTrans.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(roboticsDevelopmentAndDevelopmentToolsTrans);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoboticsDevelopmentAndDevelopmentToolsTransExists(roboticsDevelopmentAndDevelopmentToolsTrans.Id))
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
            ViewData["Language"] = new SelectList(_context.Languages, "Id", "Code", roboticsDevelopmentAndDevelopmentToolsTrans.Language);
            ViewData["Roboticsdevelopmentanddevelopmenttools"] = new SelectList(_context.RoboticsDevelopmentAndDevelopmentTools, "Id", "Id", roboticsDevelopmentAndDevelopmentToolsTrans.Roboticsdevelopmentanddevelopmenttools);
            return View(roboticsDevelopmentAndDevelopmentToolsTrans);
        }

        // GET: RoboticsDevelopmentAndDevelopmentToolsTrans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roboticsDevelopmentAndDevelopmentToolsTrans = await _context.RoboticsDevelopmentAndDevelopmentToolsTrans
                .Include(r => r.LanguageNavigation)
                .Include(r => r.RoboticsdevelopmentanddevelopmenttoolsNavigation)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (roboticsDevelopmentAndDevelopmentToolsTrans == null)
            {
                return NotFound();
            }

            return View(roboticsDevelopmentAndDevelopmentToolsTrans);
        }

        // POST: RoboticsDevelopmentAndDevelopmentToolsTrans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var roboticsDevelopmentAndDevelopmentToolsTrans = await _context.RoboticsDevelopmentAndDevelopmentToolsTrans.SingleOrDefaultAsync(m => m.Id == id);
            _context.RoboticsDevelopmentAndDevelopmentToolsTrans.Remove(roboticsDevelopmentAndDevelopmentToolsTrans);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool RoboticsDevelopmentAndDevelopmentToolsTransExists(int id)
        {
            return _context.RoboticsDevelopmentAndDevelopmentToolsTrans.Any(e => e.Id == id);
        }
    }
}
