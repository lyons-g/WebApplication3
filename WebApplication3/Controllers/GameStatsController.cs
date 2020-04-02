using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Data;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class GameStatsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GameStatsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: GameStats
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.GameStats.Include(g => g.Game);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: GameStats/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gameStats = await _context.GameStats
                .Include(g => g.Game)
                .FirstOrDefaultAsync(m => m.GamesStatsID == id);
            if (gameStats == null)
            {
                return NotFound();
            }

            return View(gameStats);
        }

        // GET: GameStats/Create
        public IActionResult Create()
        {
            ViewData["GameID"] = new SelectList(_context.Set<Game>(), "GameID", "GameID");
            return View();
        }

        // POST: GameStats/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GamesStatsID,Rebound,Points,Turnovers,GameID")] GameStats gameStats)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gameStats);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GameID"] = new SelectList(_context.Set<Game>(), "GameID", "GameID", gameStats.GameID);
            return View(gameStats);
        }

        // GET: GameStats/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gameStats = await _context.GameStats.FindAsync(id);
            if (gameStats == null)
            {
                return NotFound();
            }
            ViewData["GameID"] = new SelectList(_context.Set<Game>(), "GameID", "GameID", gameStats.GameID);
            return View(gameStats);
        }

        // POST: GameStats/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GamesStatsID,Rebound,Points,Turnovers,GameID")] GameStats gameStats)
        {
            if (id != gameStats.GamesStatsID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gameStats);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GameStatsExists(gameStats.GamesStatsID))
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
            ViewData["GameID"] = new SelectList(_context.Set<Game>(), "GameID", "GameID", gameStats.GameID);
            return View(gameStats);
        }

        // GET: GameStats/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gameStats = await _context.GameStats
                .Include(g => g.Game)
                .FirstOrDefaultAsync(m => m.GamesStatsID == id);
            if (gameStats == null)
            {
                return NotFound();
            }

            return View(gameStats);
        }

        // POST: GameStats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gameStats = await _context.GameStats.FindAsync(id);
            _context.GameStats.Remove(gameStats);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GameStatsExists(int id)
        {
            return _context.GameStats.Any(e => e.GamesStatsID == id);
        }
    }
}
