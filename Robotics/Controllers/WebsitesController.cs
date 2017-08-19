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
    public class WebsitesController : Controller
    {
        private readonly RoboticsContext _context;

        public WebsitesController(RoboticsContext context)
        {
            _context = context;    
        }

        // GET: Websites
        public async Task<IActionResult> Index()
        {
            return View(await _context.Websites.ToListAsync());
        }

        // GET: Websites/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var websites = await _context.Websites
                .SingleOrDefaultAsync(m => m.Id == id);
            if (websites == null)
            {
                return NotFound();
            }

            return View(websites);
        }

        // GET: Websites/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Websites/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Firstname,Lastname,Organization,Title,Publicationdate,Calldate,Url")] Websites websites)
        {
            if (ModelState.IsValid)
            {
                _context.Add(websites);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(websites);
        }
        // GET: Websites/CreateAndConnect
        public IActionResult CreateAndConnect(string tablename, int tableid, int infotype, string currentpath)
        {
            ViewData["tablename"] = tablename;
            ViewData["tableid"] = tableid;
            ViewData["infotype"] = infotype;
            ViewData["currentpath"] = currentpath;

            return View();
        }

        // POST: Websites/CreateAndConnect
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAndConnect(string tablename, int tableid, int infotype, string currentpath, [Bind("Id,Firstname,Lastname,Organization,Title,Publicationdate,Calldate,Url")] Websites websites)
        {
            int id = new int();
            String[] url = new String[4];

            if (ModelState.IsValid)
            {
                _context.Add(websites);
            
                await _context.SaveChangesAsync();

                List<Websites> allentries = new List<Websites>();
                allentries = await _context.Websites.ToListAsync();
                foreach (Websites item in allentries)
                {
                    if (item == websites)
                    {
                        id = websites.Id;
                    }
                }
                var relation = new InfoSourcesInRelation { Tablename = tablename, Tableid = tableid, Infotype = infotype, Infosourceid = id };
                _context.Add(relation);
                await _context.SaveChangesAsync();
                url = currentpath.Split('/');
                return RedirectToAction(url[3], url[2], new { id = url[4] });
                //return RedirectToAction("CreateAndConnect", "InfoSourcesInRelations", new { tablename = tablename, tableid = tableid, infotype = infotype, infosourceid = id, currentpath = currentpath });
            }
            return View(websites);
        }

        // GET: Websites/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var websites = await _context.Websites.SingleOrDefaultAsync(m => m.Id == id);
            if (websites == null)
            {
                return NotFound();
            }
            return View(websites);
        }

        // POST: Websites/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Firstname,Lastname,Organization,Title,Publicationdate,Calldate,Url")] Websites websites)
        {
            if (id != websites.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(websites);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WebsitesExists(websites.Id))
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
            return View(websites);
        }

        // GET: Websites/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var websites = await _context.Websites
                .SingleOrDefaultAsync(m => m.Id == id);
            if (websites == null)
            {
                return NotFound();
            }

            return View(websites);
        }

        // POST: Websites/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var websites = await _context.Websites.SingleOrDefaultAsync(m => m.Id == id);
            _context.Websites.Remove(websites);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool WebsitesExists(int id)
        {
            return _context.Websites.Any(e => e.Id == id);
        }
    }
}
