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
    public class BusinessController : Controller
    {
        private readonly RoboticsContext _context;

        public BusinessController(RoboticsContext context)
        {
            _context = context;    
        }

        // GET: Business
        public async Task<IActionResult> Index()
        {
            return View(await _context.Business.ToListAsync());
        }

        // GET: Business/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Business = await _context.Business
                .SingleOrDefaultAsync(m => m.Id == id);
            if (Business == null)
            {
                return NotFound();
            }

            return View(Business);
        }

        // GET: Business/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Business/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id")] Business Business)
        {
            if (ModelState.IsValid)
            {
                _context.Add(Business);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(Business);
        }

        // GET: Business/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Business = await _context.Business.SingleOrDefaultAsync(m => m.Id == id);
            if (Business == null)
            {
                return NotFound();
            }
            return View(Business);
        }

        // POST: Business/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id")] Business Business)
        {
            if (id != Business.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(Business);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BusinessExists(Business.Id))
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
            return View(Business);
        }

        // GET: Business/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Business = await _context.Business
                .SingleOrDefaultAsync(m => m.Id == id);
            if (Business == null)
            {
                return NotFound();
            }

            return View(Business);
        }

        // POST: Business/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var Business = await _context.Business.SingleOrDefaultAsync(m => m.Id == id);
            _context.Business.Remove(Business);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool BusinessExists(int id)
        {
            return _context.Business.Any(e => e.Id == id);
        }
    }
}
