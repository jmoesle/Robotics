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
    public class RoboticsCompaniesController : Controller
    {
        private readonly RoboticsContext _context;

        public RoboticsCompaniesController(RoboticsContext context)
        {
            _context = context;    
        }

        // GET: RoboticsCompanies
        public async Task<IActionResult> Index()
        {
            return View(await _context.RoboticsCompanies.ToListAsync());
        }

        // GET: RoboticsCompanies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roboticsCompanies = await _context.RoboticsCompanies
                .SingleOrDefaultAsync(m => m.Id == id);
            if (roboticsCompanies == null)
            {
                return NotFound();
            }

            return View(roboticsCompanies);
        }

        // GET: RoboticsCompanies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RoboticsCompanies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id")] RoboticsCompanies roboticsCompanies)
        {
            if (ModelState.IsValid)
            {
                _context.Add(roboticsCompanies);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(roboticsCompanies);
        }

        // GET: RoboticsCompanies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roboticsCompanies = await _context.RoboticsCompanies.SingleOrDefaultAsync(m => m.Id == id);
            if (roboticsCompanies == null)
            {
                return NotFound();
            }
            return View(roboticsCompanies);
        }

        // POST: RoboticsCompanies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id")] RoboticsCompanies roboticsCompanies)
        {
            if (id != roboticsCompanies.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(roboticsCompanies);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoboticsCompaniesExists(roboticsCompanies.Id))
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
            return View(roboticsCompanies);
        }

        // GET: RoboticsCompanies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roboticsCompanies = await _context.RoboticsCompanies
                .SingleOrDefaultAsync(m => m.Id == id);
            if (roboticsCompanies == null)
            {
                return NotFound();
            }

            return View(roboticsCompanies);
        }

        // POST: RoboticsCompanies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var roboticsCompanies = await _context.RoboticsCompanies.SingleOrDefaultAsync(m => m.Id == id);
            _context.RoboticsCompanies.Remove(roboticsCompanies);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool RoboticsCompaniesExists(int id)
        {
            return _context.RoboticsCompanies.Any(e => e.Id == id);
        }
    }
}
