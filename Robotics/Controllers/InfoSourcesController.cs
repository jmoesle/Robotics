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
    public class InfoSourcesController : Controller
    {
        private readonly RoboticsContext _context;

        public InfoSourcesController(RoboticsContext context)
        {
            _context = context;    
        }

        // GET: InfoSources
        public async Task<IActionResult> Index()
        {
            var roboticsContext = _context.InfoSources.Include(i => i.BooksNavigation).Include(i => i.CollectionsNavigation).Include(i => i.JournalsNavigation).Include(i => i.NewspapersNavigation).Include(i => i.OfficialstatementsNavigation).Include(i => i.SeriesNavigation).Include(i => i.UnpublishedNavigation).Include(i => i.WebsitesNavigation);
            return View(await roboticsContext.ToListAsync());
        }

        // GET: InfoSources/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var infoSources = await _context.InfoSources
                .Include(i => i.BooksNavigation)
                .Include(i => i.CollectionsNavigation)
                .Include(i => i.JournalsNavigation)
                .Include(i => i.NewspapersNavigation)
                .Include(i => i.OfficialstatementsNavigation)
                .Include(i => i.SeriesNavigation)
                .Include(i => i.UnpublishedNavigation)
                .Include(i => i.WebsitesNavigation)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (infoSources == null)
            {
                return NotFound();
            }

            return View(infoSources);
        }

        // GET: InfoSources/Create
        public IActionResult Create()
        {
            ViewData["Books"] = new SelectList(_context.Books, "Id", "Firstnameauhor1");
            ViewData["Collections"] = new SelectList(_context.Collections, "Id", "Firstnameauhor1");
            ViewData["Journals"] = new SelectList(_context.Journals, "Id", "Firstnameauhor1");
            ViewData["Newspapers"] = new SelectList(_context.Newspapers, "Id", "Firstnameauhor1");
            ViewData["Officialstatements"] = new SelectList(_context.OfficialStatements, "Id", "Publisher");
            ViewData["Series"] = new SelectList(_context.Series, "Id", "Firstnameauhor1");
            ViewData["Unpublished"] = new SelectList(_context.Unpublished, "Id", "Firstnameauhor1");
            ViewData["Websites"] = new SelectList(_context.Websites, "Id", "Title");
            return View();
        }

        // POST: InfoSources/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Books,Series,Journals,Collections,Unpublished,Newspapers,Officialstatements,Websites")] InfoSources infoSources)
        {
            if (ModelState.IsValid)
            {
                _context.Add(infoSources);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["Books"] = new SelectList(_context.Books, "Id", "Firstnameauhor1", infoSources.Books);
            ViewData["Collections"] = new SelectList(_context.Collections, "Id", "Firstnameauhor1", infoSources.Collections);
            ViewData["Journals"] = new SelectList(_context.Journals, "Id", "Firstnameauhor1", infoSources.Journals);
            ViewData["Newspapers"] = new SelectList(_context.Newspapers, "Id", "Firstnameauhor1", infoSources.Newspapers);
            ViewData["Officialstatements"] = new SelectList(_context.OfficialStatements, "Id", "Publisher", infoSources.Officialstatements);
            ViewData["Series"] = new SelectList(_context.Series, "Id", "Firstnameauhor1", infoSources.Series);
            ViewData["Unpublished"] = new SelectList(_context.Unpublished, "Id", "Firstnameauhor1", infoSources.Unpublished);
            ViewData["Websites"] = new SelectList(_context.Websites, "Id", "Title", infoSources.Websites);
            return View(infoSources);
        }

        // GET: InfoSources/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var infoSources = await _context.InfoSources.SingleOrDefaultAsync(m => m.Id == id);
            if (infoSources == null)
            {
                return NotFound();
            }
            ViewData["Books"] = new SelectList(_context.Books, "Id", "Firstnameauhor1", infoSources.Books);
            ViewData["Collections"] = new SelectList(_context.Collections, "Id", "Firstnameauhor1", infoSources.Collections);
            ViewData["Journals"] = new SelectList(_context.Journals, "Id", "Firstnameauhor1", infoSources.Journals);
            ViewData["Newspapers"] = new SelectList(_context.Newspapers, "Id", "Firstnameauhor1", infoSources.Newspapers);
            ViewData["Officialstatements"] = new SelectList(_context.OfficialStatements, "Id", "Publisher", infoSources.Officialstatements);
            ViewData["Series"] = new SelectList(_context.Series, "Id", "Firstnameauhor1", infoSources.Series);
            ViewData["Unpublished"] = new SelectList(_context.Unpublished, "Id", "Firstnameauhor1", infoSources.Unpublished);
            ViewData["Websites"] = new SelectList(_context.Websites, "Id", "Title", infoSources.Websites);
            return View(infoSources);
        }

        // POST: InfoSources/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Books,Series,Journals,Collections,Unpublished,Newspapers,Officialstatements,Websites")] InfoSources infoSources)
        {
            if (id != infoSources.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(infoSources);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InfoSourcesExists(infoSources.Id))
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
            ViewData["Books"] = new SelectList(_context.Books, "Id", "Firstnameauhor1", infoSources.Books);
            ViewData["Collections"] = new SelectList(_context.Collections, "Id", "Firstnameauhor1", infoSources.Collections);
            ViewData["Journals"] = new SelectList(_context.Journals, "Id", "Firstnameauhor1", infoSources.Journals);
            ViewData["Newspapers"] = new SelectList(_context.Newspapers, "Id", "Firstnameauhor1", infoSources.Newspapers);
            ViewData["Officialstatements"] = new SelectList(_context.OfficialStatements, "Id", "Publisher", infoSources.Officialstatements);
            ViewData["Series"] = new SelectList(_context.Series, "Id", "Firstnameauhor1", infoSources.Series);
            ViewData["Unpublished"] = new SelectList(_context.Unpublished, "Id", "Firstnameauhor1", infoSources.Unpublished);
            ViewData["Websites"] = new SelectList(_context.Websites, "Id", "Title", infoSources.Websites);
            return View(infoSources);
        }

        // GET: InfoSources/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var infoSources = await _context.InfoSources
                .Include(i => i.BooksNavigation)
                .Include(i => i.CollectionsNavigation)
                .Include(i => i.JournalsNavigation)
                .Include(i => i.NewspapersNavigation)
                .Include(i => i.OfficialstatementsNavigation)
                .Include(i => i.SeriesNavigation)
                .Include(i => i.UnpublishedNavigation)
                .Include(i => i.WebsitesNavigation)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (infoSources == null)
            {
                return NotFound();
            }

            return View(infoSources);
        }

        // POST: InfoSources/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var infoSources = await _context.InfoSources.SingleOrDefaultAsync(m => m.Id == id);
            _context.InfoSources.Remove(infoSources);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool InfoSourcesExists(int id)
        {
            return _context.InfoSources.Any(e => e.Id == id);
        }
    }
}
