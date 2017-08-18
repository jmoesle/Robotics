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
    public class AddressesInRelationsController : Controller
    {
        private readonly RoboticsContext _context;

        public AddressesInRelationsController(RoboticsContext context)
        {
            _context = context;    
        }

        // GET: AddressesInRelations
        public async Task<IActionResult> Index()
        {
            var roboticsContext = _context.AddressesInRelation.Include(a => a.AddressesNavigation);
            return View(await roboticsContext.ToListAsync());
        }

        // GET: AddressesInRelations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var addressesInRelation = await _context.AddressesInRelation
                .Include(a => a.AddressesNavigation)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (addressesInRelation == null)
            {
                return NotFound();
            }

            return View(addressesInRelation);
        }


        // GET: AddressesInRelations/Create
        public IActionResult Create()
        {
            ViewData["Addresses"] = new SelectList(_context.Addresses, "Id", "Id");
            return View();
        }

        // POST: AddressesInRelations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Tablename,Tableid,Addresses")] AddressesInRelation addressesInRelation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(addressesInRelation);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["Addresses"] = new SelectList(_context.Addresses, "Id", "Id", addressesInRelation.Addresses);
            return View(addressesInRelation);
        }

        // GET: AddressesInRelations/CreateAndConnect
        public IActionResult CreateAndConnect(string tablename, int tableid, int addressesid, string currentpath)
        {
            ViewData["Addresses"] = new SelectList(_context.Addresses, "Id", "Id");
            ViewData["tablename"] = tablename;
            ViewData["tableid"] = tableid;
            ViewData["addressesid"] = addressesid;
            ViewData["currentpath"] = currentpath;


            return View();
        }

        // POST: AddressesInRelations/CreateAndConnect
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAndConnect(string currentpath, [Bind("Id,Tablename,Tableid,Addresses")] AddressesInRelation addressesInRelation)
        {
            String[] url = new String[4];
            if (ModelState.IsValid)
            {
                _context.Add(addressesInRelation);
                await _context.SaveChangesAsync();
                url = currentpath.Split('/');

                return RedirectToAction(url[3], url[2], new { id = url[4] });
            }
            ViewData["Addresses"] = new SelectList(_context.Addresses, "Id", "Id", addressesInRelation.Addresses);
            return View(addressesInRelation);
        }

        

        // GET: AddressesInRelations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var addressesInRelation = await _context.AddressesInRelation.SingleOrDefaultAsync(m => m.Id == id);
            if (addressesInRelation == null)
            {
                return NotFound();
            }
            ViewData["Addresses"] = new SelectList(_context.Addresses, "Id", "Id", addressesInRelation.Addresses);
            return View(addressesInRelation);
        }

        // POST: AddressesInRelations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Tablename,Tableid,Addresses")] AddressesInRelation addressesInRelation)
        {
            if (id != addressesInRelation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(addressesInRelation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AddressesInRelationExists(addressesInRelation.Id))
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
            ViewData["Addresses"] = new SelectList(_context.Addresses, "Id", "Id", addressesInRelation.Addresses);
            return View(addressesInRelation);
        }

        // GET: AddressesInRelations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var addressesInRelation = await _context.AddressesInRelation
                .Include(a => a.AddressesNavigation)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (addressesInRelation == null)
            {
                return NotFound();
            }

            return View(addressesInRelation);
        }

        // POST: AddressesInRelations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var addressesInRelation = await _context.AddressesInRelation.SingleOrDefaultAsync(m => m.Id == id);
            _context.AddressesInRelation.Remove(addressesInRelation);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool AddressesInRelationExists(int id)
        {
            return _context.AddressesInRelation.Any(e => e.Id == id);
        }
    }
}
