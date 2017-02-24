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
    public class RelatedContributingFieldsController : Controller
    {
        private readonly RoboticsContext _context;

        public RelatedContributingFieldsController(RoboticsContext context)
        {
            _context = context;    
        }

        // GET: RelatedContributingFields
        public async Task<IActionResult> Index()
        {
            var roboticsContext = _context.RelatedContributingFields.Include(r => r.Contributingfield1Navigation).Include(r => r.Contributingfield2Navigation);
            return View(await roboticsContext.ToListAsync());
        }

        // GET: RelatedContributingFields/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var relatedContributingFields = await _context.RelatedContributingFields
                .Include(r => r.Contributingfield1Navigation)
                .Include(r => r.Contributingfield2Navigation)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (relatedContributingFields == null)
            {
                return NotFound();
            }

            return View(relatedContributingFields);
        }

        // GET: RelatedContributingFields/Create
        public IActionResult Create()
        {
            ViewData["Contributingfield1"] = new SelectList(_context.ContributingFields, "Id", "Id");
            ViewData["Contributingfield2"] = new SelectList(_context.ContributingFields, "Id", "Id");
            return View();
        }

        // POST: RelatedContributingFields/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Contributingfield1,Contributingfield2")] RelatedContributingFields relatedContributingFields)
        {
            if (ModelState.IsValid)
            {
                _context.Add(relatedContributingFields);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["Contributingfield1"] = new SelectList(_context.ContributingFields, "Id", "Id", relatedContributingFields.Contributingfield1);
            ViewData["Contributingfield2"] = new SelectList(_context.ContributingFields, "Id", "Id", relatedContributingFields.Contributingfield2);
            return View(relatedContributingFields);
        }

        // GET: RelatedContributingFields/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var relatedContributingFields = await _context.RelatedContributingFields.SingleOrDefaultAsync(m => m.Id == id);
            if (relatedContributingFields == null)
            {
                return NotFound();
            }
            ViewData["Contributingfield1"] = new SelectList(_context.ContributingFields, "Id", "Id", relatedContributingFields.Contributingfield1);
            ViewData["Contributingfield2"] = new SelectList(_context.ContributingFields, "Id", "Id", relatedContributingFields.Contributingfield2);
            return View(relatedContributingFields);
        }

        // POST: RelatedContributingFields/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Contributingfield1,Contributingfield2")] RelatedContributingFields relatedContributingFields)
        {
            if (id != relatedContributingFields.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(relatedContributingFields);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RelatedContributingFieldsExists(relatedContributingFields.Id))
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
            ViewData["Contributingfield1"] = new SelectList(_context.ContributingFields, "Id", "Id", relatedContributingFields.Contributingfield1);
            ViewData["Contributingfield2"] = new SelectList(_context.ContributingFields, "Id", "Id", relatedContributingFields.Contributingfield2);
            return View(relatedContributingFields);
        }

        // GET: RelatedContributingFields/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var relatedContributingFields = await _context.RelatedContributingFields
                .Include(r => r.Contributingfield1Navigation)
                .Include(r => r.Contributingfield2Navigation)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (relatedContributingFields == null)
            {
                return NotFound();
            }

            return View(relatedContributingFields);
        }

        // POST: RelatedContributingFields/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var relatedContributingFields = await _context.RelatedContributingFields.SingleOrDefaultAsync(m => m.Id == id);
            _context.RelatedContributingFields.Remove(relatedContributingFields);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool RelatedContributingFieldsExists(int id)
        {
            return _context.RelatedContributingFields.Any(e => e.Id == id);
        }
    }
}
