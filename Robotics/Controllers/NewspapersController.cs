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
    public class NewspapersController : Controller
    {
        private readonly RoboticsContext _context;

        public NewspapersController(RoboticsContext context)
        {
            _context = context;    
        }

        // GET: Newspapers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Newspapers.ToListAsync());
        }

        // GET: Newspapers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var newspapers = await _context.Newspapers
                .SingleOrDefaultAsync(m => m.Id == id);
            if (newspapers == null)
            {
                return NotFound();
            }

            return View(newspapers);
        }

        // GET: Newspapers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Newspapers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Firstnameauhor1,Lastnameauhor1,Firstnameauhor2,Lastnameauhor2,Firstnameauhor3,Lastnameauhor3,Furtherauthors,Title,Newspapername,Issue,Publicationdate,Pages")] Newspapers newspapers)
        {
            if (ModelState.IsValid)
            {
                _context.Add(newspapers);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(newspapers);
        }

        // GET: Newspapers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var newspapers = await _context.Newspapers.SingleOrDefaultAsync(m => m.Id == id);
            if (newspapers == null)
            {
                return NotFound();
            }
            return View(newspapers);
        }

        // POST: Newspapers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Firstnameauhor1,Lastnameauhor1,Firstnameauhor2,Lastnameauhor2,Firstnameauhor3,Lastnameauhor3,Furtherauthors,Title,Newspapername,Issue,Publicationdate,Pages")] Newspapers newspapers)
        {
            if (id != newspapers.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(newspapers);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NewspapersExists(newspapers.Id))
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
            return View(newspapers);
        }

        // GET: Newspapers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var newspapers = await _context.Newspapers
                .SingleOrDefaultAsync(m => m.Id == id);
            if (newspapers == null)
            {
                return NotFound();
            }

            return View(newspapers);
        }

        // POST: Newspapers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var newspapers = await _context.Newspapers.SingleOrDefaultAsync(m => m.Id == id);
            _context.Newspapers.Remove(newspapers);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool NewspapersExists(int id)
        {
            return _context.Newspapers.Any(e => e.Id == id);
        }
    }
}
