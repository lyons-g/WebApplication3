using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using WebApplication3.Controllers;
using WebApplication3.Data;
using WebApplication3.Models;
using Xunit;
using Assert = Xunit.Assert;

namespace StatsNow.UnitTests
{
    [TestClass]
    public class GameTests
    {
        [Fact]
        public async void GamesController_Index_NoGames()
        {
            //Arrange
            var mockGameRepository = new MockGameRepository().MockGetGames(new List<Game>());

            var controller = new GamesController(mockGameRepository.Object);

            //act
            var result = await controller.Index();

            //assert

            Assert.IsAssignableFrom<ActionResult<IEnumerable<Game>>>(result);
            mockGameRepository.VerifyGetGames(Times.Once());
        }

        [Fact]
        public async void GamesController_Index_GamesExist()
        {
            //Arrange
            var mockGames = new List<Game>()
            {
                new Game()
                {
                    GameId = 1,
                    FGA = 15
                }
            };
            var mockGameRepository = new MockGameRepository().MockGetGames(mockGames);

            var controller = new GamesController(mockGameRepository.Object);

            //act
            var result = await controller.Index();

            //assert

            Assert.IsAssignableFrom<ActionResult<IEnumerable<Game>>>(result);
            mockGameRepository.VerifyGetGames(Times.Once());
        }
        [Fact]
        public async void GamesController_Delete_Game()
        {
            //Arrange
            var mockGame = new Game()
            {
                GameId = 1
            };

            var mockGameRepository = new MockGameRepository().MockGetGameByID(mockGame);
            var controller = new GamesController(mockGameRepository.Object);

            //act
            var result = await controller.Delete(1);

            //Assert
            Assert.IsAssignableFrom<ActionResult<Game>>(result);
            mockGameRepository.VerifyGetGameByID(Times.Once());
        }

        [Fact]
        public async void GamesController_Game_Delete_Confirmed()
        {
            //Arrange
            var mockGameRepository = new MockGameRepository().MockDeleteGame();

            var controller = new GamesController(mockGameRepository.Object);

            //act
            var result = await controller.DeleteConfirmed(1);

            //assert

            Assert.IsAssignableFrom<ActionResult<Game>>(result);

            // mockGameRepository.VerifyGetGameByID(Times.Once());
            mockGameRepository.VerifyDeleteGame(Times.Once());

        }


        [Fact]
        public async void GamesController_Game_Details()
        {
            //Arrange
            var mockGame = new Game()
            {
                GameId = 1
            };

            var mockGameRepository = new MockGameRepository().MockGetGameByID(mockGame);
            var controller = new GamesController(mockGameRepository.Object);

            //act
            var result = await controller.Details(1);

            //Assert
            Assert.IsAssignableFrom<ActionResult<Game>>(result);
            mockGameRepository.VerifyGetGameByID(Times.Once());

        }

        [Fact]
        public async void GamesController_Edit_Game()
        {
            //Arrange
            var mockGame = new Game()
            {
                GameId = 1
            };

            var mockGameRepository = new MockGameRepository().MockGetGameByID(mockGame);
            var controller = new GamesController(mockGameRepository.Object);

            //act
            var result = await controller.Edit(1);

            //Assert
            Assert.IsAssignableFrom<ActionResult<Game>>(result);
            mockGameRepository.VerifyGetGameByID(Times.Once());
        }
     
      /*  [Fact]
        public async void GameController_Edit_Game_Confirmed()
        {
            //arrange
            var mockGame = new Game()
            {
                GameId = 1,
                FGA = 10
                
            };
            var mockGameRepository = new MockGameRepository().MockEditGame(mockGame);
            var controller = new GamesController(mockGameRepository.Object);

            //act
            var existingGame = await controller.Edit(1);
            mockGame.FGA = 15;
            var updatedData = await controller.Edit(Game);
            
            //Assert
        }*/

    }
}

     /*   public async void GamesController_GamesDetails_ID_Invalid()
        {
            //arrange
            var mockGameRepository = new MockGameRepository().MockGetGameByIDInvalid();
            var controller = new GamesController(mockGameRepository.Object);


            //act
            var result = controller.Details(1);

            //Assert
            Assert.IsNotFound(result);

        }
    }

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
*/



/*   //Arrange
var mockGame = new Game()
{
    GameId = 1
};

var mockGameRepository = new MockGameRepository().MockGetGameByID(mockGame);


var controller = new GamesController(new MockGameRepository().Object, mockGameRepository.Object);;

//Act

var result = controller.Index(1);


//Assert

Assert.IsAssignableFrom<ViewResult>(result);
mockGameRepository.VerifyGatAll(Times.Once());
}
}
}*/
