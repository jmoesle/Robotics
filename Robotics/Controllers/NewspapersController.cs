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
        // GET: Newspapers/CreateAndConnect
        public IActionResult CreateAndConnect(string tablename, int tableid, int infotype, string currentpath)
        {
            ViewData["tablename"] = tablename;
            ViewData["tableid"] = tableid;
            ViewData["infotype"] = infotype;
            ViewData["currentpath"] = currentpath;

            return View();
        }

        // POST: Newspapers/CreateAndConnect
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAndConnect(string tablename, int tableid, int infotype, string currentpath, [Bind("Id,Firstnameauhor1,Lastnameauhor1,Firstnameauhor2,Lastnameauhor2,Firstnameauhor3,Lastnameauhor3,Furtherauthors,Title,Newspapername,Issue,Publicationdate,Pages")] Newspapers newspapers)
        {
            int id = new int();
            String[] url = new String[4];

            if (ModelState.IsValid)
            {
                _context.Add(newspapers);

                await _context.SaveChangesAsync();

                List<Newspapers> allentries = new List<Newspapers>();
                allentries = await _context.Newspapers.ToListAsync();
                foreach (Newspapers item in allentries)
                {
                    if (item == newspapers)
                    {
                        id = newspapers.Id;
                    }
                }
                var relation = new InfoSourcesInRelation { Tablename = tablename, Tableid = tableid, Infotype = infotype, Infosourceid = id };
                _context.Add(relation);
                await _context.SaveChangesAsync();
                url = currentpath.Split('/');
                return RedirectToAction(url[3], url[2], new { id = url[4] });
                //return RedirectToAction("CreateAndConnect", "InfoSourcesInRelations", new { tablename = tablename, tableid = tableid, infotype = infotype, infosourceid = id, currentpath = currentpath });
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
