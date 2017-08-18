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
    public class InfoSourcesInRelationsController : Controller
    {
        private readonly RoboticsContext _context;

        public InfoSourcesInRelationsController(RoboticsContext context)
        {
            _context = context;    
        }

        // GET: InfoSourcesInRelations
        public async Task<IActionResult> Index()
        {
            var roboticsContext = _context.InfoSourcesInRelation.Include(i => i.InfotypesNavigation);
            return View(await roboticsContext.ToListAsync());
        }

        // GET: InfoSourcesInRelations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var infoSourcesInRelation = await _context.InfoSourcesInRelation
                .Include(i => i.InfotypesNavigation)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (infoSourcesInRelation == null)
            {
                return NotFound();
            }

            return View(infoSourcesInRelation);
        }

        // GET: InfoSourcesInRelations/Create
        public IActionResult Create()
        {
            ViewData["Infotypes"] = new SelectList(_context.InfoTypes, "Id", "Name");
            return View();
        }

        // POST: InfoSourcesInRelations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Tablename,Tableid,Infotype,Infosourceid")] InfoSourcesInRelation infoSourcesInRelation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(infoSourcesInRelation);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["Infotypes"] = new SelectList(_context.InfoTypes, "Id", "Name", infoSourcesInRelation.Infotype);
            return View(infoSourcesInRelation);
        }

        // GET: InfoSourcesInRelations/CreateAndConnect
        public IActionResult CreateAndConnect(string tablename, int tableid, int infotype, int infosourceid, string currentpath)
        {
            ViewData["Infotypes"] = new SelectList(_context.InfoTypes, "Id", "Name");
            ViewData["tablename"] = tablename;
            ViewData["tableid"] = tableid;
            ViewData["infotype"] = infotype;
            ViewData["infosourceid"] = infosourceid;
            ViewData["currentpath"] = currentpath;
            return View();
        }

        // POST: InfoSourcesInRelations/CreateAndConnect
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAndConnect(string currentpath, [Bind("Id,Tablename,Tableid,Infotype,Infosourceid")] InfoSourcesInRelation infoSourcesInRelation)
        {
            String[] url = new String[4];
            if (ModelState.IsValid)
            {
                _context.Add(infoSourcesInRelation);
                await _context.SaveChangesAsync();
                url = currentpath.Split('/');

                return RedirectToAction(url[3], url[2] , new { id = url[4]});
            }
            ViewData["Infotypes"] = new SelectList(_context.InfoTypes, "Id", "Name", infoSourcesInRelation.Infotype);
            return View(infoSourcesInRelation);
        }
        
        // GET: InfoSourcesInRelations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var infoSourcesInRelation = await _context.InfoSourcesInRelation.SingleOrDefaultAsync(m => m.Id == id);
            if (infoSourcesInRelation == null)
            {
                return NotFound();
            }
            ViewData["Infotypes"] = new SelectList(_context.InfoTypes, "Id", "Name", infoSourcesInRelation.Infotype);
            return View(infoSourcesInRelation);
        }

        // POST: InfoSourcesInRelations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Tablename,Tableid,Infotype,Infosourceid")] InfoSourcesInRelation infoSourcesInRelation)
        {
            if (id != infoSourcesInRelation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(infoSourcesInRelation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InfoSourcesInRelationExists(infoSourcesInRelation.Id))
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
            ViewData["Infostypes"] = new SelectList(_context.InfoTypes, "Id", "Name", infoSourcesInRelation.Infotype);
            return View(infoSourcesInRelation);
        }

        // GET: InfoSourcesInRelations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var infoSourcesInRelation = await _context.InfoSourcesInRelation
                .Include(i => i.InfotypesNavigation)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (infoSourcesInRelation == null)
            {
                return NotFound();
            }

            return View(infoSourcesInRelation);
        }

        // POST: InfoSourcesInRelations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var infoSourcesInRelation = await _context.InfoSourcesInRelation.SingleOrDefaultAsync(m => m.Id == id);
            _context.InfoSourcesInRelation.Remove(infoSourcesInRelation);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool InfoSourcesInRelationExists(int id)
        {
            return _context.InfoSourcesInRelation.Any(e => e.Id == id);
        }
    }
}
