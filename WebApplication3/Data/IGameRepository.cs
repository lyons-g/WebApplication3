using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Models;

namespace WebApplication3.Data
{
    public interface IGameRepository : IDisposable
    {
        IEnumerable<Game> GetGames();
        Game GetGameByID(int GameId);
        void addGame(Game game);
        void DeleteGame(int GameId);
        void UpdateGame(Game game);
        void Save();

    }
}
