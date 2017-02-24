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
    public class TypesInRelationsController : Controller
    {
        private readonly RoboticsContext _context;

        public TypesInRelationsController(RoboticsContext context)
        {
            _context = context;    
        }

        // GET: TypesInRelations
        public async Task<IActionResult> Index()
        {
            var roboticsContext = _context.TypesInRelation.Include(t => t.ModesoflocomotionNavigation).Include(t => t.RoboticsprinciplesNavigation).Include(t => t.TypesNavigation);
            return View(await roboticsContext.ToListAsync());
        }

        // GET: TypesInRelations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typesInRelation = await _context.TypesInRelation
                .Include(t => t.ModesoflocomotionNavigation)
                .Include(t => t.RoboticsprinciplesNavigation)
                .Include(t => t.TypesNavigation)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (typesInRelation == null)
            {
                return NotFound();
            }

            return View(typesInRelation);
        }

        // GET: TypesInRelations/Create
        public IActionResult Create()
        {
            ViewData["Modesoflocomotion"] = new SelectList(_context.ModesOfLocomotion, "Id", "Id");
            ViewData["Roboticsprinciples"] = new SelectList(_context.RoboticsPrinciples, "Id", "Id");
            ViewData["Types"] = new SelectList(_context.Types, "Id", "Id");
            return View();
        }

        // POST: TypesInRelations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Types,Roboticsprinciples,Modesoflocomotion")] TypesInRelation typesInRelation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(typesInRelation);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["Modesoflocomotion"] = new SelectList(_context.ModesOfLocomotion, "Id", "Id", typesInRelation.Modesoflocomotion);
            ViewData["Roboticsprinciples"] = new SelectList(_context.RoboticsPrinciples, "Id", "Id", typesInRelation.Roboticsprinciples);
            ViewData["Types"] = new SelectList(_context.Types, "Id", "Id", typesInRelation.Types);
            return View(typesInRelation);
        }

        // GET: TypesInRelations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typesInRelation = await _context.TypesInRelation.SingleOrDefaultAsync(m => m.Id == id);
            if (typesInRelation == null)
            {
                return NotFound();
            }
            ViewData["Modesoflocomotion"] = new SelectList(_context.ModesOfLocomotion, "Id", "Id", typesInRelation.Modesoflocomotion);
            ViewData["Roboticsprinciples"] = new SelectList(_context.RoboticsPrinciples, "Id", "Id", typesInRelation.Roboticsprinciples);
            ViewData["Types"] = new SelectList(_context.Types, "Id", "Id", typesInRelation.Types);
            return View(typesInRelation);
        }

        // POST: TypesInRelations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Types,Roboticsprinciples,Modesoflocomotion")] TypesInRelation typesInRelation)
        {
            if (id != typesInRelation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(typesInRelation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TypesInRelationExists(typesInRelation.Id))
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
            ViewData["Modesoflocomotion"] = new SelectList(_context.ModesOfLocomotion, "Id", "Id", typesInRelation.Modesoflocomotion);
            ViewData["Roboticsprinciples"] = new SelectList(_context.RoboticsPrinciples, "Id", "Id", typesInRelation.Roboticsprinciples);
            ViewData["Types"] = new SelectList(_context.Types, "Id", "Id", typesInRelation.Types);
            return View(typesInRelation);
        }

        // GET: TypesInRelations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typesInRelation = await _context.TypesInRelation
                .Include(t => t.ModesoflocomotionNavigation)
                .Include(t => t.RoboticsprinciplesNavigation)
                .Include(t => t.TypesNavigation)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (typesInRelation == null)
            {
                return NotFound();
            }

            return View(typesInRelation);
        }

        // POST: TypesInRelations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var typesInRelation = await _context.TypesInRelation.SingleOrDefaultAsync(m => m.Id == id);
            _context.TypesInRelation.Remove(typesInRelation);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool TypesInRelationExists(int id)
        {
            return _context.TypesInRelation.Any(e => e.Id == id);
        }
    }
}
