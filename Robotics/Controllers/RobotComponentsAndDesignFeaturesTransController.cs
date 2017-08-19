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
    public class RobotComponentsAndDesignFeaturesTransController : Controller
    {
        private readonly RoboticsContext _context;

        public RobotComponentsAndDesignFeaturesTransController(RoboticsContext context)
        {
            _context = context;    
        }

        // GET: RobotComponentsAndDesignFeaturesTrans
        public async Task<IActionResult> Index()
        {
            var roboticsContext = _context.RobotComponentsAndDesignFeaturesTrans.Include(r => r.LanguageNavigation).Include(r => r.RobotcomponentsanddesignfeaturesNavigation);
            return View(await roboticsContext.ToListAsync());
        }

        // GET: RobotComponentsAndDesignFeaturesTrans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var robotComponentsAndDesignFeaturesTrans = await _context.RobotComponentsAndDesignFeaturesTrans
                .Include(r => r.LanguageNavigation)
                .Include(r => r.RobotcomponentsanddesignfeaturesNavigation)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (robotComponentsAndDesignFeaturesTrans == null)
            {
                return NotFound();
            }

            return View(robotComponentsAndDesignFeaturesTrans);
        }

        // GET: RobotComponentsAndDesignFeaturesTrans/Create
        public IActionResult Create()
        {
            ViewData["Language"] = new SelectList(_context.Languages, "Id", "Code");
            ViewData["Robotcomponentsanddesignfeatures"] = new SelectList(_context.RobotComponentsAndDesignFeatures, "Id", "Id");
            return View();
        }

        // POST: RobotComponentsAndDesignFeaturesTrans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int RobotComponentsAndDesignFeatures, [Bind("Id,Name,Description,Robotcomponentsanddesignfeatures,Language")] RobotComponentsAndDesignFeaturesTrans robotComponentsAndDesignFeaturesTrans)
        {
            if (ModelState.IsValid)
            {
                if (RobotComponentsAndDesignFeatures == 0) { RobotComponentsAndDesignFeatures entry = new RobotComponentsAndDesignFeatures(); _context.Add(entry); robotComponentsAndDesignFeaturesTrans.Robotcomponentsanddesignfeatures = entry.Id; }

                _context.Add(robotComponentsAndDesignFeaturesTrans);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["Language"] = new SelectList(_context.Languages, "Id", "Code", robotComponentsAndDesignFeaturesTrans.Language);
            ViewData["Robotcomponentsanddesignfeatures"] = new SelectList(_context.RobotComponentsAndDesignFeatures, "Id", "Id", robotComponentsAndDesignFeaturesTrans.Robotcomponentsanddesignfeatures);
            return View(robotComponentsAndDesignFeaturesTrans);
        }

        // GET: RobotComponentsAndDesignFeaturesTrans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var robotComponentsAndDesignFeaturesTrans = await _context.RobotComponentsAndDesignFeaturesTrans.SingleOrDefaultAsync(m => m.Id == id);
            if (robotComponentsAndDesignFeaturesTrans == null)
            {
                return NotFound();
            }
            ViewData["Language"] = new SelectList(_context.Languages, "Id", "Code", robotComponentsAndDesignFeaturesTrans.Language);
            ViewData["Robotcomponentsanddesignfeatures"] = new SelectList(_context.RobotComponentsAndDesignFeatures, "Id", "Id", robotComponentsAndDesignFeaturesTrans.Robotcomponentsanddesignfeatures);
            return View(robotComponentsAndDesignFeaturesTrans);
        }

        // POST: RobotComponentsAndDesignFeaturesTrans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Robotcomponentsanddesignfeatures,Language")] RobotComponentsAndDesignFeaturesTrans robotComponentsAndDesignFeaturesTrans)
        {
            if (id != robotComponentsAndDesignFeaturesTrans.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(robotComponentsAndDesignFeaturesTrans);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RobotComponentsAndDesignFeaturesTransExists(robotComponentsAndDesignFeaturesTrans.Id))
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
            ViewData["Language"] = new SelectList(_context.Languages, "Id", "Code", robotComponentsAndDesignFeaturesTrans.Language);
            ViewData["Robotcomponentsanddesignfeatures"] = new SelectList(_context.RobotComponentsAndDesignFeatures, "Id", "Id", robotComponentsAndDesignFeaturesTrans.Robotcomponentsanddesignfeatures);
            return View(robotComponentsAndDesignFeaturesTrans);
        }

        // GET: RobotComponentsAndDesignFeaturesTrans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var robotComponentsAndDesignFeaturesTrans = await _context.RobotComponentsAndDesignFeaturesTrans
                .Include(r => r.LanguageNavigation)
                .Include(r => r.RobotcomponentsanddesignfeaturesNavigation)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (robotComponentsAndDesignFeaturesTrans == null)
            {
                return NotFound();
            }

            return View(robotComponentsAndDesignFeaturesTrans);
        }

        // POST: RobotComponentsAndDesignFeaturesTrans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var robotComponentsAndDesignFeaturesTrans = await _context.RobotComponentsAndDesignFeaturesTrans.SingleOrDefaultAsync(m => m.Id == id);
            _context.RobotComponentsAndDesignFeaturesTrans.Remove(robotComponentsAndDesignFeaturesTrans);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool RobotComponentsAndDesignFeaturesTransExists(int id)
        {
            return _context.RobotComponentsAndDesignFeaturesTrans.Any(e => e.Id == id);
        }
    }
}
