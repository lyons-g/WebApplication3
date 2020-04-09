using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Models;

namespace WebApplication3.Data
{
    public interface IGameRepository 
    {
        Task <List<Game>> GetGames();
        Task <Game> GetGameByID(int Id);
        Task <Game> addGame(Game game);
        Task <Game> DeleteGame(int id);
        Task <Game> UpdateGame(Game game);
        

    }
}
