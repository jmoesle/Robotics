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
    public class IndustriesTransController : Controller
    {
        private readonly RoboticsContext _context;

        public IndustriesTransController(RoboticsContext context)
        {
            _context = context;    
        }

        // GET: IndustriesTrans
        public async Task<IActionResult> Index()
        {
           // var roboticsContext = _context.IndustriesTrans;
            var roboticsContext = _context.IndustriesTrans
                .Include(it => it.IndustriesNavigation)
                    .ThenInclude(ind => ind.SpecificRobotsInRelation)
                        .ThenInclude(sr => sr.SpecificrobotsNavigation)
                            .ThenInclude(sn => sn.Id)
                .Include(i => i.LanguageNavigation)
               //       .AsNoTracking()
               ;
            return View(await roboticsContext.ToListAsync());
        }

        // GET: IndustriesTrans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var industriesTrans = await _context.IndustriesTrans
                .Include(i => i.IndustriesNavigation)
                .Include(i => i.LanguageNavigation)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (industriesTrans == null)
            {
                return NotFound();
            }

            return View(industriesTrans);
        }

        // GET: IndustriesTrans/Create
        public IActionResult Create()
        {
            ViewData["Industries"] = new SelectList(_context.Industries, "Id", "Id");
            ViewData["Language"] = new SelectList(_context.Languages, "Id", "Code");
            return View();
        }

        // POST: IndustriesTrans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Industries,Language")] IndustriesTrans industriesTrans)
        {
            if (ModelState.IsValid)
            {
                _context.Add(industriesTrans);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["Industries"] = new SelectList(_context.Industries, "Id", "Id", industriesTrans.Industries);
            ViewData["Language"] = new SelectList(_context.Languages, "Id", "Code", industriesTrans.Language);
            return View(industriesTrans);
        }

        // GET: IndustriesTrans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var industriesTrans = await _context.IndustriesTrans.SingleOrDefaultAsync(m => m.Id == id);
            if (industriesTrans == null)
            {
                return NotFound();
            }
            ViewData["Industries"] = new SelectList(_context.Industries, "Id", "Id", industriesTrans.Industries);
            ViewData["Language"] = new SelectList(_context.Languages, "Id", "Code", industriesTrans.Language);
            return View(industriesTrans);
        }

        // POST: IndustriesTrans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Industries,Language")] IndustriesTrans industriesTrans)
        {
            if (id != industriesTrans.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(industriesTrans);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IndustriesTransExists(industriesTrans.Id))
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
            ViewData["Industries"] = new SelectList(_context.Industries, "Id", "Id", industriesTrans.Industries);
            ViewData["Language"] = new SelectList(_context.Languages, "Id", "Code", industriesTrans.Language);
            return View(industriesTrans);
        }

        // GET: IndustriesTrans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var industriesTrans = await _context.IndustriesTrans
                .Include(i => i.IndustriesNavigation)
                .Include(i => i.LanguageNavigation)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (industriesTrans == null)
            {
                return NotFound();
            }

            return View(industriesTrans);
        }

        // POST: IndustriesTrans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var industriesTrans = await _context.IndustriesTrans.SingleOrDefaultAsync(m => m.Id == id);
            _context.IndustriesTrans.Remove(industriesTrans);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool IndustriesTransExists(int id)
        {
            return _context.IndustriesTrans.Any(e => e.Id == id);
        }
    }
}
