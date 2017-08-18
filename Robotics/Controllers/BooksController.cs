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
    public class BooksController : Controller
    {
        private readonly RoboticsContext _context;

        public BooksController(RoboticsContext context)
        {
            _context = context;    
        }

        // GET: Books
        public async Task<IActionResult> Index()
        {
            return View(await _context.Books.ToListAsync());
        }

        // GET: Books/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var books = await _context.Books
                .SingleOrDefaultAsync(m => m.Id == id);
            if (books == null)
            {
                return NotFound();
            }

            return View(books);
        }

        // GET: Books/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Firstnameauhor1,Lastnameauhor1,Firstnameauhor2,Lastnameauhor2,Firstnameauhor3,Lastnameauhor3,Furtherauthors,Title,Location,Edition,Publicationdate,Pages")] Books books)
        {
            if (ModelState.IsValid)
            {
                _context.Add(books);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(books);
        }
        // GET: Books/CreateAndConnect
        public IActionResult CreateAndConnect(string tablename, int tableid, int infotype, string currentpath)
        {
            ViewData["tablename"] = tablename;
            ViewData["tableid"] = tableid;
            ViewData["infotype"] = infotype;
            ViewData["currentpath"] = currentpath;

            return View();
        }

        // POST: Books/CreateAndConnect
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAndConnect(string tablename, int tableid, int infotype, string currentpath, [Bind("Id,Firstnameauhor1,Lastnameauhor1,Firstnameauhor2,Lastnameauhor2,Firstnameauhor3,Lastnameauhor3,Furtherauthors,Title,Location,Edition,Publicationdate,Pages")] Books books)
        {
            int id = new int();

            if (ModelState.IsValid)
            {
                _context.Add(books);

                await _context.SaveChangesAsync();

                List<Books> allbooks = new List<Books>();
                allbooks = await _context.Books.ToListAsync();
                foreach (Books item in allbooks)
                {
                    if (item == books)
                    {
                        id = books.Id;
                    }
                }
             
                return RedirectToAction("CreateAndConnect", "InfoSourcesInRelations", new { tablename = tablename, tableid = tableid, infotype = infotype, infosourceid = id, currentpath = currentpath });
            }

            return View(books);
        }

        // GET: Books/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var books = await _context.Books.SingleOrDefaultAsync(m => m.Id == id);
            if (books == null)
            {
                return NotFound();
            }
            return View(books);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Firstnameauhor1,Lastnameauhor1,Firstnameauhor2,Lastnameauhor2,Firstnameauhor3,Lastnameauhor3,Furtherauthors,Title,Location,Edition,Publicationdate,Pages")] Books books)
        {
            if (id != books.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(books);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BooksExists(books.Id))
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
            return View(books);
        }

        // GET: Books/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var books = await _context.Books
                .SingleOrDefaultAsync(m => m.Id == id);
            if (books == null)
            {
                return NotFound();
            }

            return View(books);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var books = await _context.Books.SingleOrDefaultAsync(m => m.Id == id);
            _context.Books.Remove(books);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool BooksExists(int id)
        {
            return _context.Books.Any(e => e.Id == id);
        }
    }
}
