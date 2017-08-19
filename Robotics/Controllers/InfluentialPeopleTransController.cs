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
    public class InfluentialPeopleTransController : Controller
    {
        private readonly RoboticsContext _context;

        public InfluentialPeopleTransController(RoboticsContext context)
        {
            _context = context;    
        }

        // GET: InfluentialPeopleTrans
        public async Task<IActionResult> Index()
        {
            var roboticsContext = _context.InfluentialPeopleTrans.Include(i => i.InfluentialpeopleNavigation).Include(i => i.LanguageNavigation);
            return View(await roboticsContext.ToListAsync());
        }

        // GET: InfluentialPeopleTrans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var influentialPeopleTrans = await _context.InfluentialPeopleTrans
                .Include(i => i.InfluentialpeopleNavigation)
                .Include(i => i.LanguageNavigation)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (influentialPeopleTrans == null)
            {
                return NotFound();
            }

            return View(influentialPeopleTrans);
        }

        // GET: InfluentialPeopleTrans/Create
        public IActionResult Create()
        {
            ViewData["Influentialpeople"] = new SelectList(_context.InfluentialPeople, "Id", "Id");
            ViewData["Language"] = new SelectList(_context.Languages, "Id", "Code");
            return View();
        }

        // POST: InfluentialPeopleTrans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int InfluentialPeople, [Bind("Id,Prefix,Firstname,Lastname,Description,Influentialpeople,Language")] InfluentialPeopleTrans influentialPeopleTrans)
        {
            if (ModelState.IsValid)
            {
                if (InfluentialPeople == 0) { InfluentialPeople entry = new InfluentialPeople(); _context.Add(entry); influentialPeopleTrans.Influentialpeople = entry.Id; }

                _context.Add(influentialPeopleTrans);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["Influentialpeople"] = new SelectList(_context.InfluentialPeople, "Id", "Id", influentialPeopleTrans.Influentialpeople);
            ViewData["Language"] = new SelectList(_context.Languages, "Id", "Code", influentialPeopleTrans.Language);
            return View(influentialPeopleTrans);
        }

        // GET: InfluentialPeopleTrans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var influentialPeopleTrans = await _context.InfluentialPeopleTrans.SingleOrDefaultAsync(m => m.Id == id);
            if (influentialPeopleTrans == null)
            {
                return NotFound();
            }
            ViewData["Influentialpeople"] = new SelectList(_context.InfluentialPeople, "Id", "Id", influentialPeopleTrans.Influentialpeople);
            ViewData["Language"] = new SelectList(_context.Languages, "Id", "Code", influentialPeopleTrans.Language);
            return View(influentialPeopleTrans);
        }

        // POST: InfluentialPeopleTrans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Prefix,Firstname,Lastname,Description,Influentialpeople,Language")] InfluentialPeopleTrans influentialPeopleTrans)
        {
            if (id != influentialPeopleTrans.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(influentialPeopleTrans);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InfluentialPeopleTransExists(influentialPeopleTrans.Id))
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
            ViewData["Influentialpeople"] = new SelectList(_context.InfluentialPeople, "Id", "Id", influentialPeopleTrans.Influentialpeople);
            ViewData["Language"] = new SelectList(_context.Languages, "Id", "Code", influentialPeopleTrans.Language);
            return View(influentialPeopleTrans);
        }

        // GET: InfluentialPeopleTrans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var influentialPeopleTrans = await _context.InfluentialPeopleTrans
                .Include(i => i.InfluentialpeopleNavigation)
                .Include(i => i.LanguageNavigation)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (influentialPeopleTrans == null)
            {
                return NotFound();
            }

            return View(influentialPeopleTrans);
        }

        // POST: InfluentialPeopleTrans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var influentialPeopleTrans = await _context.InfluentialPeopleTrans.SingleOrDefaultAsync(m => m.Id == id);
            _context.InfluentialPeopleTrans.Remove(influentialPeopleTrans);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool InfluentialPeopleTransExists(int id)
        {
            return _context.InfluentialPeopleTrans.Any(e => e.Id == id);
        }
    }
}
