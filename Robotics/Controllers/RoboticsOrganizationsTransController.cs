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
    public class RoboticsOrganizationsTransController : Controller
    {
        private readonly RoboticsContext _context;

        public RoboticsOrganizationsTransController(RoboticsContext context)
        {
            _context = context;    
        }

        // GET: RoboticsOrganizationsTrans
        public async Task<IActionResult> Index()
        {
            var roboticsContext = _context.RoboticsOrganizationsTrans.Include(r => r.LanguageNavigation).Include(r => r.RoboticsorganizationsNavigation);
            return View(await roboticsContext.ToListAsync());
        }

        // GET: RoboticsOrganizationsTrans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roboticsOrganizationsTrans = await _context.RoboticsOrganizationsTrans
                .Include(r => r.LanguageNavigation)
                .Include(r => r.RoboticsorganizationsNavigation)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (roboticsOrganizationsTrans == null)
            {
                return NotFound();
            }

            return View(roboticsOrganizationsTrans);
        }

        // GET: RoboticsOrganizationsTrans/Create
        public IActionResult Create()
        {
            ViewData["Language"] = new SelectList(_context.Languages, "Id", "Code");
            ViewData["Roboticsorganizations"] = new SelectList(_context.RoboticsOrganizations, "Id", "Id");
            return View();
        }

        // POST: RoboticsOrganizationsTrans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int RoboticsOrganizations, [Bind("Id,Name,Description,Roboticsorganizations,Language")] RoboticsOrganizationsTrans roboticsOrganizationsTrans)
        {
            if (ModelState.IsValid)
            {
                if (RoboticsOrganizations == 0) { RoboticsOrganizations entry = new RoboticsOrganizations(); _context.Add(entry); roboticsOrganizationsTrans.Roboticsorganizations = entry.Id; }

                _context.Add(roboticsOrganizationsTrans);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["Language"] = new SelectList(_context.Languages, "Id", "Code", roboticsOrganizationsTrans.Language);
            ViewData["Roboticsorganizations"] = new SelectList(_context.RoboticsOrganizations, "Id", "Id", roboticsOrganizationsTrans.Roboticsorganizations);
            return View(roboticsOrganizationsTrans);
        }

        // GET: RoboticsOrganizationsTrans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roboticsOrganizationsTrans = await _context.RoboticsOrganizationsTrans.SingleOrDefaultAsync(m => m.Id == id);
            if (roboticsOrganizationsTrans == null)
            {
                return NotFound();
            }
            ViewData["Language"] = new SelectList(_context.Languages, "Id", "Code", roboticsOrganizationsTrans.Language);
            ViewData["Roboticsorganizations"] = new SelectList(_context.RoboticsOrganizations, "Id", "Id", roboticsOrganizationsTrans.Roboticsorganizations);
            return View(roboticsOrganizationsTrans);
        }

        // POST: RoboticsOrganizationsTrans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Roboticsorganizations,Language")] RoboticsOrganizationsTrans roboticsOrganizationsTrans)
        {
            if (id != roboticsOrganizationsTrans.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(roboticsOrganizationsTrans);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoboticsOrganizationsTransExists(roboticsOrganizationsTrans.Id))
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
            ViewData["Language"] = new SelectList(_context.Languages, "Id", "Code", roboticsOrganizationsTrans.Language);
            ViewData["Roboticsorganizations"] = new SelectList(_context.RoboticsOrganizations, "Id", "Id", roboticsOrganizationsTrans.Roboticsorganizations);
            return View(roboticsOrganizationsTrans);
        }

        // GET: RoboticsOrganizationsTrans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roboticsOrganizationsTrans = await _context.RoboticsOrganizationsTrans
                .Include(r => r.LanguageNavigation)
                .Include(r => r.RoboticsorganizationsNavigation)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (roboticsOrganizationsTrans == null)
            {
                return NotFound();
            }

            return View(roboticsOrganizationsTrans);
        }

        // POST: RoboticsOrganizationsTrans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var roboticsOrganizationsTrans = await _context.RoboticsOrganizationsTrans.SingleOrDefaultAsync(m => m.Id == id);
            _context.RoboticsOrganizationsTrans.Remove(roboticsOrganizationsTrans);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool RoboticsOrganizationsTransExists(int id)
        {
            return _context.RoboticsOrganizationsTrans.Any(e => e.Id == id);
        }
    }
}
