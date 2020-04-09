using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Models;

namespace WebApplication3.Data
{
    public class GameRepository : IGameRepository
    {
        private readonly ApplicationDbContext context;

        public GameRepository(ApplicationDbContext _context)
        {
            context = _context;
        }

        public async Task<List<Game>> GetGames()
        {

            return await context.Set<Game>().ToListAsync();

        }

        /*
                public async Task <IEnumerable<Game>> GetGames()
                {
                    return await context.Games.ToListAsync();
                }
                */


        public async Task<Game> GetGameByID(int id)
        {
            return await context.Games.FindAsync(id);

            // FirstOrDefault(g => g.GameId == gameId);
        }

        /*  public async Task<Game> GetGameByID(int? Id)
          {
              return await context.Games.FindAsync(Id);
          }

          */


        public async Task<Game> addGame(Game game)
        {
            context.Set<Game>().Add(game);
            await context.SaveChangesAsync();
            return game;

        }



        public async Task<Game> DeleteGame(int id)
        {
            var game = await context.Set<Game>().FindAsync(id);
            if (game == null)
            {
                return game;
            }
            context.Set<Game>().Remove(game);
            await context.SaveChangesAsync();
            return game;

        }





        public async Task<Game> UpdateGame(Game game)
        {
            context.Entry(game).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return game;
        }



    }
}
