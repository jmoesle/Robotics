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
    public class RoboticsCompaniesInRelationsController : Controller
    {
        private readonly RoboticsContext _context;

        public RoboticsCompaniesInRelationsController(RoboticsContext context)
        {
            _context = context;    
        }

        // GET: RoboticsCompaniesInRelations
        public async Task<IActionResult> Index()
        {
            var roboticsContext = _context.RoboticsCompaniesInRelation.Include(r => r.ContributingfieldsNavigation).Include(r => r.BranchesNavigation).Include(r => r.RoboticscompaniesNavigation);
            return View(await roboticsContext.ToListAsync());
        }

        // GET: RoboticsCompaniesInRelations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roboticsCompaniesInRelation = await _context.RoboticsCompaniesInRelation
                .Include(r => r.ContributingfieldsNavigation)
                .Include(r => r.BranchesNavigation)
                .Include(r => r.RoboticscompaniesNavigation)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (roboticsCompaniesInRelation == null)
            {
                return NotFound();
            }

            return View(roboticsCompaniesInRelation);
        }

        // GET: RoboticsCompaniesInRelations/Create
        public IActionResult Create()
        {
            ViewData["Contributingfields"] = new SelectList(_context.ContributingFields, "Id", "Id");
            ViewData["Branches"] = new SelectList(_context.Branches, "Id", "Id");
            ViewData["Roboticscompanies"] = new SelectList(_context.RoboticsCompanies, "Id", "Id");
            return View();
        }

        // POST: RoboticsCompaniesInRelations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Roboticscompanies,Branches,Contributingfields")] RoboticsCompaniesInRelation roboticsCompaniesInRelation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(roboticsCompaniesInRelation);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["Contributingfields"] = new SelectList(_context.ContributingFields, "Id", "Id", roboticsCompaniesInRelation.Contributingfields);
            ViewData["Branches"] = new SelectList(_context.Branches, "Id", "Id", roboticsCompaniesInRelation.Branches);
            ViewData["Roboticscompanies"] = new SelectList(_context.RoboticsCompanies, "Id", "Id", roboticsCompaniesInRelation.Roboticscompanies);
            return View(roboticsCompaniesInRelation);
        }

        // GET: RoboticsCompaniesInRelations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roboticsCompaniesInRelation = await _context.RoboticsCompaniesInRelation.SingleOrDefaultAsync(m => m.Id == id);
            if (roboticsCompaniesInRelation == null)
            {
                return NotFound();
            }
            ViewData["Contributingfields"] = new SelectList(_context.ContributingFields, "Id", "Id", roboticsCompaniesInRelation.Contributingfields);
            ViewData["Branches"] = new SelectList(_context.Branches, "Id", "Id", roboticsCompaniesInRelation.Branches);
            ViewData["Roboticscompanies"] = new SelectList(_context.RoboticsCompanies, "Id", "Id", roboticsCompaniesInRelation.Roboticscompanies);
            return View(roboticsCompaniesInRelation);
        }

        // POST: RoboticsCompaniesInRelations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Roboticscompanies,Branches,Contributingfields")] RoboticsCompaniesInRelation roboticsCompaniesInRelation)
        {
            if (id != roboticsCompaniesInRelation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(roboticsCompaniesInRelation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoboticsCompaniesInRelationExists(roboticsCompaniesInRelation.Id))
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
            ViewData["Contributingfields"] = new SelectList(_context.ContributingFields, "Id", "Id", roboticsCompaniesInRelation.Contributingfields);
            ViewData["Branches"] = new SelectList(_context.Branches, "Id", "Id", roboticsCompaniesInRelation.Branches);
            ViewData["Roboticscompanies"] = new SelectList(_context.RoboticsCompanies, "Id", "Id", roboticsCompaniesInRelation.Roboticscompanies);
            return View(roboticsCompaniesInRelation);
        }

        // GET: RoboticsCompaniesInRelations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roboticsCompaniesInRelation = await _context.RoboticsCompaniesInRelation
                .Include(r => r.ContributingfieldsNavigation)
                .Include(r => r.BranchesNavigation)
                .Include(r => r.RoboticscompaniesNavigation)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (roboticsCompaniesInRelation == null)
            {
                return NotFound();
            }

            return View(roboticsCompaniesInRelation);
        }

        // POST: RoboticsCompaniesInRelations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var roboticsCompaniesInRelation = await _context.RoboticsCompaniesInRelation.SingleOrDefaultAsync(m => m.Id == id);
            _context.RoboticsCompaniesInRelation.Remove(roboticsCompaniesInRelation);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool RoboticsCompaniesInRelationExists(int id)
        {
            return _context.RoboticsCompaniesInRelation.Any(e => e.Id == id);
        }
    }
}
