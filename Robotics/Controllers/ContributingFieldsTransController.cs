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
    public class ContributingFieldsTransController : Controller
    {
        private readonly RoboticsContext _context;

        public ContributingFieldsTransController(RoboticsContext context)
        {
            _context = context;    
        }

        // GET: ContributingFieldsTrans
        public async Task<IActionResult> Index()
        {
            var roboticsContext = _context.ContributingFieldsTrans.Include(c => c.ContributingfieldsNavigation).Include(c => c.LanguageNavigation);
            return View(await roboticsContext.ToListAsync());
        }

        // GET: ContributingFieldsTrans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contributingFieldsTrans = await _context.ContributingFieldsTrans
                .Include(c => c.ContributingfieldsNavigation)
                .Include(c => c.LanguageNavigation)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (contributingFieldsTrans == null)
            {
                return NotFound();
            }

            return View(contributingFieldsTrans);
        }

        // GET: ContributingFieldsTrans/Create
        public IActionResult Create()
        {
            ViewData["Contributingfields"] = new SelectList(_context.ContributingFields, "Id", "Id");
            ViewData["Language"] = new SelectList(_context.Languages, "Id", "Code");
            return View();
        }

        // POST: ContributingFieldsTrans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int ContributingFields, [Bind("Id,Name,Description,Contributingfields,Language")] ContributingFieldsTrans contributingFieldsTrans)
        {
            if (ModelState.IsValid)
            {
                if (ContributingFields == 0) { ContributingFields entry = new ContributingFields(); _context.Add(entry); contributingFieldsTrans.Contributingfields = entry.Id; }

                _context.Add(contributingFieldsTrans);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["Contributingfields"] = new SelectList(_context.ContributingFields, "Id", "Id", contributingFieldsTrans.Contributingfields);
            ViewData["Language"] = new SelectList(_context.Languages, "Id", "Code", contributingFieldsTrans.Language);
            return View(contributingFieldsTrans);
        }

        // GET: ContributingFieldsTrans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contributingFieldsTrans = await _context.ContributingFieldsTrans.SingleOrDefaultAsync(m => m.Id == id);
            if (contributingFieldsTrans == null)
            {
                return NotFound();
            }
            ViewData["Contributingfields"] = new SelectList(_context.ContributingFields, "Id", "Id", contributingFieldsTrans.Contributingfields);
            ViewData["Language"] = new SelectList(_context.Languages, "Id", "Code", contributingFieldsTrans.Language);
            return View(contributingFieldsTrans);
        }

        // POST: ContributingFieldsTrans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Contributingfields,Language")] ContributingFieldsTrans contributingFieldsTrans)
        {
            if (id != contributingFieldsTrans.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contributingFieldsTrans);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContributingFieldsTransExists(contributingFieldsTrans.Id))
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
            ViewData["Contributingfields"] = new SelectList(_context.ContributingFields, "Id", "Id", contributingFieldsTrans.Contributingfields);
            ViewData["Language"] = new SelectList(_context.Languages, "Id", "Code", contributingFieldsTrans.Language);
            return View(contributingFieldsTrans);
        }

        // GET: ContributingFieldsTrans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contributingFieldsTrans = await _context.ContributingFieldsTrans
                .Include(c => c.ContributingfieldsNavigation)
                .Include(c => c.LanguageNavigation)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (contributingFieldsTrans == null)
            {
                return NotFound();
            }

            return View(contributingFieldsTrans);
        }

        // POST: ContributingFieldsTrans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contributingFieldsTrans = await _context.ContributingFieldsTrans.SingleOrDefaultAsync(m => m.Id == id);
            _context.ContributingFieldsTrans.Remove(contributingFieldsTrans);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ContributingFieldsTransExists(int id)
        {
            return _context.ContributingFieldsTrans.Any(e => e.Id == id);
        }
    }
}
