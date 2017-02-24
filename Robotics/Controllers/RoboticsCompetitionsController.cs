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
    public class RoboticsCompetitionsController : Controller
    {
        private readonly RoboticsContext _context;

        public RoboticsCompetitionsController(RoboticsContext context)
        {
            _context = context;    
        }

        // GET: RoboticsCompetitions
        public async Task<IActionResult> Index()
        {
            return View(await _context.RoboticsCompetitions.ToListAsync());
        }

        // GET: RoboticsCompetitions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roboticsCompetitions = await _context.RoboticsCompetitions
                .SingleOrDefaultAsync(m => m.Id == id);
            if (roboticsCompetitions == null)
            {
                return NotFound();
            }

            return View(roboticsCompetitions);
        }

        // GET: RoboticsCompetitions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RoboticsCompetitions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id")] RoboticsCompetitions roboticsCompetitions)
        {
            if (ModelState.IsValid)
            {
                _context.Add(roboticsCompetitions);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(roboticsCompetitions);
        }

        // GET: RoboticsCompetitions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roboticsCompetitions = await _context.RoboticsCompetitions.SingleOrDefaultAsync(m => m.Id == id);
            if (roboticsCompetitions == null)
            {
                return NotFound();
            }
            return View(roboticsCompetitions);
        }

        // POST: RoboticsCompetitions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id")] RoboticsCompetitions roboticsCompetitions)
        {
            if (id != roboticsCompetitions.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(roboticsCompetitions);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoboticsCompetitionsExists(roboticsCompetitions.Id))
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
            return View(roboticsCompetitions);
        }

        // GET: RoboticsCompetitions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roboticsCompetitions = await _context.RoboticsCompetitions
                .SingleOrDefaultAsync(m => m.Id == id);
            if (roboticsCompetitions == null)
            {
                return NotFound();
            }

            return View(roboticsCompetitions);
        }

        // POST: RoboticsCompetitions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var roboticsCompetitions = await _context.RoboticsCompetitions.SingleOrDefaultAsync(m => m.Id == id);
            _context.RoboticsCompetitions.Remove(roboticsCompetitions);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool RoboticsCompetitionsExists(int id)
        {
            return _context.RoboticsCompetitions.Any(e => e.Id == id);
        }
    }
}
