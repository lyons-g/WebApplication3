using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using WebApplication3.Data;
using WebApplication3.Models;
using System.Threading.Tasks;

namespace StatsNow.UnitTests
{
    public class MockGameRepository : Mock<IGameRepository>
    {

       
        
        public MockGameRepository MockGetGames(List<Game> results)
        {
            Setup(x => x.GetGames())
                .Returns(Task.FromResult(results));
            return this;
        }

        public MockGameRepository VerifyGetGames(Times times)
        {
            Verify(x => x.GetGames(), times);
            return this;
        }

        public MockGameRepository MockGetGameByID(Game result)
        {
            Setup(x => x.GetGameByID(It.IsAny<int>()))
                .ReturnsAsync(result);

            return this;
        }

        public MockGameRepository MockDeleteGame()
        {
            Setup(x => x.GetGameByID(It.IsAny<int>()));

            return this;
        }

       

        public MockGameRepository VerifyDeleteGame(Times times)
        {
            Verify(x => x.DeleteGame(It.IsAny<int>()), times);
            return this;
        }

        public MockGameRepository MockEditGame(Game game)
        {
            Setup(x => x.UpdateGame(game));
                //.Returns(Task.FromResults(game));
            return this;
        }
       
        public MockGameRepository VerifyGetGameByID(Times times)
        {
            Verify(x => x.GetGameByID(It.IsAny<int>()), times);
            return this;

        }
    }
}


