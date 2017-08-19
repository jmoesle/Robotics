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
    public class RoboticsCompetitionsInRelationsController : Controller
    {
        private readonly RoboticsContext _context;

        public RoboticsCompetitionsInRelationsController(RoboticsContext context)
        {
            _context = context;    
        }

        // GET: RoboticsCompetitionsInRelations
        public async Task<IActionResult> Index()
        {
            var roboticsContext = _context.RoboticsCompetitionsInRelation.Include(r => r.ContributingfieldsNavigation).Include(r => r.BusinessNavigation).Include(r => r.BranchesNavigation).Include(r => r.RoboticscompetitionsNavigation);
            return View(await roboticsContext.ToListAsync());
        }

        // GET: RoboticsCompetitionsInRelations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roboticsCompetitionsInRelation = await _context.RoboticsCompetitionsInRelation
                .Include(r => r.ContributingfieldsNavigation)
                .Include(r => r.BusinessNavigation)
                .Include(r => r.BranchesNavigation)
                .Include(r => r.RoboticscompetitionsNavigation)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (roboticsCompetitionsInRelation == null)
            {
                return NotFound();
            }

            return View(roboticsCompetitionsInRelation);
        }

        // GET: RoboticsCompetitionsInRelations/Create
        public IActionResult Create()
        {
            ViewData["Contributingfields"] = new SelectList(_context.ContributingFields, "Id", "Id");
            ViewData["Business"] = new SelectList(_context.Business, "Id", "Id");

            ViewData["Branches"] = new SelectList(_context.Branches, "Id", "Id");
            ViewData["Roboticscompetitions"] = new SelectList(_context.RoboticsCompetitions, "Id", "Id");
            return View();
        }

        // POST: RoboticsCompetitionsInRelations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Roboticscompetitions,Business,Branches,Contributingfields")] RoboticsCompetitionsInRelation roboticsCompetitionsInRelation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(roboticsCompetitionsInRelation);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["Contributingfields"] = new SelectList(_context.ContributingFields, "Id", "Id", roboticsCompetitionsInRelation.Contributingfields);
            ViewData["Business"] = new SelectList(_context.Business, "Id", "Id", roboticsCompetitionsInRelation.Business);

            ViewData["Branches"] = new SelectList(_context.Branches, "Id", "Id", roboticsCompetitionsInRelation.Branches);
            ViewData["Roboticscompetitions"] = new SelectList(_context.RoboticsCompetitions, "Id", "Id", roboticsCompetitionsInRelation.Roboticscompetitions);
            return View(roboticsCompetitionsInRelation);
        }

        // GET: RoboticsCompetitionsInRelations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roboticsCompetitionsInRelation = await _context.RoboticsCompetitionsInRelation.SingleOrDefaultAsync(m => m.Id == id);
            if (roboticsCompetitionsInRelation == null)
            {
                return NotFound();
            }
            ViewData["Contributingfields"] = new SelectList(_context.ContributingFields, "Id", "Id", roboticsCompetitionsInRelation.Contributingfields);
            ViewData["Business"] = new SelectList(_context.Business, "Id", "Id", roboticsCompetitionsInRelation.Business);

            ViewData["Branches"] = new SelectList(_context.Branches, "Id", "Id", roboticsCompetitionsInRelation.Branches);
            ViewData["Roboticscompetitions"] = new SelectList(_context.RoboticsCompetitions, "Id", "Id", roboticsCompetitionsInRelation.Roboticscompetitions);
            return View(roboticsCompetitionsInRelation);
        }

        // POST: RoboticsCompetitionsInRelations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Roboticscompetitions,Business,Branches,Contributingfields")] RoboticsCompetitionsInRelation roboticsCompetitionsInRelation)
        {
            if (id != roboticsCompetitionsInRelation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(roboticsCompetitionsInRelation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoboticsCompetitionsInRelationExists(roboticsCompetitionsInRelation.Id))
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
            ViewData["Contributingfields"] = new SelectList(_context.ContributingFields, "Id", "Id", roboticsCompetitionsInRelation.Contributingfields);
            ViewData["Business"] = new SelectList(_context.Business, "Id", "Id", roboticsCompetitionsInRelation.Business);

            ViewData["Branches"] = new SelectList(_context.Branches, "Id", "Id", roboticsCompetitionsInRelation.Branches);
            ViewData["Roboticscompetitions"] = new SelectList(_context.RoboticsCompetitions, "Id", "Id", roboticsCompetitionsInRelation.Roboticscompetitions);
            return View(roboticsCompetitionsInRelation);
        }

        // GET: RoboticsCompetitionsInRelations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roboticsCompetitionsInRelation = await _context.RoboticsCompetitionsInRelation
                .Include(r => r.ContributingfieldsNavigation)
                                .Include(r => r.BusinessNavigation)

                .Include(r => r.BranchesNavigation)
                .Include(r => r.RoboticscompetitionsNavigation)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (roboticsCompetitionsInRelation == null)
            {
                return NotFound();
            }

            return View(roboticsCompetitionsInRelation);
        }

        // POST: RoboticsCompetitionsInRelations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var roboticsCompetitionsInRelation = await _context.RoboticsCompetitionsInRelation.SingleOrDefaultAsync(m => m.Id == id);
            _context.RoboticsCompetitionsInRelation.Remove(roboticsCompetitionsInRelation);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool RoboticsCompetitionsInRelationExists(int id)
        {
            return _context.RoboticsCompetitionsInRelation.Any(e => e.Id == id);
        }
    }
}
