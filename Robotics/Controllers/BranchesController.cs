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
    public class BranchesController : Controller
    {
        private readonly RoboticsContext _context;

        public BranchesController(RoboticsContext context)
        {
            _context = context;    
        }

        // GET: Branches
        public async Task<IActionResult> Index()
        {
            return View(await _context.Branches.ToListAsync());
        }

        // GET: Branches/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Branches = await _context.Branches
                .SingleOrDefaultAsync(m => m.Id == id);
            if (Branches == null)
            {
                return NotFound();
            }

            return View(Branches);
        }

        // GET: Branches/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Branches/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id")] Branches Branches)
        {
            if (ModelState.IsValid)
            {
                _context.Add(Branches);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(Branches);
        }

        // GET: Branches/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Branches = await _context.Branches.SingleOrDefaultAsync(m => m.Id == id);
            if (Branches == null)
            {
                return NotFound();
            }
            return View(Branches);
        }

        // POST: Branches/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id")] Branches Branches)
        {
            if (id != Branches.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(Branches);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BranchesExists(Branches.Id))
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
            return View(Branches);
        }

        // GET: Branches/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Branches = await _context.Branches
                .SingleOrDefaultAsync(m => m.Id == id);
            if (Branches == null)
            {
                return NotFound();
            }

            return View(Branches);
        }

        // POST: Branches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var Branches = await _context.Branches.SingleOrDefaultAsync(m => m.Id == id);
            _context.Branches.Remove(Branches);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool BranchesExists(int id)
        {
            return _context.Branches.Any(e => e.Id == id);
        }
    }
}
