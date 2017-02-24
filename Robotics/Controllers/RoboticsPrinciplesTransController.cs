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
    public class RoboticsPrinciplesTransController : Controller
    {
        private readonly RoboticsContext _context;

        public RoboticsPrinciplesTransController(RoboticsContext context)
        {
            _context = context;    
        }

        // GET: RoboticsPrinciplesTrans
        public async Task<IActionResult> Index()
        {
            var roboticsContext = _context.RoboticsPrinciplesTrans.Include(r => r.LanguageNavigation).Include(r => r.RoboticsprinciplesNavigation);
            return View(await roboticsContext.ToListAsync());
        }

        // GET: RoboticsPrinciplesTrans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roboticsPrinciplesTrans = await _context.RoboticsPrinciplesTrans
                .Include(r => r.LanguageNavigation)
                .Include(r => r.RoboticsprinciplesNavigation)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (roboticsPrinciplesTrans == null)
            {
                return NotFound();
            }

            return View(roboticsPrinciplesTrans);
        }

        // GET: RoboticsPrinciplesTrans/Create
        public IActionResult Create()
        {
            ViewData["Language"] = new SelectList(_context.Languages, "Id", "Code");
            ViewData["Roboticsprinciples"] = new SelectList(_context.RoboticsPrinciples, "Id", "Id");
            return View();
        }

        // POST: RoboticsPrinciplesTrans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Roboticsprinciples,Language")] RoboticsPrinciplesTrans roboticsPrinciplesTrans)
        {
            if (ModelState.IsValid)
            {
                _context.Add(roboticsPrinciplesTrans);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["Language"] = new SelectList(_context.Languages, "Id", "Code", roboticsPrinciplesTrans.Language);
            ViewData["Roboticsprinciples"] = new SelectList(_context.RoboticsPrinciples, "Id", "Id", roboticsPrinciplesTrans.Roboticsprinciples);
            return View(roboticsPrinciplesTrans);
        }

        // GET: RoboticsPrinciplesTrans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roboticsPrinciplesTrans = await _context.RoboticsPrinciplesTrans.SingleOrDefaultAsync(m => m.Id == id);
            if (roboticsPrinciplesTrans == null)
            {
                return NotFound();
            }
            ViewData["Language"] = new SelectList(_context.Languages, "Id", "Code", roboticsPrinciplesTrans.Language);
            ViewData["Roboticsprinciples"] = new SelectList(_context.RoboticsPrinciples, "Id", "Id", roboticsPrinciplesTrans.Roboticsprinciples);
            return View(roboticsPrinciplesTrans);
        }

        // POST: RoboticsPrinciplesTrans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Roboticsprinciples,Language")] RoboticsPrinciplesTrans roboticsPrinciplesTrans)
        {
            if (id != roboticsPrinciplesTrans.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(roboticsPrinciplesTrans);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoboticsPrinciplesTransExists(roboticsPrinciplesTrans.Id))
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
            ViewData["Language"] = new SelectList(_context.Languages, "Id", "Code", roboticsPrinciplesTrans.Language);
            ViewData["Roboticsprinciples"] = new SelectList(_context.RoboticsPrinciples, "Id", "Id", roboticsPrinciplesTrans.Roboticsprinciples);
            return View(roboticsPrinciplesTrans);
        }

        // GET: RoboticsPrinciplesTrans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roboticsPrinciplesTrans = await _context.RoboticsPrinciplesTrans
                .Include(r => r.LanguageNavigation)
                .Include(r => r.RoboticsprinciplesNavigation)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (roboticsPrinciplesTrans == null)
            {
                return NotFound();
            }

            return View(roboticsPrinciplesTrans);
        }

        // POST: RoboticsPrinciplesTrans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var roboticsPrinciplesTrans = await _context.RoboticsPrinciplesTrans.SingleOrDefaultAsync(m => m.Id == id);
            _context.RoboticsPrinciplesTrans.Remove(roboticsPrinciplesTrans);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool RoboticsPrinciplesTransExists(int id)
        {
            return _context.RoboticsPrinciplesTrans.Any(e => e.Id == id);
        }
    }
}
