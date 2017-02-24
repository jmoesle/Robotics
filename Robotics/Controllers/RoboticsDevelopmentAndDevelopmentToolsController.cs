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
    public class RoboticsDevelopmentAndDevelopmentToolsController : Controller
    {
        private readonly RoboticsContext _context;

        public RoboticsDevelopmentAndDevelopmentToolsController(RoboticsContext context)
        {
            _context = context;    
        }

        // GET: RoboticsDevelopmentAndDevelopmentTools
        public async Task<IActionResult> Index()
        {
            return View(await _context.RoboticsDevelopmentAndDevelopmentTools.ToListAsync());
        }

        // GET: RoboticsDevelopmentAndDevelopmentTools/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roboticsDevelopmentAndDevelopmentTools = await _context.RoboticsDevelopmentAndDevelopmentTools
                .SingleOrDefaultAsync(m => m.Id == id);
            if (roboticsDevelopmentAndDevelopmentTools == null)
            {
                return NotFound();
            }

            return View(roboticsDevelopmentAndDevelopmentTools);
        }

        // GET: RoboticsDevelopmentAndDevelopmentTools/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RoboticsDevelopmentAndDevelopmentTools/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id")] RoboticsDevelopmentAndDevelopmentTools roboticsDevelopmentAndDevelopmentTools)
        {
            if (ModelState.IsValid)
            {
                _context.Add(roboticsDevelopmentAndDevelopmentTools);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(roboticsDevelopmentAndDevelopmentTools);
        }

        // GET: RoboticsDevelopmentAndDevelopmentTools/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roboticsDevelopmentAndDevelopmentTools = await _context.RoboticsDevelopmentAndDevelopmentTools.SingleOrDefaultAsync(m => m.Id == id);
            if (roboticsDevelopmentAndDevelopmentTools == null)
            {
                return NotFound();
            }
            return View(roboticsDevelopmentAndDevelopmentTools);
        }

        // POST: RoboticsDevelopmentAndDevelopmentTools/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id")] RoboticsDevelopmentAndDevelopmentTools roboticsDevelopmentAndDevelopmentTools)
        {
            if (id != roboticsDevelopmentAndDevelopmentTools.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(roboticsDevelopmentAndDevelopmentTools);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoboticsDevelopmentAndDevelopmentToolsExists(roboticsDevelopmentAndDevelopmentTools.Id))
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
            return View(roboticsDevelopmentAndDevelopmentTools);
        }

        // GET: RoboticsDevelopmentAndDevelopmentTools/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roboticsDevelopmentAndDevelopmentTools = await _context.RoboticsDevelopmentAndDevelopmentTools
                .SingleOrDefaultAsync(m => m.Id == id);
            if (roboticsDevelopmentAndDevelopmentTools == null)
            {
                return NotFound();
            }

            return View(roboticsDevelopmentAndDevelopmentTools);
        }

        // POST: RoboticsDevelopmentAndDevelopmentTools/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var roboticsDevelopmentAndDevelopmentTools = await _context.RoboticsDevelopmentAndDevelopmentTools.SingleOrDefaultAsync(m => m.Id == id);
            _context.RoboticsDevelopmentAndDevelopmentTools.Remove(roboticsDevelopmentAndDevelopmentTools);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool RoboticsDevelopmentAndDevelopmentToolsExists(int id)
        {
            return _context.RoboticsDevelopmentAndDevelopmentTools.Any(e => e.Id == id);
        }
    }
}
