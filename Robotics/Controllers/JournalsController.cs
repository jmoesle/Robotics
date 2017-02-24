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
    public class JournalsController : Controller
    {
        private readonly RoboticsContext _context;

        public JournalsController(RoboticsContext context)
        {
            _context = context;    
        }

        // GET: Journals
        public async Task<IActionResult> Index()
        {
            return View(await _context.Journals.ToListAsync());
        }

        // GET: Journals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var journals = await _context.Journals
                .SingleOrDefaultAsync(m => m.Id == id);
            if (journals == null)
            {
                return NotFound();
            }

            return View(journals);
        }

        // GET: Journals/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Journals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Firstnameauhor1,Lastnameauhor1,Firstnameauhor2,Lastnameauhor2,Firstnameauhor3,Lastnameauhor3,Furtherauthors,Title,Journalname,Volume,Publicationdate,Issue,Pages,Url")] Journals journals)
        {
            if (ModelState.IsValid)
            {
                _context.Add(journals);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(journals);
        }

        // GET: Journals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var journals = await _context.Journals.SingleOrDefaultAsync(m => m.Id == id);
            if (journals == null)
            {
                return NotFound();
            }
            return View(journals);
        }

        // POST: Journals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Firstnameauhor1,Lastnameauhor1,Firstnameauhor2,Lastnameauhor2,Firstnameauhor3,Lastnameauhor3,Furtherauthors,Title,Journalname,Volume,Publicationdate,Issue,Pages,Url")] Journals journals)
        {
            if (id != journals.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(journals);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JournalsExists(journals.Id))
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
            return View(journals);
        }

        // GET: Journals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var journals = await _context.Journals
                .SingleOrDefaultAsync(m => m.Id == id);
            if (journals == null)
            {
                return NotFound();
            }

            return View(journals);
        }

        // POST: Journals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var journals = await _context.Journals.SingleOrDefaultAsync(m => m.Id == id);
            _context.Journals.Remove(journals);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool JournalsExists(int id)
        {
            return _context.Journals.Any(e => e.Id == id);
        }
    }
}
