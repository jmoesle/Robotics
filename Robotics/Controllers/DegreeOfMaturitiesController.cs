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
    public class DegreeOfMaturitiesController : Controller
    {
        private readonly RoboticsContext _context;

        public DegreeOfMaturitiesController(RoboticsContext context)
        {
            _context = context;    
        }

        // GET: DegreeOfMaturities
        public async Task<IActionResult> Index()
        {
            return View(await _context.DegreeOfMaturity.ToListAsync());
        }

        // GET: DegreeOfMaturities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var degreeOfMaturity = await _context.DegreeOfMaturity
                .SingleOrDefaultAsync(m => m.Id == id);
            if (degreeOfMaturity == null)
            {
                return NotFound();
            }

            return View(degreeOfMaturity);
        }

        // GET: DegreeOfMaturities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DegreeOfMaturities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id")] DegreeOfMaturity degreeOfMaturity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(degreeOfMaturity);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(degreeOfMaturity);
        }

        // GET: DegreeOfMaturities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var degreeOfMaturity = await _context.DegreeOfMaturity.SingleOrDefaultAsync(m => m.Id == id);
            if (degreeOfMaturity == null)
            {
                return NotFound();
            }
            return View(degreeOfMaturity);
        }

        // POST: DegreeOfMaturities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id")] DegreeOfMaturity degreeOfMaturity)
        {
            if (id != degreeOfMaturity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(degreeOfMaturity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DegreeOfMaturityExists(degreeOfMaturity.Id))
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
            return View(degreeOfMaturity);
        }

        // GET: DegreeOfMaturities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var degreeOfMaturity = await _context.DegreeOfMaturity
                .SingleOrDefaultAsync(m => m.Id == id);
            if (degreeOfMaturity == null)
            {
                return NotFound();
            }

            return View(degreeOfMaturity);
        }

        // POST: DegreeOfMaturities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var degreeOfMaturity = await _context.DegreeOfMaturity.SingleOrDefaultAsync(m => m.Id == id);
            _context.DegreeOfMaturity.Remove(degreeOfMaturity);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool DegreeOfMaturityExists(int id)
        {
            return _context.DegreeOfMaturity.Any(e => e.Id == id);
        }
    }
}
