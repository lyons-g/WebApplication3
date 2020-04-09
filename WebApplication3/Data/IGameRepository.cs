using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Models;

namespace WebApplication3.Data
{
    public interface IGameRepository : IDisposable
    {
        IEnumerable<Game> GetGamesAsync();
       Task <Game> GetGameByIDAsync(int ? gameId);
        Task addGame(Game game);
        Task DeleteGame(int GameId);
        Task UpdateGame(Game game);
        Task SaveAsync();

    }
}
