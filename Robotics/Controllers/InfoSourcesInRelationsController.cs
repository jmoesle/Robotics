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
    public class InfoSourcesInRelationsController : Controller
    {
        private readonly RoboticsContext _context;

        public InfoSourcesInRelationsController(RoboticsContext context)
        {
            _context = context;    
        }

        // GET: InfoSourcesInRelations
        public async Task<IActionResult> Index()
        {
            var roboticsContext = _context.InfoSourcesInRelation.Include(i => i.InfosourcesNavigation);
            return View(await roboticsContext.ToListAsync());
        }

        // GET: InfoSourcesInRelations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var infoSourcesInRelation = await _context.InfoSourcesInRelation
                .Include(i => i.InfosourcesNavigation)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (infoSourcesInRelation == null)
            {
                return NotFound();
            }

            return View(infoSourcesInRelation);
        }

        // GET: InfoSourcesInRelations/Create
        public IActionResult Create()
        {
            ViewData["Infosources"] = new SelectList(_context.InfoSources, "Id", "Id");
            return View();
        }

        // POST: InfoSourcesInRelations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Tablename,Tableid,Infosources")] InfoSourcesInRelation infoSourcesInRelation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(infoSourcesInRelation);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["Infosources"] = new SelectList(_context.InfoSources, "Id", "Id", infoSourcesInRelation.Infosources);
            return View(infoSourcesInRelation);
        }

        // GET: InfoSourcesInRelations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var infoSourcesInRelation = await _context.InfoSourcesInRelation.SingleOrDefaultAsync(m => m.Id == id);
            if (infoSourcesInRelation == null)
            {
                return NotFound();
            }
            ViewData["Infosources"] = new SelectList(_context.InfoSources, "Id", "Id", infoSourcesInRelation.Infosources);
            return View(infoSourcesInRelation);
        }

        // POST: InfoSourcesInRelations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Tablename,Tableid,Infosources")] InfoSourcesInRelation infoSourcesInRelation)
        {
            if (id != infoSourcesInRelation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(infoSourcesInRelation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InfoSourcesInRelationExists(infoSourcesInRelation.Id))
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
            ViewData["Infosources"] = new SelectList(_context.InfoSources, "Id", "Id", infoSourcesInRelation.Infosources);
            return View(infoSourcesInRelation);
        }

        // GET: InfoSourcesInRelations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var infoSourcesInRelation = await _context.InfoSourcesInRelation
                .Include(i => i.InfosourcesNavigation)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (infoSourcesInRelation == null)
            {
                return NotFound();
            }

            return View(infoSourcesInRelation);
        }

        // POST: InfoSourcesInRelations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var infoSourcesInRelation = await _context.InfoSourcesInRelation.SingleOrDefaultAsync(m => m.Id == id);
            _context.InfoSourcesInRelation.Remove(infoSourcesInRelation);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool InfoSourcesInRelationExists(int id)
        {
            return _context.InfoSourcesInRelation.Any(e => e.Id == id);
        }
    }
}
