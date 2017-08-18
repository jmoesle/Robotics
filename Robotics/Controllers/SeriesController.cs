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
    public class SeriesController : Controller
    {
        private readonly RoboticsContext _context;

        public SeriesController(RoboticsContext context)
        {
            _context = context;    
        }

        // GET: Series
        public async Task<IActionResult> Index()
        {
            return View(await _context.Series.ToListAsync());
        }

        // GET: Series/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var series = await _context.Series
                .SingleOrDefaultAsync(m => m.Id == id);
            if (series == null)
            {
                return NotFound();
            }

            return View(series);
        }

        // GET: Series/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Series/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Firstnameauhor1,Lastnameauhor1,Firstnameauhor2,Lastnameauhor2,Firstnameauhor3,Lastnameauhor3,Furtherauthors,Title,Titleseries,Volume,Location,Edition,Publicationdate,Pages")] Series series)
        {
            if (ModelState.IsValid)
            {
                _context.Add(series);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(series);
        }
        // GET: Series/CreateAndConnect
        public IActionResult CreateAndConnect(string tablename, int tableid, int infotype, string currentpath)
        {
            ViewData["tablename"] = tablename;
            ViewData["tableid"] = tableid;
            ViewData["infotype"] = infotype;
            ViewData["currentpath"] = currentpath;

            return View();
        }


        // POST: Series/CreateAndConnect
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAndConnect(string tablename, int tableid, int infotype, string currentpath, [Bind("Id,Firstnameauhor1,Lastnameauhor1,Firstnameauhor2,Lastnameauhor2,Firstnameauhor3,Lastnameauhor3,Furtherauthors,Title,Titleseries,Volume,Location,Edition,Publicationdate,Pages")] Series series)
        {
            int id = new int();

            if (ModelState.IsValid)
            {
                _context.Add(series);

                await _context.SaveChangesAsync();

                List<Series> allentries = new List<Series>();
                allentries = await _context.Series.ToListAsync();
                foreach (Series item in allentries)
                {
                    if (item == series)
                    {
                        id = series.Id;
                    }
                }

                return RedirectToAction("CreateAndConnect", "InfoSourcesInRelations", new { tablename = tablename, tableid = tableid, infotype = infotype, infosourceid = id, currentpath = currentpath });
            }
            return View(series);
        }

        // GET: Series/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var series = await _context.Series.SingleOrDefaultAsync(m => m.Id == id);
            if (series == null)
            {
                return NotFound();
            }
            return View(series);
        }

        // POST: Series/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Firstnameauhor1,Lastnameauhor1,Firstnameauhor2,Lastnameauhor2,Firstnameauhor3,Lastnameauhor3,Furtherauthors,Title,Titleseries,Volume,Location,Edition,Publicationdate,Pages")] Series series)
        {
            if (id != series.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(series);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SeriesExists(series.Id))
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
            return View(series);
        }

        // GET: Series/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var series = await _context.Series
                .SingleOrDefaultAsync(m => m.Id == id);
            if (series == null)
            {
                return NotFound();
            }

            return View(series);
        }

        // POST: Series/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var series = await _context.Series.SingleOrDefaultAsync(m => m.Id == id);
            _context.Series.Remove(series);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool SeriesExists(int id)
        {
            return _context.Series.Any(e => e.Id == id);
        }
    }
}
