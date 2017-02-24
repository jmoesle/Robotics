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
    public class RoboticsOrganizationsController : Controller
    {
        private readonly RoboticsContext _context;

        public RoboticsOrganizationsController(RoboticsContext context)
        {
            _context = context;    
        }

        // GET: RoboticsOrganizations
        public async Task<IActionResult> Index()
        {
            return View(await _context.RoboticsOrganizations.ToListAsync());
        }

        // GET: RoboticsOrganizations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roboticsOrganizations = await _context.RoboticsOrganizations
                .SingleOrDefaultAsync(m => m.Id == id);
            if (roboticsOrganizations == null)
            {
                return NotFound();
            }

            return View(roboticsOrganizations);
        }

        // GET: RoboticsOrganizations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RoboticsOrganizations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id")] RoboticsOrganizations roboticsOrganizations)
        {
            if (ModelState.IsValid)
            {
                _context.Add(roboticsOrganizations);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(roboticsOrganizations);
        }

        // GET: RoboticsOrganizations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roboticsOrganizations = await _context.RoboticsOrganizations.SingleOrDefaultAsync(m => m.Id == id);
            if (roboticsOrganizations == null)
            {
                return NotFound();
            }
            return View(roboticsOrganizations);
        }

        // POST: RoboticsOrganizations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id")] RoboticsOrganizations roboticsOrganizations)
        {
            if (id != roboticsOrganizations.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(roboticsOrganizations);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoboticsOrganizationsExists(roboticsOrganizations.Id))
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
            return View(roboticsOrganizations);
        }

        // GET: RoboticsOrganizations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roboticsOrganizations = await _context.RoboticsOrganizations
                .SingleOrDefaultAsync(m => m.Id == id);
            if (roboticsOrganizations == null)
            {
                return NotFound();
            }

            return View(roboticsOrganizations);
        }

        // POST: RoboticsOrganizations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var roboticsOrganizations = await _context.RoboticsOrganizations.SingleOrDefaultAsync(m => m.Id == id);
            _context.RoboticsOrganizations.Remove(roboticsOrganizations);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool RoboticsOrganizationsExists(int id)
        {
            return _context.RoboticsOrganizations.Any(e => e.Id == id);
        }
    }
}
