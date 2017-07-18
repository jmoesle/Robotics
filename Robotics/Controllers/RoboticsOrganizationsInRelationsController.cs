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
    public class RoboticsOrganizationsInRelationsController : Controller
    {
        private readonly RoboticsContext _context;

        public RoboticsOrganizationsInRelationsController(RoboticsContext context)
        {
            _context = context;    
        }

        // GET: RoboticsOrganizationsInRelations
        public async Task<IActionResult> Index()
        {
            var roboticsContext = _context.RoboticsOrganizationsInRelation.Include(r => r.ContributingfieldsNavigation).Include(r => r.BranchesNavigation).Include(r => r.RoboticsorganizationsNavigation);
            return View(await roboticsContext.ToListAsync());
        }

        // GET: RoboticsOrganizationsInRelations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roboticsOrganizationsInRelation = await _context.RoboticsOrganizationsInRelation
                .Include(r => r.ContributingfieldsNavigation)
                .Include(r => r.BranchesNavigation)
                .Include(r => r.RoboticsorganizationsNavigation)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (roboticsOrganizationsInRelation == null)
            {
                return NotFound();
            }

            return View(roboticsOrganizationsInRelation);
        }

        // GET: RoboticsOrganizationsInRelations/Create
        public IActionResult Create()
        {
            ViewData["Contributingfields"] = new SelectList(_context.ContributingFields, "Id", "Id");
            ViewData["Branches"] = new SelectList(_context.Branches, "Id", "Id");
            ViewData["Roboticsorganizations"] = new SelectList(_context.RoboticsOrganizations, "Id", "Id");
            return View();
        }

        // POST: RoboticsOrganizationsInRelations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Roboticsorganizations,Branches,Contributingfields")] RoboticsOrganizationsInRelation roboticsOrganizationsInRelation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(roboticsOrganizationsInRelation);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["Contributingfields"] = new SelectList(_context.ContributingFields, "Id", "Id", roboticsOrganizationsInRelation.Contributingfields);
            ViewData["Branches"] = new SelectList(_context.Branches, "Id", "Id", roboticsOrganizationsInRelation.Branches);
            ViewData["Roboticsorganizations"] = new SelectList(_context.RoboticsOrganizations, "Id", "Id", roboticsOrganizationsInRelation.Roboticsorganizations);
            return View(roboticsOrganizationsInRelation);
        }

        // GET: RoboticsOrganizationsInRelations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roboticsOrganizationsInRelation = await _context.RoboticsOrganizationsInRelation.SingleOrDefaultAsync(m => m.Id == id);
            if (roboticsOrganizationsInRelation == null)
            {
                return NotFound();
            }
            ViewData["Contributingfields"] = new SelectList(_context.ContributingFields, "Id", "Id", roboticsOrganizationsInRelation.Contributingfields);
            ViewData["Branches"] = new SelectList(_context.Branches, "Id", "Id", roboticsOrganizationsInRelation.Branches);
            ViewData["Roboticsorganizations"] = new SelectList(_context.RoboticsOrganizations, "Id", "Id", roboticsOrganizationsInRelation.Roboticsorganizations);
            return View(roboticsOrganizationsInRelation);
        }

        // POST: RoboticsOrganizationsInRelations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Roboticsorganizations,Branches,Contributingfields")] RoboticsOrganizationsInRelation roboticsOrganizationsInRelation)
        {
            if (id != roboticsOrganizationsInRelation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(roboticsOrganizationsInRelation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoboticsOrganizationsInRelationExists(roboticsOrganizationsInRelation.Id))
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
            ViewData["Contributingfields"] = new SelectList(_context.ContributingFields, "Id", "Id", roboticsOrganizationsInRelation.Contributingfields);
            ViewData["Branches"] = new SelectList(_context.Branches, "Id", "Id", roboticsOrganizationsInRelation.Branches);
            ViewData["Roboticsorganizations"] = new SelectList(_context.RoboticsOrganizations, "Id", "Id", roboticsOrganizationsInRelation.Roboticsorganizations);
            return View(roboticsOrganizationsInRelation);
        }

        // GET: RoboticsOrganizationsInRelations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roboticsOrganizationsInRelation = await _context.RoboticsOrganizationsInRelation
                .Include(r => r.ContributingfieldsNavigation)
                .Include(r => r.BranchesNavigation)
                .Include(r => r.RoboticsorganizationsNavigation)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (roboticsOrganizationsInRelation == null)
            {
                return NotFound();
            }

            return View(roboticsOrganizationsInRelation);
        }

        // POST: RoboticsOrganizationsInRelations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var roboticsOrganizationsInRelation = await _context.RoboticsOrganizationsInRelation.SingleOrDefaultAsync(m => m.Id == id);
            _context.RoboticsOrganizationsInRelation.Remove(roboticsOrganizationsInRelation);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool RoboticsOrganizationsInRelationExists(int id)
        {
            return _context.RoboticsOrganizationsInRelation.Any(e => e.Id == id);
        }
    }
}
