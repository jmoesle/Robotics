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
    public class OfficialStatementsController : Controller
    {
        private readonly RoboticsContext _context;

        public OfficialStatementsController(RoboticsContext context)
        {
            _context = context;    
        }

        // GET: OfficialStatements
        public async Task<IActionResult> Index()
        {
            return View(await _context.OfficialStatements.ToListAsync());
        }

        // GET: OfficialStatements/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var officialStatements = await _context.OfficialStatements
                .SingleOrDefaultAsync(m => m.Id == id);
            if (officialStatements == null)
            {
                return NotFound();
            }

            return View(officialStatements);
        }

        // GET: OfficialStatements/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OfficialStatements/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Publisher,Title,Publication,Issue,Location,Publicationdate,Pages")] OfficialStatements officialStatements)
        {
            if (ModelState.IsValid)
            {
                _context.Add(officialStatements);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(officialStatements);
        }

        // GET: OfficialStatements/CreateAndConnect
        public IActionResult CreateAndConnect(string tablename, int tableid, int infotype, string currentpath)
        {
            ViewData["tablename"] = tablename;
            ViewData["tableid"] = tableid;
            ViewData["infotype"] = infotype;
            ViewData["currentpath"] = currentpath;

            return View();
        }

        // POST: OfficialStatements/CreateAndConnect
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAndConnect(string tablename, int tableid, int infotype, string currentpath, [Bind("Id,Publisher,Title,Publication,Issue,Location,Publicationdate,Pages")] OfficialStatements officialStatements)
        {
            int id = new int();

            if (ModelState.IsValid)
            {
                _context.Add(officialStatements);

                await _context.SaveChangesAsync();

                List<OfficialStatements> allentries = new List<OfficialStatements>();
                allentries = await _context.OfficialStatements.ToListAsync();
                foreach (OfficialStatements item in allentries)
                {
                    if (item == officialStatements)
                    {
                        id = officialStatements.Id;
                    }
                }

                return RedirectToAction("CreateAndConnect", "InfoSourcesInRelations", new { tablename = tablename, tableid = tableid, infotype = infotype, infosourceid = id, currentpath = currentpath });
            }
            return View(officialStatements);
        }

        // GET: OfficialStatements/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var officialStatements = await _context.OfficialStatements.SingleOrDefaultAsync(m => m.Id == id);
            if (officialStatements == null)
            {
                return NotFound();
            }
            return View(officialStatements);
        }

        // POST: OfficialStatements/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Publisher,Title,Publication,Issue,Location,Publicationdate,Pages")] OfficialStatements officialStatements)
        {
            if (id != officialStatements.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(officialStatements);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OfficialStatementsExists(officialStatements.Id))
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
            return View(officialStatements);
        }

        // GET: OfficialStatements/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var officialStatements = await _context.OfficialStatements
                .SingleOrDefaultAsync(m => m.Id == id);
            if (officialStatements == null)
            {
                return NotFound();
            }

            return View(officialStatements);
        }

        // POST: OfficialStatements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var officialStatements = await _context.OfficialStatements.SingleOrDefaultAsync(m => m.Id == id);
            _context.OfficialStatements.Remove(officialStatements);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool OfficialStatementsExists(int id)
        {
            return _context.OfficialStatements.Any(e => e.Id == id);
        }
    }
}
