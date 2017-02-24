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
    public class IndustriesController : Controller
    {
        private readonly RoboticsContext _context;

        public IndustriesController(RoboticsContext context)
        {
            _context = context;    
        }

        // GET: Industries
        public async Task<IActionResult> Index()
        {
            return View(await _context.Industries.ToListAsync());
        }

        // GET: Industries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var industries = await _context.Industries
                .SingleOrDefaultAsync(m => m.Id == id);
            if (industries == null)
            {
                return NotFound();
            }

            return View(industries);
        }

        // GET: Industries/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Industries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id")] Industries industries)
        {
            if (ModelState.IsValid)
            {
                _context.Add(industries);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(industries);
        }

        // GET: Industries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var industries = await _context.Industries.SingleOrDefaultAsync(m => m.Id == id);
            if (industries == null)
            {
                return NotFound();
            }
            return View(industries);
        }

        // POST: Industries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id")] Industries industries)
        {
            if (id != industries.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(industries);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IndustriesExists(industries.Id))
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
            return View(industries);
        }

        // GET: Industries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var industries = await _context.Industries
                .SingleOrDefaultAsync(m => m.Id == id);
            if (industries == null)
            {
                return NotFound();
            }

            return View(industries);
        }

        // POST: Industries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var industries = await _context.Industries.SingleOrDefaultAsync(m => m.Id == id);
            _context.Industries.Remove(industries);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool IndustriesExists(int id)
        {
            return _context.Industries.Any(e => e.Id == id);
        }
    }
}
