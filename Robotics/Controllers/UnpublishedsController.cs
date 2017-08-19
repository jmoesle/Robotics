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
    public class UnpublishedsController : Controller
    {
        private readonly RoboticsContext _context;

        public UnpublishedsController(RoboticsContext context)
        {
            _context = context;    
        }

        // GET: Unpublisheds
        public async Task<IActionResult> Index()
        {
            return View(await _context.Unpublished.ToListAsync());
        }

        // GET: Unpublisheds/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unpublished = await _context.Unpublished
                .SingleOrDefaultAsync(m => m.Id == id);
            if (unpublished == null)
            {
                return NotFound();
            }

            return View(unpublished);
        }

        // GET: Unpublisheds/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Unpublisheds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Firstnameauhor1,Lastnameauhor1,Firstnameauhor2,Lastnameauhor2,Firstnameauhor3,Lastnameauhor3,Furtherauthors,Title,Type,Schoollocation,Edition,Publicationdate,Pages")] Unpublished unpublished)
        {
            if (ModelState.IsValid)
            {
                _context.Add(unpublished);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(unpublished);
        }
        // GET: Unpublisheds/CreateAndConnect
        public IActionResult CreateAndConnect(string tablename, int tableid, int infotype, string currentpath)
        {
            ViewData["tablename"] = tablename;
            ViewData["tableid"] = tableid;
            ViewData["infotype"] = infotype;
            ViewData["currentpath"] = currentpath;

            return View();
        }
        // POST: Unpublisheds/CreateAndConnect
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAndConnect(string tablename, int tableid, int infotype, string currentpath, [Bind("Id,Firstnameauhor1,Lastnameauhor1,Firstnameauhor2,Lastnameauhor2,Firstnameauhor3,Lastnameauhor3,Furtherauthors,Title,Type,Schoollocation,Edition,Publicationdate,Pages")] Unpublished unpublished)
        {
            int id = new int();
            String[] url = new String[4];

            if (ModelState.IsValid)
            {
                _context.Add(unpublished);

                await _context.SaveChangesAsync();

                List<Unpublished> allentries = new List<Unpublished>();
                allentries = await _context.Unpublished.ToListAsync();
                foreach (Unpublished item in allentries)
                {
                    if (item == unpublished)
                    {
                        id = unpublished.Id;
                    }
                }
                var relation = new InfoSourcesInRelation { Tablename = tablename, Tableid = tableid, Infotype = infotype, Infosourceid = id };
                _context.Add(relation);
                await _context.SaveChangesAsync();
                url = currentpath.Split('/');
                return RedirectToAction(url[3], url[2], new { id = url[4] });
                //return RedirectToAction("CreateAndConnect", "InfoSourcesInRelations", new { tablename = tablename, tableid = tableid, infotype = infotype, infosourceid = id, currentpath = currentpath });
            }
            return View(unpublished);
        }

        // GET: Unpublisheds/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unpublished = await _context.Unpublished.SingleOrDefaultAsync(m => m.Id == id);
            if (unpublished == null)
            {
                return NotFound();
            }
            return View(unpublished);
        }

        // POST: Unpublisheds/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Firstnameauhor1,Lastnameauhor1,Firstnameauhor2,Lastnameauhor2,Firstnameauhor3,Lastnameauhor3,Furtherauthors,Title,Type,Schoollocation,Edition,Publicationdate,Pages")] Unpublished unpublished)
        {
            if (id != unpublished.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(unpublished);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UnpublishedExists(unpublished.Id))
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
            return View(unpublished);
        }

        // GET: Unpublisheds/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unpublished = await _context.Unpublished
                .SingleOrDefaultAsync(m => m.Id == id);
            if (unpublished == null)
            {
                return NotFound();
            }

            return View(unpublished);
        }

        // POST: Unpublisheds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var unpublished = await _context.Unpublished.SingleOrDefaultAsync(m => m.Id == id);
            _context.Unpublished.Remove(unpublished);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool UnpublishedExists(int id)
        {
            return _context.Unpublished.Any(e => e.Id == id);
        }
    }
}
