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
    public class AddressesController : Controller
    {
        private readonly RoboticsContext _context;

        public AddressesController(RoboticsContext context)
        {
            _context = context;    
        }

        // GET: Addresses
        public async Task<IActionResult> Index()
        {
            var roboticsContext = _context.Addresses.Include(a => a.CountryNavigation);
            return View(await roboticsContext.ToListAsync());
        }

        public async Task<IActionResult> Overview()
        {
            var roboticsContext = _context.Addresses.Include(a => a.CountryNavigation);
            return View(await roboticsContext.ToListAsync());
        }

        // GET: Addresses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var addresses = await _context.Addresses
                .Include(a => a.CountryNavigation)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (addresses == null)
            {
                return NotFound();
            }

            return View(addresses);
        }

        // GET: Addresses/Create
        public IActionResult Create()
        {
            ViewData["Country"] = new SelectList(_context.Countries, "Id", "Code");
            return View();
        }

        // POST: Addresses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Firstname,Lastname,Company,Street,Streetnumber,Zip,State,Country,Latitude,Longitude,Label")] Addresses addresses)
        {
            if (ModelState.IsValid)
            {
                _context.Add(addresses);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["Country"] = new SelectList(_context.Countries, "Id", "Code", addresses.Country);
            return View(addresses);
        }

        // GET: Addresses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var addresses = await _context.Addresses.SingleOrDefaultAsync(m => m.Id == id);
            if (addresses == null)
            {
                return NotFound();
            }
            ViewData["Country"] = new SelectList(_context.Countries, "Id", "Code", addresses.Country);
            return View(addresses);
        }

        // POST: Addresses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Firstname,Lastname,Company,Street,Streetnumber,Zip,State,Country,Latitude,Longitude,Label")] Addresses addresses)
        {
            if (id != addresses.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(addresses);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AddressesExists(addresses.Id))
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
            ViewData["Country"] = new SelectList(_context.Countries, "Id", "Code", addresses.Country);
            return View(addresses);
        }

        // GET: Addresses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var addresses = await _context.Addresses
                .Include(a => a.CountryNavigation)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (addresses == null)
            {
                return NotFound();
            }

            return View(addresses);
        }

        // POST: Addresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var addresses = await _context.Addresses.SingleOrDefaultAsync(m => m.Id == id);
            _context.Addresses.Remove(addresses);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool AddressesExists(int id)
        {
            return _context.Addresses.Any(e => e.Id == id);
        }
    }
}
