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
    public class RobotComponentsAndDesignFeaturesController : Controller
    {
        private readonly RoboticsContext _context;

        public RobotComponentsAndDesignFeaturesController(RoboticsContext context)
        {
            _context = context;    
        }

        // GET: RobotComponentsAndDesignFeatures
        public async Task<IActionResult> Index()
        {
            return View(await _context.RobotComponentsAndDesignFeatures.ToListAsync());
        }

        // GET: RobotComponentsAndDesignFeatures/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var robotComponentsAndDesignFeatures = await _context.RobotComponentsAndDesignFeatures
                .SingleOrDefaultAsync(m => m.Id == id);
            if (robotComponentsAndDesignFeatures == null)
            {
                return NotFound();
            }

            return View(robotComponentsAndDesignFeatures);
        }

        // GET: RobotComponentsAndDesignFeatures/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RobotComponentsAndDesignFeatures/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id")] RobotComponentsAndDesignFeatures robotComponentsAndDesignFeatures)
        {
            if (ModelState.IsValid)
            {
                _context.Add(robotComponentsAndDesignFeatures);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(robotComponentsAndDesignFeatures);
        }

        // GET: RobotComponentsAndDesignFeatures/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var robotComponentsAndDesignFeatures = await _context.RobotComponentsAndDesignFeatures.SingleOrDefaultAsync(m => m.Id == id);
            if (robotComponentsAndDesignFeatures == null)
            {
                return NotFound();
            }
            return View(robotComponentsAndDesignFeatures);
        }

        // POST: RobotComponentsAndDesignFeatures/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id")] RobotComponentsAndDesignFeatures robotComponentsAndDesignFeatures)
        {
            if (id != robotComponentsAndDesignFeatures.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(robotComponentsAndDesignFeatures);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RobotComponentsAndDesignFeaturesExists(robotComponentsAndDesignFeatures.Id))
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
            return View(robotComponentsAndDesignFeatures);
        }

        // GET: RobotComponentsAndDesignFeatures/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var robotComponentsAndDesignFeatures = await _context.RobotComponentsAndDesignFeatures
                .SingleOrDefaultAsync(m => m.Id == id);
            if (robotComponentsAndDesignFeatures == null)
            {
                return NotFound();
            }

            return View(robotComponentsAndDesignFeatures);
        }

        // POST: RobotComponentsAndDesignFeatures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var robotComponentsAndDesignFeatures = await _context.RobotComponentsAndDesignFeatures.SingleOrDefaultAsync(m => m.Id == id);
            _context.RobotComponentsAndDesignFeatures.Remove(robotComponentsAndDesignFeatures);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool RobotComponentsAndDesignFeaturesExists(int id)
        {
            return _context.RobotComponentsAndDesignFeatures.Any(e => e.Id == id);
        }
    }
}
