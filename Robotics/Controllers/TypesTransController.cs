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
    public class TypesTransController : Controller
    {
        private readonly RoboticsContext _context;

        public TypesTransController(RoboticsContext context)
        {
            _context = context;    
        }

        // GET: TypesTrans
        public async Task<IActionResult> Index()
        {
            var roboticsContext = _context.TypesTrans.Include(t => t.LanguageNavigation).Include(t => t.TypesNavigation);
            return View(await roboticsContext.ToListAsync());
        }

        // GET: TypesTrans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typesTrans = await _context.TypesTrans
                .Include(t => t.LanguageNavigation)
                .Include(t => t.TypesNavigation)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (typesTrans == null)
            {
                return NotFound();
            }

            return View(typesTrans);
        }

        // GET: TypesTrans/Create
        public IActionResult Create()
        {
            ViewData["Language"] = new SelectList(_context.Languages, "Id", "Code");
            ViewData["Types"] = new SelectList(_context.Types, "Id", "Id");
            return View();
        }

        // POST: TypesTrans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int Types, [Bind("Id,Name,Description,Language,Types")] TypesTrans typesTrans)
        {
            if (ModelState.IsValid)
            {
                if (Types == 0) { Types entry = new Types(); _context.Add(entry); typesTrans.Types = entry.Id; }

                _context.Add(typesTrans);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["Language"] = new SelectList(_context.Languages, "Id", "Code", typesTrans.Language);
            ViewData["Types"] = new SelectList(_context.Types, "Id", "Id", typesTrans.Types);
            return View(typesTrans);
        }

        // GET: TypesTrans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typesTrans = await _context.TypesTrans.SingleOrDefaultAsync(m => m.Id == id);
            if (typesTrans == null)
            {
                return NotFound();
            }
            ViewData["Language"] = new SelectList(_context.Languages, "Id", "Code", typesTrans.Language);
            ViewData["Types"] = new SelectList(_context.Types, "Id", "Id", typesTrans.Types);
            return View(typesTrans);
        }

        // POST: TypesTrans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Language,Types")] TypesTrans typesTrans)
        {
            if (id != typesTrans.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(typesTrans);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TypesTransExists(typesTrans.Id))
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
            ViewData["Language"] = new SelectList(_context.Languages, "Id", "Code", typesTrans.Language);
            ViewData["Types"] = new SelectList(_context.Types, "Id", "Id", typesTrans.Types);
            return View(typesTrans);
        }

        // GET: TypesTrans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typesTrans = await _context.TypesTrans
                .Include(t => t.LanguageNavigation)
                .Include(t => t.TypesNavigation)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (typesTrans == null)
            {
                return NotFound();
            }

            return View(typesTrans);
        }

        // POST: TypesTrans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var typesTrans = await _context.TypesTrans.SingleOrDefaultAsync(m => m.Id == id);
            _context.TypesTrans.Remove(typesTrans);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool TypesTransExists(int id)
        {
            return _context.TypesTrans.Any(e => e.Id == id);
        }
    }
}
