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
    public class RoboticsCompetitionsTransController : Controller
    {
        private readonly RoboticsContext _context;

        public RoboticsCompetitionsTransController(RoboticsContext context)
        {
            _context = context;    
        }

        // GET: RoboticsCompetitionsTrans
        public async Task<IActionResult> Index()
        {
            var roboticsContext = _context.RoboticsCompetitionsTrans.Include(r => r.LanguageNavigation).Include(r => r.RoboticscompetitionsNavigation);
            return View(await roboticsContext.ToListAsync());
        }

        // GET: RoboticsCompetitionsTrans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roboticsCompetitionsTrans = await _context.RoboticsCompetitionsTrans
                .Include(r => r.LanguageNavigation)
                .Include(r => r.RoboticscompetitionsNavigation)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (roboticsCompetitionsTrans == null)
            {
                return NotFound();
            }

            return View(roboticsCompetitionsTrans);
        }

        // GET: RoboticsCompetitionsTrans/Create
        public IActionResult Create()
        {
            ViewData["Language"] = new SelectList(_context.Languages, "Id", "Code");
            ViewData["Roboticscompetitions"] = new SelectList(_context.RoboticsCompetitions, "Id", "Id");
            return View();
        }

        // POST: RoboticsCompetitionsTrans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int RoboticsCompetitions, [Bind("Id,Name,Description,Roboticscompetitions,Language")] RoboticsCompetitionsTrans roboticsCompetitionsTrans)
        {
            if (ModelState.IsValid)
            {
                if (RoboticsCompetitions == 0) { RoboticsCompetitions entry = new RoboticsCompetitions(); _context.Add(entry); roboticsCompetitionsTrans.Roboticscompetitions = entry.Id; }

                _context.Add(roboticsCompetitionsTrans);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["Language"] = new SelectList(_context.Languages, "Id", "Code", roboticsCompetitionsTrans.Language);
            ViewData["Roboticscompetitions"] = new SelectList(_context.RoboticsCompetitions, "Id", "Id", roboticsCompetitionsTrans.Roboticscompetitions);
            return View(roboticsCompetitionsTrans);
        }

        // GET: RoboticsCompetitionsTrans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roboticsCompetitionsTrans = await _context.RoboticsCompetitionsTrans.SingleOrDefaultAsync(m => m.Id == id);
            if (roboticsCompetitionsTrans == null)
            {
                return NotFound();
            }
            ViewData["Language"] = new SelectList(_context.Languages, "Id", "Code", roboticsCompetitionsTrans.Language);
            ViewData["Roboticscompetitions"] = new SelectList(_context.RoboticsCompetitions, "Id", "Id", roboticsCompetitionsTrans.Roboticscompetitions);
            return View(roboticsCompetitionsTrans);
        }

        // POST: RoboticsCompetitionsTrans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Roboticscompetitions,Language")] RoboticsCompetitionsTrans roboticsCompetitionsTrans)
        {
            if (id != roboticsCompetitionsTrans.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(roboticsCompetitionsTrans);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoboticsCompetitionsTransExists(roboticsCompetitionsTrans.Id))
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
            ViewData["Language"] = new SelectList(_context.Languages, "Id", "Code", roboticsCompetitionsTrans.Language);
            ViewData["Roboticscompetitions"] = new SelectList(_context.RoboticsCompetitions, "Id", "Id", roboticsCompetitionsTrans.Roboticscompetitions);
            return View(roboticsCompetitionsTrans);
        }

        // GET: RoboticsCompetitionsTrans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roboticsCompetitionsTrans = await _context.RoboticsCompetitionsTrans
                .Include(r => r.LanguageNavigation)
                .Include(r => r.RoboticscompetitionsNavigation)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (roboticsCompetitionsTrans == null)
            {
                return NotFound();
            }

            return View(roboticsCompetitionsTrans);
        }

        // POST: RoboticsCompetitionsTrans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var roboticsCompetitionsTrans = await _context.RoboticsCompetitionsTrans.SingleOrDefaultAsync(m => m.Id == id);
            _context.RoboticsCompetitionsTrans.Remove(roboticsCompetitionsTrans);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool RoboticsCompetitionsTransExists(int id)
        {
            return _context.RoboticsCompetitionsTrans.Any(e => e.Id == id);
        }
    }
}
