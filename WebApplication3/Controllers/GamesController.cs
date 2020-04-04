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
    public class GamesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GamesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Games
        public async Task<IActionResult> Index()
        {
            return View(await _context.Games.ToListAsync());
        }

        // GET: Games/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var game = await _context.Games
                .FirstOrDefaultAsync(m => m.GameId == id);
            if (game == null)
            {
                return NotFound();
            }

            return View(game);
        }

        // GET: Games/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Games/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GameId,HomeTeam,AwayTeam,Venue,HomeScore,AwayScore,Win,FGA,FGM,FGperC,Two_PM,Two_PA,TwoPerC,Three_PA,Three_PM,Three_PC,FTM,FTA,FT_PC,O_Rb,D_Rb,Total_Reb,AST,TO,Steal,Block,Points,Notes")] Game game)
        {
            if (ModelState.IsValid)
            {
                _context.Add(game);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(game);
        }

        // GET: Games/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var game = await _context.Games.FindAsync(id);
            if (game == null)
            {
                return NotFound();
            }
            return View(game);
        }

        // POST: Games/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GameId,HomeTeam,AwayTeam,Venue,HomeScore,AwayScore,Win,FGA,FGM,FGperC,Two_PM,Two_PA,TwoPerC,Three_PA,Three_PM,Three_PC,FTM,FTA,FT_PC,O_Rb,D_Rb,Total_Reb,AST,TO,Steal,Block,Points,Notes")] Game game)
        {
            if (id != game.GameId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(game);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GameExists(game.GameId))
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
            return View(game);
        }

        // GET: Games/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var game = await _context.Games
                .FirstOrDefaultAsync(m => m.GameId == id);
            if (game == null)
            {
                return NotFound();
            }

            return View(game);
        }

        // POST: Games/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var game = await _context.Games.FindAsync(id);
            _context.Games.Remove(game);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GameExists(int id)
        {
            return _context.Games.Any(e => e.GameId == id);
        }

        public async Task<IActionResult> Trend()
        {
            var appDbContext = _context.Games;

            return View(await appDbContext.ToListAsync());
        }

        public async Task<JsonResult> Method()
        {
            var game = await _context.Games.Select(g => g.GameId).Distinct().ToListAsync();

            var FGA = _context.Games.
                Select(g => g.FGA);

            var FGM = _context.Games
                .Select(g => g.FGM);
           
            var FGpc = _context.Games
                .Select(g => g.FGperC);

            var win = _context.Games.Select(g => g.Win);

            var notes = _context.Games.Select(g => g.Notes);

            var Two = _context.Games.Select(g => g.Two_PM);
            var TwoA = _context.Games.Select(g => g.Two_PA);
           var TwoPC = _context.Games.Select(g => g.TwoPerC);

            var Three = _context.Games.Select(g => g.Three_PM);
            var ThreeA = _context.Games.Select(g => g.Three_PA);
            var ThreePC = _context.Games.Select(g => g.Three_PC);

            var FT = _context.Games.Select(g => g.FTM);
            var FTA = _context.Games.Select(g => g.FTA);
            var FTpc = _context.Games.Select(g => g.FT_PC);

            var OR = _context.Games.Select(g => g.O_Rb);
            var DR = _context.Games.Select(g => g.D_Rb);
            var TR = _context.Games.Select(g => g.Total_Reb);

            var AST = _context.Games.Select(g => g.AST);
            var TO = _context.Games.Select(g => g.TO);
            var ST = _context.Games.Select(g => g.Block);
            var Points = _context.Games.Select(g => g.Points);


            return new JsonResult(new { myFGA = FGA, myFGM = FGM, myFGpc = FGpc, 
                
                myGame = game, myWin = win, myNotes = notes,
            
                myTwo = Two, myTwoA = TwoA, myTwoPC = TwoPC,
            
                myThree = Three, myThreeA = ThreeA, myThreePC = ThreePC,
            
                myFT = FT, myFTA = FTA, myFTpc = FTpc, 
            
                myOR = OR, myDR = DR, myTR = TR,

                myAST = AST, myTO = TO, myST = ST, myPoints = Points
            
            
            });

        }
       
     
    }
}
