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
    public class InfoTypesController : Controller
    {
        private readonly RoboticsContext _context;

        public InfoTypesController(RoboticsContext context)
        {
            _context = context;    
        }

        // GET: InfoTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.InfoTypes.ToListAsync());
        }


        

        // GET: InfoTypes/SelectInfoType
        public async Task<IActionResult> SelectInfoType(string tablename, int tableid, string currentpath)
        {

            ViewData["tablename"] = tablename;
            ViewData["tableid"] = tableid;
            ViewData["currentpath"] = currentpath;
            return View(await _context.InfoTypes.ToListAsync());
        }
        // GET: InfoTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var infoTypes = await _context.InfoTypes
                .SingleOrDefaultAsync(m => m.Id == id);
            if (infoTypes == null)
            {
                return NotFound();
            }

            return View(infoTypes);
        }

        // GET: InfoTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: InfoTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] InfoTypes infoTypes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(infoTypes);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(infoTypes);
        }

        // GET: InfoTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var infoTypes = await _context.InfoTypes.SingleOrDefaultAsync(m => m.Id == id);
            if (infoTypes == null)
            {
                return NotFound();
            }
            return View(infoTypes);
        }

        // POST: InfoTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] InfoTypes infoTypes)
        {
            if (id != infoTypes.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(infoTypes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InfoTypesExists(infoTypes.Id))
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
            return View(infoTypes);
        }

        // GET: InfoTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var infoTypes = await _context.InfoTypes
                .SingleOrDefaultAsync(m => m.Id == id);
            if (infoTypes == null)
            {
                return NotFound();
            }

            return View(infoTypes);
        }

        // POST: InfoTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var infoTypes = await _context.InfoTypes.SingleOrDefaultAsync(m => m.Id == id);
            _context.InfoTypes.Remove(infoTypes);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool InfoTypesExists(int id)
        {
            return _context.InfoTypes.Any(e => e.Id == id);
        }
    }
}
