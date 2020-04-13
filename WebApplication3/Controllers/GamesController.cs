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
        // private readonly ApplicationDbContext _context;

        private readonly IGameRepository gameRepository;

        public GamesController(IGameRepository gameRepository)
        {
            this.gameRepository = gameRepository;
        }

        /*  public GamesController(ApplicationDbContext context)
          {
              _context = context;
          }


          // GET: Games
          public async Task<IActionResult> Index()
          {
              return View(await _context.Games.ToListAsync());
          }*/

        public async Task<ActionResult<IEnumerable<Game>>> Index()
        {
            
            return View(await gameRepository.GetGames());
            
        }



        public async Task<ActionResult<Game>> Details(int Id)
        {
            
            var game = await gameRepository.GetGameByID(Id);
            if(game == null)
            {
                return NotFound();
            }
           
            return View(game);
        }

     

        // GET: Games/Details/5
     /*   public async Task<IActionResult> Details(int? id)
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

    */

        // GET: Games/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Games/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("GameId,HomeTeam,AwayTeam,Venue,HomeScore,AwayScore,Win,FGA,FGM,FGperC,Two_PM,Two_PA,TwoPerC,Three_PA,Three_PM,Three_PC,FTM,FTA,FT_PC,O_Rb,D_Rb,Total_Reb,AST,TO,Steal,Block,Points,Notes")] Game game)
        {
            if (ModelState.IsValid)
            {
                await gameRepository.addGame(game);
                return RedirectToAction(nameof(Index));
            }
            return View(game);
        }



        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.



        // GET: Games/Edit/5
        public async Task<ActionResult<Game>> Edit(int id)
        {
            Game game = await gameRepository.GetGameByID(id);

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
        public async Task<ActionResult<Game>> Edit(int id, [Bind("GameId,HomeTeam,AwayTeam,Venue,HomeScore,AwayScore,Win,FGA,FGM,FGperC,Two_PM,Two_PA,TwoPerC,Three_PA,Three_PM,Three_PC,FTM,FTA,FT_PC,O_Rb,D_Rb,Total_Reb,AST,TO,Steal,Block,Points,Notes")] Game game)
        {
            if (id != game.GameId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await gameRepository.UpdateGame(game);
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
        public async Task<ActionResult<Game>> Delete(int id)
        {
            var game = await gameRepository.GetGameByID(id);
           
                
            if (game == null)
            {
                return NotFound();
            }

            return View(game);
        }

        // POST: Games/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult<Game>> DeleteConfirmed(int id)
        {
            //var game = gameRepository.GetGameByID(id);
            await gameRepository.DeleteGame(id);
            return RedirectToAction(nameof(Index));
        }





        private bool GameExists(int id)
        {
            var game =  gameRepository.GetGameByID(id);
            if (game == null)
            {
                return false;
            }
            else
            {
                return true;
            }
            //context.Set<Game>().ToListAsync();

                //return gameRepository.GetGames().contains(e => e.GameId == id);

        }
        

        public IActionResult Trend()
        {
            return View();
        }

        public async Task<JsonResult> Method()
        {
            var game = await gameRepository.GetGames();

            var FGA = game.Select(g => g.FGM);
                

            var FGM = game.Select(g => g.FGM);
           
            var FGpc = game.Select(g => g.FGperC);

            var win = game.Select(g => g.Win);

            var notes = game.Select(g => g.Notes);

            var Two = game.Select(g => g.Two_PM);
            var TwoA = game.Select(g => g.Two_PA);
           var TwoPC = game.Select(g => g.TwoPerC);

            var Three = game.Select(g => g.Three_PM);
            var ThreeA = game.Select(g => g.Three_PA);
            var ThreePC = game.Select(g => g.Three_PC);

            var FT = game.Select(g => g.FTM);
            var FTA = game.Select(g => g.FTA);
            var FTpc = game.Select(g => g.FT_PC);

            var OR = game.Select(g => g.O_Rb);
            var DR = game.Select(g => g.D_Rb);
            var TR = game.Select(g => g.Total_Reb);

            var AST = game.Select(g => g.AST);
            var TO = game.Select(g => g.TO);
            var ST = game.Select(g => g.Block);
            var Points = game.Select(g => g.Points);


            return new JsonResult(new { myFGA = FGA, myFGM = FGM, myFGpc = FGpc, 
                
                myGame = game, myWin = win, myNotes = notes,
            
                myTwo = Two, myTwoA = TwoA, myTwoPC = TwoPC,
            
                myThree = Three, myThreeA = ThreeA, myThreePC = ThreePC,
            
                myFT = FT, myFTA = FTA, myFTpc = FTpc, 
            
                myOR = OR, myDR = DR, myTR = TR,

                myAST = AST, myTO = TO, myST = ST, myPoints = Points
            
            
            });

        }



        public async Task<JsonResult> DetailsGraph()
        {
            var game = await gameRepository.GetGames();

            var meanFGA = game.Average(g => g.FGperC);
            var meanTwo = game.Average(g => g.TwoPerC);
            var meanThree = game.Average(g => g.Three_PC);
            var meanFT = game.Average(g => g.FT_PC);
            var meanRBS = game.Average(g => g.Total_Reb);
            var meanAst = game.Average(g => g.AST);
            var meanTurnover = game.Average(g => g.TO);
            var meanSteals = game.Average(g => g.Steal);
            var meanBlk = game.Average(g => g.Block);
            var meanPoints = game.Average(g => g.Points);



            return new JsonResult(new {myMeanFGA = meanFGA,  myTwo = meanTwo, myThree = meanThree, 
            
            myFT = meanFT, myRBS = meanRBS, myAST = meanAst, myTO = meanTurnover, mySteals = meanSteals,
            
            myBLK = meanBlk, myPTS = meanPoints
            
            });
        }



    }
}
