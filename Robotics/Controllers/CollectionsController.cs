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
    public class CollectionsController : Controller
    {
        private readonly RoboticsContext _context;

        public CollectionsController(RoboticsContext context)
        {
            _context = context;    
        }

        // GET: Collections
        public async Task<IActionResult> Index()
        {
            return View(await _context.Collections.ToListAsync());
        }

        // GET: Collections/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var collections = await _context.Collections
                .SingleOrDefaultAsync(m => m.Id == id);
            if (collections == null)
            {
                return NotFound();
            }

            return View(collections);
        }

        // GET: Collections/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Collections/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Firstnameauhor1,Lastnameauhor1,Firstnameauhor2,Lastnameauhor2,Firstnameauhor3,Lastnameauhor3,Furtherauthors,Publisher,Title,Location,Edition,Publicationdate,Pages")] Collections collections)
        {
            if (ModelState.IsValid)
            {
                _context.Add(collections);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(collections);
        }

        // GET: Collections/CreateAndConnect
        public IActionResult CreateAndConnect(string tablename, int tableid, int infotype, string currentpath)
        {
            ViewData["tablename"] = tablename;
            ViewData["tableid"] = tableid;
            ViewData["infotype"] = infotype;
            ViewData["currentpath"] = currentpath;

            return View();
        }

        // POST: Collections/CreateAndConnect
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAndConnect(string tablename, int tableid, int infotype, string currentpath, [Bind("Id,Firstnameauhor1,Lastnameauhor1,Firstnameauhor2,Lastnameauhor2,Firstnameauhor3,Lastnameauhor3,Furtherauthors,Publisher,Title,Location,Edition,Publicationdate,Pages")] Collections collections)
        {
            int id = new int();

            if (ModelState.IsValid)
            {
                _context.Add(collections);

                await _context.SaveChangesAsync();

                List<Collections> allentries = new List<Collections>();
                allentries = await _context.Collections.ToListAsync();
                foreach (Collections item in allentries)
                {
                    if (item == collections)
                    {
                        id = collections.Id;
                    }
                }

                return RedirectToAction("CreateAndConnect", "InfoSourcesInRelations", new { tablename = tablename, tableid = tableid, infotype = infotype, infosourceid = id, currentpath = currentpath });
            }
            return View(collections);
        }

        // GET: Collections/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var collections = await _context.Collections.SingleOrDefaultAsync(m => m.Id == id);
            if (collections == null)
            {
                return NotFound();
            }
            return View(collections);
        }

        // POST: Collections/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Firstnameauhor1,Lastnameauhor1,Firstnameauhor2,Lastnameauhor2,Firstnameauhor3,Lastnameauhor3,Furtherauthors,Publisher,Title,Location,Edition,Publicationdate,Pages")] Collections collections)
        {
            if (id != collections.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(collections);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CollectionsExists(collections.Id))
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
            return View(collections);
        }

        // GET: Collections/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var collections = await _context.Collections
                .SingleOrDefaultAsync(m => m.Id == id);
            if (collections == null)
            {
                return NotFound();
            }

            return View(collections);
        }

        // POST: Collections/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var collections = await _context.Collections.SingleOrDefaultAsync(m => m.Id == id);
            _context.Collections.Remove(collections);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool CollectionsExists(int id)
        {
            return _context.Collections.Any(e => e.Id == id);
        }
    }
}
