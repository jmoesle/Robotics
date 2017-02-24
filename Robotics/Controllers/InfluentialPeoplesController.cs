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
    public class InfluentialPeoplesController : Controller
    {
        private readonly RoboticsContext _context;

        public InfluentialPeoplesController(RoboticsContext context)
        {
            _context = context;    
        }

        // GET: InfluentialPeoples
        public async Task<IActionResult> Index()
        {
            return View(await _context.InfluentialPeople.ToListAsync());
        }

        // GET: InfluentialPeoples/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var influentialPeople = await _context.InfluentialPeople
                .SingleOrDefaultAsync(m => m.Id == id);
            if (influentialPeople == null)
            {
                return NotFound();
            }

            return View(influentialPeople);
        }

        // GET: InfluentialPeoples/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: InfluentialPeoples/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id")] InfluentialPeople influentialPeople)
        {
            if (ModelState.IsValid)
            {
                _context.Add(influentialPeople);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(influentialPeople);
        }

        // GET: InfluentialPeoples/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var influentialPeople = await _context.InfluentialPeople.SingleOrDefaultAsync(m => m.Id == id);
            if (influentialPeople == null)
            {
                return NotFound();
            }
            return View(influentialPeople);
        }

        // POST: InfluentialPeoples/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id")] InfluentialPeople influentialPeople)
        {
            if (id != influentialPeople.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(influentialPeople);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InfluentialPeopleExists(influentialPeople.Id))
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
            return View(influentialPeople);
        }

        // GET: InfluentialPeoples/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var influentialPeople = await _context.InfluentialPeople
                .SingleOrDefaultAsync(m => m.Id == id);
            if (influentialPeople == null)
            {
                return NotFound();
            }

            return View(influentialPeople);
        }

        // POST: InfluentialPeoples/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var influentialPeople = await _context.InfluentialPeople.SingleOrDefaultAsync(m => m.Id == id);
            _context.InfluentialPeople.Remove(influentialPeople);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool InfluentialPeopleExists(int id)
        {
            return _context.InfluentialPeople.Any(e => e.Id == id);
        }
    }
}
