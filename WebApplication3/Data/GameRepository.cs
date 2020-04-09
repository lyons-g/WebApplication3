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

        public IEnumerable<Game> GetGamesAsync()
        {
            
                return context.Games.ToList();
            
        }

        /*
                public async Task <IEnumerable<Game>> GetGames()
                {
                    return await context.Games.ToListAsync();
                }
                */


        public async Task<Game> GetGameByIDAsync(int? gameId)
        {
            return await context.Games.FindAsync(gameId);
                
               // FirstOrDefault(g => g.GameId == gameId);
        }

      /*  public async Task<Game> GetGameByID(int? Id)
        {
            return await context.Games.FindAsync(Id);
        }

        */


        public async Task addGame (Game game)
        {
            context.Games.Add(game);
           await context.SaveChangesAsync();
             
        }

 

        public async Task DeleteGame(int GameID)
        {
            Game game = await context.Games.FindAsync(GameID);
                context.Games.Remove(game);
        }





        public async Task UpdateGame(Game game)
        {
             context.Entry(game).State = EntityState.Modified;
        }



    
        
        public async Task SaveAsync()
            {
            await context.SaveChangesAsync();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
