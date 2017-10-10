using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OrangeOrchard.Models;

namespace OrangeOrchard.Controllers
{
    public class TreesController : Controller
    {
        private readonly OrangeOrchardContext _context;

        public TreesController(OrangeOrchardContext context)
        {
            _context = context;
        }

        // GET: Trees
        // Requires using Microsoft.AspNetCore.Mvc.Rendering;
        public async Task<IActionResult> Index(string movieGenre, string searchString)
        {
            // Use LINQ to get list of genres.
            IQueryable<string> genreQuery = from m in _context.Tree
                                            orderby m.Genre
                                            select m.Genre;

            var trees = from m in _context.Tree
                        select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                trees = trees.Where(s => s.Name.Contains(searchString));
            }

            if (!String.IsNullOrEmpty(movieGenre))
            {
                trees = trees.Where(x => x.Genre == movieGenre);
            }

            var movieGenreVM = new MovieGenreViewModel();
            movieGenreVM.genres = new SelectList(await genreQuery.Distinct().ToListAsync());
            movieGenreVM.trees = await trees.ToListAsync();

            return View(movieGenreVM);
        }

        [HttpPost]
        public string Index(string searchString, bool notUsed)
        {
            return "From [HttpPost]Index: filter on " + searchString;
        }

        // GET: Trees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tree = await _context.Tree
                .SingleOrDefaultAsync(m => m.ID == id);
            if (tree == null)
            {
                return NotFound();
            }

            return View(tree);
        }

        // GET: Trees/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Trees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Age")] Tree tree)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tree);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tree);
        }

        /* CURRENTLY NOT IN USE/ GET: Trees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var  = await _context.Tree.SingleOrDefaultAsync(m => m.ID == id);
            if ( == null)
            {
                return NotFound();
            }
            return View();
        }

        // POST: Trees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Age,Height,NumOranges")] Tree )
        {
            if (id != .ID)
            {
                return NotFound();
            }
            //verifies data can modify  object
            if (ModelState.IsValid)
            {
                try
                {
                    //saves edited  data to database
                    _context.Update();
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieExists(.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                //returns to index page
                return RedirectToAction(nameof(Index));
            }
            return View();
        }*/

        // GET: Trees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tree = await _context.Tree
                .SingleOrDefaultAsync(m => m.ID == id);
            if (tree == null)
            {
                return NotFound();
            }

            return View(tree);
        }

        // POST: Trees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tree = await _context.Tree.SingleOrDefaultAsync(m => m.ID == id);
            _context.Tree.Remove(tree);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieExists(int id)
        {
            return _context.Tree.Any(e => e.ID == id);
        }
    }
}
