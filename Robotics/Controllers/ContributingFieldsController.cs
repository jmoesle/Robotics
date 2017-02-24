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
    public class ContributingFieldsController : Controller
    {
        private readonly RoboticsContext _context;

        public ContributingFieldsController(RoboticsContext context)
        {
            _context = context;    
        }

        // GET: ContributingFields
        public async Task<IActionResult> Index()
        {
            return View(await _context.ContributingFields.ToListAsync());
        }

        // GET: ContributingFields/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contributingFields = await _context.ContributingFields
                .SingleOrDefaultAsync(m => m.Id == id);
            if (contributingFields == null)
            {
                return NotFound();
            }

            return View(contributingFields);
        }

        // GET: ContributingFields/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ContributingFields/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id")] ContributingFields contributingFields)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contributingFields);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(contributingFields);
        }

        // GET: ContributingFields/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contributingFields = await _context.ContributingFields.SingleOrDefaultAsync(m => m.Id == id);
            if (contributingFields == null)
            {
                return NotFound();
            }
            return View(contributingFields);
        }

        // POST: ContributingFields/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id")] ContributingFields contributingFields)
        {
            if (id != contributingFields.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contributingFields);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContributingFieldsExists(contributingFields.Id))
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
            return View(contributingFields);
        }

        // GET: ContributingFields/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contributingFields = await _context.ContributingFields
                .SingleOrDefaultAsync(m => m.Id == id);
            if (contributingFields == null)
            {
                return NotFound();
            }

            return View(contributingFields);
        }

        // POST: ContributingFields/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contributingFields = await _context.ContributingFields.SingleOrDefaultAsync(m => m.Id == id);
            _context.ContributingFields.Remove(contributingFields);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ContributingFieldsExists(int id)
        {
            return _context.ContributingFields.Any(e => e.Id == id);
        }
    }
}
