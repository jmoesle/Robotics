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
    public class BranchesTransController : Controller
    {
        private readonly RoboticsContext _context;

        public BranchesTransController(RoboticsContext context)
        {
            _context = context;    
        }

        // GET: BranchesTrans
        public async Task<IActionResult> Index()
        {
           // var roboticsContext = _context.BranchesTrans;
            var roboticsContext = _context.BranchesTrans
               .Include(it => it.BranchesNavigation) //BranchesNavigation
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

        // GET: BranchesTrans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var BranchesTrans = await _context.BranchesTrans
                .Include(i => i.BranchesNavigation)
                     .ThenInclude(ind => ind.SpecificRobotsInRelation)
                      .ThenInclude(sr => sr.SpecificrobotsNavigation)
                   //  .ThenInclude(sn => sn.Id)
                .Include(i => i.LanguageNavigation)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (BranchesTrans == null)
            {
                return NotFound();
            }

            return View(BranchesTrans);
        }

        // GET: BranchesTrans/Create
        public IActionResult Create(string currentpath)
        {
            ViewData["currentpath"] = currentpath;
            ViewData["Branches"] = new SelectList(_context.Branches, "Id", "Id");
            ViewData["Language"] = new SelectList(_context.Languages, "Id", "Code");
            return View();
        }

        // POST: BranchesTrans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int Branches, string currentpath, [Bind("Id,Name,Description,Branches,Language")] BranchesTrans BranchesTrans)
        {
            if (ModelState.IsValid)
            {
                if(Branches == 0) { Branches branch = new Branches(); _context.Add(branch); BranchesTrans.Branches = branch.Id; }
                _context.Add(BranchesTrans);
                await _context.SaveChangesAsync();
                String[] url = new String[4];
                url = currentpath.Split('/');
                return RedirectToAction("Index", url[2] );
            }
            ViewData["Branches"] = new SelectList(_context.Branches, "Id", "Id", BranchesTrans.Branches);
            ViewData["Language"] = new SelectList(_context.Languages, "Id", "Code", BranchesTrans.Language);
            return View(BranchesTrans);
        }

        // GET: BranchesTrans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var BranchesTrans = await _context.BranchesTrans.SingleOrDefaultAsync(m => m.Id == id);
            if (BranchesTrans == null)
            {
                return NotFound();
            }
            ViewData["Branches"] = new SelectList(_context.Branches, "Id", "Id", BranchesTrans.Branches);
            ViewData["Language"] = new SelectList(_context.Languages, "Id", "Code", BranchesTrans.Language);
            return View(BranchesTrans);
        }

        // POST: BranchesTrans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Branches,Language")] BranchesTrans BranchesTrans)
        {
            if (id != BranchesTrans.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(BranchesTrans);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BranchesTransExists(BranchesTrans.Id))
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
            ViewData["Branches"] = new SelectList(_context.Branches, "Id", "Id", BranchesTrans.Branches);
            ViewData["Language"] = new SelectList(_context.Languages, "Id", "Code", BranchesTrans.Language);
            return View(BranchesTrans);
        }

        // GET: BranchesTrans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var BranchesTrans = await _context.BranchesTrans
                .Include(i => i.BranchesNavigation) //Navigation
                .Include(i => i.LanguageNavigation) //Navigation
                .SingleOrDefaultAsync(m => m.Id == id);
            if (BranchesTrans == null)
            {
                return NotFound();
            }

            return View(BranchesTrans);
        }

        // POST: BranchesTrans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var BranchesTrans = await _context.BranchesTrans.SingleOrDefaultAsync(m => m.Id == id);
            _context.BranchesTrans.Remove(BranchesTrans);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool BranchesTransExists(int id)
        {
            return _context.BranchesTrans.Any(e => e.Id == id);
        }
    }
}
