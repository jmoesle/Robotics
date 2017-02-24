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
    public class CountriesTransController : Controller
    {
        private readonly RoboticsContext _context;

        public CountriesTransController(RoboticsContext context)
        {
            _context = context;    
        }

        // GET: CountriesTrans
        public async Task<IActionResult> Index()
        {
            var roboticsContext = _context.CountriesTrans.Include(c => c.CountriesNavigation).Include(c => c.LanguageNavigation);
            return View(await roboticsContext.ToListAsync());
        }

        // GET: CountriesTrans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var countriesTrans = await _context.CountriesTrans
                .Include(c => c.CountriesNavigation)
                .Include(c => c.LanguageNavigation)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (countriesTrans == null)
            {
                return NotFound();
            }

            return View(countriesTrans);
        }

        // GET: CountriesTrans/Create
        public IActionResult Create()
        {
            ViewData["Countries"] = new SelectList(_context.Countries, "Id", "Code");
            ViewData["Language"] = new SelectList(_context.Languages, "Id", "Code");
            return View();
        }

        // POST: CountriesTrans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Countries,Name,Language")] CountriesTrans countriesTrans)
        {
            if (ModelState.IsValid)
            {
                _context.Add(countriesTrans);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["Countries"] = new SelectList(_context.Countries, "Id", "Code", countriesTrans.Countries);
            ViewData["Language"] = new SelectList(_context.Languages, "Id", "Code", countriesTrans.Language);
            return View(countriesTrans);
        }

        // GET: CountriesTrans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var countriesTrans = await _context.CountriesTrans.SingleOrDefaultAsync(m => m.Id == id);
            if (countriesTrans == null)
            {
                return NotFound();
            }
            ViewData["Countries"] = new SelectList(_context.Countries, "Id", "Code", countriesTrans.Countries);
            ViewData["Language"] = new SelectList(_context.Languages, "Id", "Code", countriesTrans.Language);
            return View(countriesTrans);
        }

        // POST: CountriesTrans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Countries,Name,Language")] CountriesTrans countriesTrans)
        {
            if (id != countriesTrans.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(countriesTrans);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CountriesTransExists(countriesTrans.Id))
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
            ViewData["Countries"] = new SelectList(_context.Countries, "Id", "Code", countriesTrans.Countries);
            ViewData["Language"] = new SelectList(_context.Languages, "Id", "Code", countriesTrans.Language);
            return View(countriesTrans);
        }

        // GET: CountriesTrans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var countriesTrans = await _context.CountriesTrans
                .Include(c => c.CountriesNavigation)
                .Include(c => c.LanguageNavigation)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (countriesTrans == null)
            {
                return NotFound();
            }

            return View(countriesTrans);
        }

        // POST: CountriesTrans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var countriesTrans = await _context.CountriesTrans.SingleOrDefaultAsync(m => m.Id == id);
            _context.CountriesTrans.Remove(countriesTrans);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool CountriesTransExists(int id)
        {
            return _context.CountriesTrans.Any(e => e.Id == id);
        }
    }
}
