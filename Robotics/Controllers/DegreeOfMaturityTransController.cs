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
    public class DegreeOfMaturityTransController : Controller
    {
        private readonly RoboticsContext _context;

        public DegreeOfMaturityTransController(RoboticsContext context)
        {
            _context = context;    
        }

        // GET: DegreeOfMaturityTrans
        public async Task<IActionResult> Index()
        {
            var roboticsContext = _context.DegreeOfMaturityTrans.Include(d => d.DegreeofmaturityNavigation).Include(d => d.LanguageNavigation);
            return View(await roboticsContext.ToListAsync());
        }

        // GET: DegreeOfMaturityTrans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var degreeOfMaturityTrans = await _context.DegreeOfMaturityTrans
                .Include(d => d.DegreeofmaturityNavigation)
                .Include(d => d.LanguageNavigation)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (degreeOfMaturityTrans == null)
            {
                return NotFound();
            }

            return View(degreeOfMaturityTrans);
        }

        // GET: DegreeOfMaturityTrans/Create
        public IActionResult Create()
        {
            ViewData["Degreeofmaturity"] = new SelectList(_context.DegreeOfMaturity, "Id", "Id");
            ViewData["Language"] = new SelectList(_context.Languages, "Id", "Code");
            return View();
        }

        // POST: DegreeOfMaturityTrans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int DegreeOfMaturity, [Bind("Id,Name,Degreeofmaturity,Language")] DegreeOfMaturityTrans degreeOfMaturityTrans)
        {
            if (ModelState.IsValid)
            {
                if (DegreeOfMaturity == 0) { DegreeOfMaturity entry = new DegreeOfMaturity(); _context.Add(entry); degreeOfMaturityTrans.Degreeofmaturity = entry.Id; }
            
                _context.Add(degreeOfMaturityTrans);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["Degreeofmaturity"] = new SelectList(_context.DegreeOfMaturity, "Id", "Id", degreeOfMaturityTrans.Degreeofmaturity);
            ViewData["Language"] = new SelectList(_context.Languages, "Id", "Code", degreeOfMaturityTrans.Language);
            return View(degreeOfMaturityTrans);
        }

        // GET: DegreeOfMaturityTrans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var degreeOfMaturityTrans = await _context.DegreeOfMaturityTrans.SingleOrDefaultAsync(m => m.Id == id);
            if (degreeOfMaturityTrans == null)
            {
                return NotFound();
            }
            ViewData["Degreeofmaturity"] = new SelectList(_context.DegreeOfMaturity, "Id", "Id", degreeOfMaturityTrans.Degreeofmaturity);
            ViewData["Language"] = new SelectList(_context.Languages, "Id", "Code", degreeOfMaturityTrans.Language);
            return View(degreeOfMaturityTrans);
        }

        // POST: DegreeOfMaturityTrans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Degreeofmaturity,Language")] DegreeOfMaturityTrans degreeOfMaturityTrans)
        {
            if (id != degreeOfMaturityTrans.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(degreeOfMaturityTrans);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DegreeOfMaturityTransExists(degreeOfMaturityTrans.Id))
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
            ViewData["Degreeofmaturity"] = new SelectList(_context.DegreeOfMaturity, "Id", "Id", degreeOfMaturityTrans.Degreeofmaturity);
            ViewData["Language"] = new SelectList(_context.Languages, "Id", "Code", degreeOfMaturityTrans.Language);
            return View(degreeOfMaturityTrans);
        }

        // GET: DegreeOfMaturityTrans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var degreeOfMaturityTrans = await _context.DegreeOfMaturityTrans
                .Include(d => d.DegreeofmaturityNavigation)
                .Include(d => d.LanguageNavigation)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (degreeOfMaturityTrans == null)
            {
                return NotFound();
            }

            return View(degreeOfMaturityTrans);
        }

        // POST: DegreeOfMaturityTrans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var degreeOfMaturityTrans = await _context.DegreeOfMaturityTrans.SingleOrDefaultAsync(m => m.Id == id);
            _context.DegreeOfMaturityTrans.Remove(degreeOfMaturityTrans);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool DegreeOfMaturityTransExists(int id)
        {
            return _context.DegreeOfMaturityTrans.Any(e => e.Id == id);
        }
    }
}
