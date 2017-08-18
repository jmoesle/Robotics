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
    public class RoboticsCompaniesTransController : Controller
    {
        private readonly RoboticsContext _context;

        public RoboticsCompaniesTransController(RoboticsContext context)
        {
            _context = context;    
        }

        // GET: RoboticsCompaniesTrans
        public async Task<IActionResult> Index()
        {
            var roboticsContext = _context.RoboticsCompaniesTrans.Include(r => r.LanguageNavigation).Include(r => r.RoboticscompaniesNavigation);
            return View(await roboticsContext.ToListAsync());
        }

        // GET: RoboticsCompaniesTrans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roboticsCompaniesTrans = await _context.RoboticsCompaniesTrans
                .Include(r => r.LanguageNavigation)
                .Include(r => r.RoboticscompaniesNavigation)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (roboticsCompaniesTrans == null)
            {
                return NotFound();
            }
            ViewData["RoboticsCompany"] = id;
            return View(roboticsCompaniesTrans);
        }

        // GET: RoboticsCompaniesTrans/Create
        public IActionResult Create()
        {
            ViewData["Language"] = new SelectList(_context.Languages, "Id", "Code");
            ViewData["Roboticscompanies"] = new SelectList(_context.RoboticsCompanies, "Id", "Id");
            return View();
        }

        // POST: RoboticsCompaniesTrans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Roboticscompanies,Language")] RoboticsCompaniesTrans roboticsCompaniesTrans)
        {
            if (ModelState.IsValid)
            {
                _context.Add(roboticsCompaniesTrans);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["Language"] = new SelectList(_context.Languages, "Id", "Code", roboticsCompaniesTrans.Language);
            ViewData["Roboticscompanies"] = new SelectList(_context.RoboticsCompanies, "Id", "Id", roboticsCompaniesTrans.Roboticscompanies);
            return View(roboticsCompaniesTrans);
        }

        // GET: RoboticsCompaniesTrans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roboticsCompaniesTrans = await _context.RoboticsCompaniesTrans.SingleOrDefaultAsync(m => m.Id == id);
            if (roboticsCompaniesTrans == null)
            {
                return NotFound();
            }
            ViewData["Language"] = new SelectList(_context.Languages, "Id", "Code", roboticsCompaniesTrans.Language);
            ViewData["Roboticscompanies"] = new SelectList(_context.RoboticsCompanies, "Id", "Id", roboticsCompaniesTrans.Roboticscompanies);
            return View(roboticsCompaniesTrans);
        }

        // POST: RoboticsCompaniesTrans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Roboticscompanies,Language")] RoboticsCompaniesTrans roboticsCompaniesTrans)
        {
            if (id != roboticsCompaniesTrans.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(roboticsCompaniesTrans);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoboticsCompaniesTransExists(roboticsCompaniesTrans.Id))
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
            ViewData["Language"] = new SelectList(_context.Languages, "Id", "Code", roboticsCompaniesTrans.Language);
            ViewData["Roboticscompanies"] = new SelectList(_context.RoboticsCompanies, "Id", "Id", roboticsCompaniesTrans.Roboticscompanies);
            return View(roboticsCompaniesTrans);
        }

        // GET: RoboticsCompaniesTrans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roboticsCompaniesTrans = await _context.RoboticsCompaniesTrans
                .Include(r => r.LanguageNavigation)
                .Include(r => r.RoboticscompaniesNavigation)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (roboticsCompaniesTrans == null)
            {
                return NotFound();
            }

            return View(roboticsCompaniesTrans);
        }

        // POST: RoboticsCompaniesTrans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var roboticsCompaniesTrans = await _context.RoboticsCompaniesTrans.SingleOrDefaultAsync(m => m.Id == id);
            _context.RoboticsCompaniesTrans.Remove(roboticsCompaniesTrans);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool RoboticsCompaniesTransExists(int id)
        {
            return _context.RoboticsCompaniesTrans.Any(e => e.Id == id);
        }
    }
}
