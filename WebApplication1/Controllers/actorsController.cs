using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class actorsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public actorsController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> GetActorPhoto(Guid id)
        {
            var actor = await _context.actors.FirstOrDefaultAsync(m => m.Id == id);
            if(actor == null)
            {
                return NotFound();
            }
            var imageData = actor.ActorImage;
            return File(imageData, "image/jpg");
        }

        // GET: actors
        public async Task<IActionResult> Index()
        {
              return _context.actors != null ? 
                          View(await _context.actors.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.actors'  is null.");
        }

        // GET: actors/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.actors == null)
            {
                return NotFound();
            }

            var actors = await _context.actors
                .FirstOrDefaultAsync(m => m.Id == id);
            if (actors == null)
            {
                return NotFound();
            }

            return View(actors);
        }

        // GET: actors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: actors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,gender,age,link,photo")] actors actors, IFormFile ActorImage)
        {
            if (ModelState.IsValid)
            {
                if(ActorImage != null && ActorImage.Length > 0)
                {
                    var memorySteam = new MemoryStream();
                    await ActorImage.CopyToAsync(memorySteam);
                    actors.ActorImage = memorySteam.ToArray();
                }
                _context.Add(actors);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(actors);
        }

        // GET: actors/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.actors == null)
            {
                return NotFound();
            }

            var actors = await _context.actors.FindAsync(id);
            if (actors == null)
            {
                return NotFound();
            }
            return View(actors);
        }

        // POST: actors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,gender,age,link,photo")] actors actors, IFormFile ActorImage)
        {
            if (id != actors.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(actors);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!actorsExists(actors.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(actors);
        }

        // GET: actors/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.actors == null)
            {
                return NotFound();
            }

            var actors = await _context.actors
                .FirstOrDefaultAsync(m => m.Id == id);
            if (actors == null)
            {
                return NotFound();
            }

            return View(actors);
        }

        // POST: actors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.actors == null)
            {
                return Problem("Entity set 'ApplicationDbContext.actors'  is null.");
            }
            var actors = await _context.actors.FindAsync(id);
            if (actors != null)
            {
                _context.actors.Remove(actors);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool actorsExists(Guid id)
        {
          return (_context.actors?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
