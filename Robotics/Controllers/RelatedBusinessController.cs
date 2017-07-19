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
    public class RelatedBusinessController : Controller
    {
        private readonly RoboticsContext _context;

        public RelatedBusinessController(RoboticsContext context)
        {
            _context = context;    
        }

        // GET: RelatedBusiness
        public async Task<IActionResult> Index()
        {
            var roboticsContext = _context.RelatedBusiness.Include(r => r.Business1Navigation).Include(r => r.Business2Navigation);
            return View(await roboticsContext.ToListAsync());
        }

        // GET: RelatedBusiness/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var relatedBusiness = await _context.RelatedBusiness
                .Include(r => r.Business1Navigation)
                .Include(r => r.Business2Navigation)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (relatedBusiness == null)
            {
                return NotFound();
            }

            return View(relatedBusiness);
        }

        // GET: RelatedBusiness/Create
        public IActionResult Create()
        {
            ViewData["Business1"] = new SelectList(_context.Business, "Id", "Id");
            ViewData["Business2"] = new SelectList(_context.Business, "Id", "Id");
            return View();
        }

        // POST: RelatedBusiness/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Business1,Business2")] RelatedBusiness relatedBusiness)
        {
            if (ModelState.IsValid)
            {
                _context.Add(relatedBusiness);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["Business1"] = new SelectList(_context.Business, "Id", "Id", relatedBusiness.Business1);
            ViewData["Business2"] = new SelectList(_context.Business, "Id", "Id", relatedBusiness.Business2);
            return View(relatedBusiness);
        }

        // GET: RelatedBusiness/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var relatedBusiness = await _context.RelatedBusiness.SingleOrDefaultAsync(m => m.Id == id);
            if (relatedBusiness == null)
            {
                return NotFound();
            }
            ViewData["Business1"] = new SelectList(_context.Business, "Id", "Id", relatedBusiness.Business1);
            ViewData["Business2"] = new SelectList(_context.Business, "Id", "Id", relatedBusiness.Business2);
            return View(relatedBusiness);
        }

        // POST: RelatedBusiness/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Business1,Business2")] RelatedBusiness relatedBusiness)
        {
            if (id != relatedBusiness.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(relatedBusiness);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RelatedBusinessExists(relatedBusiness.Id))
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
            ViewData["Business1"] = new SelectList(_context.Business, "Id", "Id", relatedBusiness.Business1);
            ViewData["Business2"] = new SelectList(_context.Business, "Id", "Id", relatedBusiness.Business2);
            return View(relatedBusiness);
        }

        // GET: RelatedBusiness/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var relatedBusiness = await _context.RelatedBusiness
                .Include(r => r.Business1Navigation)
                .Include(r => r.Business2Navigation)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (relatedBusiness == null)
            {
                return NotFound();
            }

            return View(relatedBusiness);
        }

        // POST: RelatedBusiness/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var relatedBusiness = await _context.RelatedBusiness.SingleOrDefaultAsync(m => m.Id == id);
            _context.RelatedBusiness.Remove(relatedBusiness);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool RelatedBusinessExists(int id)
        {
            return _context.RelatedBusiness.Any(e => e.Id == id);
        }
    }
}
