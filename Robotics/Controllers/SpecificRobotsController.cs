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
    public class SpecificRobotsController : Controller
    {
        private readonly RoboticsContext _context;

        public SpecificRobotsController(RoboticsContext context)
        {
            _context = context;    
        }

        // GET: SpecificRobots
        public async Task<IActionResult> Index()
        {

            return View(await _context.SpecificRobots.ToListAsync());

        }

        // GET: SpecificRobots/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var specificRobots = await _context.SpecificRobots
                .SingleOrDefaultAsync(m => m.Id == id);
            if (specificRobots == null)
            {
                return NotFound();
            }
           
            return View(specificRobots);
        }

        // GET: SpecificRobots/Create
        public IActionResult Create()
        {
           
            return View();
        }

        // POST: SpecificRobots/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id")] SpecificRobots specificRobots)
        {

            int id = new int();
            if (ModelState.IsValid)
            {
                _context.Add(specificRobots);
                await _context.SaveChangesAsync();

                List<SpecificRobots> allspecificrobots = new List<SpecificRobots>();
                allspecificrobots = await _context.SpecificRobots.ToListAsync();
                foreach (SpecificRobots item in allspecificrobots)
                {
                    if (item == specificRobots) {
                        id = specificRobots.Id;
                    }
                }
                return RedirectToAction("Create", "SpecificRobotsTrans", new { specificrobots = id });

            }

            return View();


        }

        // GET: SpecificRobots/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var specificRobots = await _context.SpecificRobots.SingleOrDefaultAsync(m => m.Id == id);
            if (specificRobots == null)
            {
                return NotFound();
            }
            return View(specificRobots);
        }

        // POST: SpecificRobots/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id")] SpecificRobots specificRobots)
        {
            if (id != specificRobots.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(specificRobots);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SpecificRobotsExists(specificRobots.Id))
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
            return View(specificRobots);
        }

        // GET: SpecificRobots/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var specificRobots = await _context.SpecificRobots
                .SingleOrDefaultAsync(m => m.Id == id);
            if (specificRobots == null)
            {
                return NotFound();
            }

            return View(specificRobots);
        }

        // POST: SpecificRobots/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var specificRobots = await _context.SpecificRobots.SingleOrDefaultAsync(m => m.Id == id);
            _context.SpecificRobots.Remove(specificRobots);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool SpecificRobotsExists(int id)
        {
            return _context.SpecificRobots.Any(e => e.Id == id);
        }
    }
}
