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

            Assert.IsAssignableFrom<ActionResult<IEnumerable<Game>>> (result);
            mockGameRepository.VerifyGetGames(Times.Once());
        }
    }

}
   
            
            
            
            
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
