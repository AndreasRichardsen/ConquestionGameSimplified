using ConquestionGame.DataAccessLayer;
using ConquestionGame.Domain;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConquestionGame.LogicLayer.Tests
{

    [TestFixture]
    public class GameControllerTests
    {
        GameController ctr = new GameController();
        ConquestionDBContext db = new ConquestionDBContext();

        [Test]
        public void AddAPlayerToAGame()
        {
            //Arrange
            Game game = new Game { Id = 1, Name = "TestGame", Players = new List<Player>() };
            //var game = db.Games.Where(g => g.Name.Equals("TestGame")).FirstOrDefault();
            Player player = new Player { Id = 1, Name = "TestPlayer", Games = new List<Game>() };

            //Act
            ctr.AddPlayer(game, player);

            //Assert
            var dbGame = db.Games.Include("Players").Where(g => g.Id == 1).FirstOrDefault();
            var dbPlayer = db.Players.Where(p => p.Id == 1).FirstOrDefault();
            Assert.Contains(dbPlayer, dbGame.Players);
        }

        [Test]
        public void AddPlayerToNullGame_ShouldThrowException()
        {
            //Arrange
            Game game = new Game { Id = 4, Name = "FailTest", Players = new List<Player>() }; ;
            Player player = new Player { Id = 1, Name = "TestPlayer", Games = new List<Game>() };

            //Act
            //ctr.AddPlayer(game, player);

            //Assert
            Assert.Throws<Exception>(() => ctr.AddPlayer(game, player));
        }


        [Test]
        public void ChooseGame()
        {
            //Arrange
            Game chosenGame = new Game();

            //Act
            chosenGame = ctr.ChooseGame("TestGame", false);

            //Assert
            Assert.AreEqual(1, chosenGame.Id);
        }

        [Test]
        public void ChooseGame_NullGame()
        {
            //Arrange
            Game chosenGame = new Game();

            //Act
            chosenGame = ctr.ChooseGame("FailTest", false);

            //Assert
            Assert.Null(chosenGame);
        }

        [Test]
        public void ActiveGames()
        {
            //Arrange
            List<Game> activeGame = new List<Game>();

            //Act
            activeGame = ctr.ActiveGames();

            //Assert
            Assert.AreEqual(1, activeGame.Count);
        }

        [Test]
        public void createGame_NameIsUniqueToActiveList()
        {
            //Arrange 
            Game game = new Game { Name = "TestGame2" };

            //Act
            ctr.CreateGame(game);

            //Assert
            var gameEntity = db.Games.Where(g => g.Name.Equals(game.Name)).FirstOrDefault();
            Assert.AreEqual(game.Name, gameEntity.Name);
            db.Games.Remove(gameEntity);
            db.SaveChanges();
        }

        [Test]
        public void createGame_NameIsNotUniqueToActiveList()
        {
            //Arrange
            Game game = new Game { Name = "TestGame" };
            string msg = "";

            //Act
            try
            {
                ctr.CreateGame(game);
                Assert.Fail();
            }
            catch (Exception e)
            {
                msg = e.Message;
            }

            //Assert
            Assert.Throws<Exception>(() => ctr.CreateGame(game));
            Assert.AreEqual("Game name is already taken, please select an unique name.", msg);
        }

        [Test]
        public void JoinGame_SuccessfulJoin()
        {
            //Arrange
            Game game = new Game { Id = 1, Name = "TestGame" };
            Player player = new Player { Id = 2, Name = "TestPlayer2" };

            //Act
            ctr.LeaveGame(game, player);
            bool success = ctr.JoinGame(game, player);

            //Arrange
            Assert.IsTrue(success);
        }

        [Test]
        public void JoinGame_InvalidPlayer_Join_Failure()
        {
            //Arrange
            Game game = new Game { Id = 1, Name = "TestGame" };
            Player player = new Player { Id = 999, Name = "NotARealPlayer" };

            //Act
            bool success = ctr.JoinGame(game, player);

            //Arrange
            Assert.IsFalse(success);
        }

        [Test]
        public void LeaveGame_SuccessfulLeave()
        {
            //Arrange
            Game game = new Game { Id = 1, Name = "TestGame" };
            Player player = new Player { Id = 2, Name = "TestPlayer2" };

            //Act
            ctr.JoinGame(game, player);
            bool success = ctr.LeaveGame(game, player);

            //Arrange
            Assert.IsTrue(success);
        }

        [Test]
        public void LeaveGame_Null_Player_Failure()
        {
            //Arrange
            Game game = new Game { Id = 1, Name = "TestGame" };
            Player player = new Player { Id = 999, Name = "NotARealPlayer" };

            //Act
            bool sucess = ctr.LeaveGame(game, player);

            //Assert
            Assert.IsFalse(sucess);
        }

        //[Test]
        //public void NotARealTest()
        //{
        //    QuestionSet qs = db.InitializeData();
        //    db.QuestionSets.Add(qs);
        //    db.SaveChanges();
        //}
    }
}

