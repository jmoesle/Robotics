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
    public class BusinessTransController : Controller
    {
        private readonly RoboticsContext _context;

        public BusinessTransController(RoboticsContext context)
        {
            _context = context;    
        }

        // GET: BusinessTrans
        public async Task<IActionResult> Index()
        {
           // var roboticsContext = _context.BusinessTrans;
            var roboticsContext = _context.BusinessTrans
               .Include(it => it.BusinessNavigation) //BusinessNavigation
              //   .ThenInclude(ind => ind.SpecificRobotsInRelation)
               //       .ThenInclude(sr => sr.SpecificrobotsNavigation.Id)
                     // .ThenInclude(sr => sr.SpeId)
                     // .ThenInclude(sr => sr.s)
               .Include(i => i.LanguageNavigation) // Navigation
                //      .AsNoTracking()
               ;
            ;
            
            return View(await roboticsContext.ToListAsync());
        }

        // GET: BusinessTrans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var BusinessTrans = await _context.BusinessTrans
                .Include(i => i.BusinessNavigation)
                     .ThenInclude(ind => ind.SpecificRobotsInRelation)
                      .ThenInclude(sr => sr.SpecificrobotsNavigation)
                   //  .ThenInclude(sn => sn.Id)
                .Include(i => i.LanguageNavigation)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (BusinessTrans == null)
            {
                return NotFound();
            }

            return View(BusinessTrans);
        }

        // GET: BusinessTrans/Create
        public IActionResult Create()
        {
            ViewData["Business"] = new SelectList(_context.Business, "Id", "Id");
            ViewData["Language"] = new SelectList(_context.Languages, "Id", "Code");
            return View();
        }

        // POST: BusinessTrans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Business,Language")] BusinessTrans BusinessTrans)
        {
            if (ModelState.IsValid)
            {
                _context.Add(BusinessTrans);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["Business"] = new SelectList(_context.Business, "Id", "Id", BusinessTrans.Business);
            ViewData["Language"] = new SelectList(_context.Languages, "Id", "Code", BusinessTrans.Language);
            return View(BusinessTrans);
        }

        // GET: BusinessTrans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var BusinessTrans = await _context.BusinessTrans.SingleOrDefaultAsync(m => m.Id == id);
            if (BusinessTrans == null)
            {
                return NotFound();
            }
            ViewData["Business"] = new SelectList(_context.Business, "Id", "Id", BusinessTrans.Business);
            ViewData["Language"] = new SelectList(_context.Languages, "Id", "Code", BusinessTrans.Language);
            return View(BusinessTrans);
        }

        // POST: BusinessTrans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Business,Language")] BusinessTrans BusinessTrans)
        {
            if (id != BusinessTrans.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(BusinessTrans);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BusinessTransExists(BusinessTrans.Id))
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
            ViewData["Business"] = new SelectList(_context.Business, "Id", "Id", BusinessTrans.Business);
            ViewData["Language"] = new SelectList(_context.Languages, "Id", "Code", BusinessTrans.Language);
            return View(BusinessTrans);
        }

        // GET: BusinessTrans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var BusinessTrans = await _context.BusinessTrans
                .Include(i => i.BusinessNavigation) //Navigation
                .Include(i => i.LanguageNavigation) //Navigation
                .SingleOrDefaultAsync(m => m.Id == id);
            if (BusinessTrans == null)
            {
                return NotFound();
            }

            return View(BusinessTrans);
        }

        // POST: BusinessTrans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var BusinessTrans = await _context.BusinessTrans.SingleOrDefaultAsync(m => m.Id == id);
            _context.BusinessTrans.Remove(BusinessTrans);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool BusinessTransExists(int id)
        {
            return _context.BusinessTrans.Any(e => e.Id == id);
        }
    }
}
