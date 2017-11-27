using ConquestionGame.DataAccessLayer;
using ConquestionGame.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConquestionGame.LogicLayer
{
    public class GameController
    {
        ConquestionDBContext db = new ConquestionDBContext();
        RoundController roundCtr = new RoundController();

        public Game CreateGame(Game game)
        {
            if (!ActiveGamesNames().Contains(game.Name))
            {
                game.GameStatus = Game.GameStatusEnum.starting;
                db.Games.Add(game);
                db.SaveChanges();
                return game;
            }
            else
            {
                throw new Exception("Game name is already taken, please select an unique name.");
            }

        }

        public void AddPlayer(Game game, Player player)
        {
            var gameEntity = db.Games.Include("Players").Where(g => g.Name.Equals(game.Name)).FirstOrDefault();
            var playerEntity = db.Players.Where(p => p.Name.Equals(player.Name)).FirstOrDefault();
            if (gameEntity != null)

            {
                if (gameEntity.Players == null)
                {
                    gameEntity.Players = new List<Player>();
                }
                if (!gameEntity.Players.Contains(playerEntity))
                {
                    gameEntity.Players.Add(playerEntity);
                    db.Entry(gameEntity).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }

            }
            else
            {
                throw new Exception();
            }
        }

        public void AddMap(Game game, Map map)
        {
            var gameEntity = db.Games.Where(g => g.Name.Equals(game.Name)).FirstOrDefault();
            var mapEntity = db.Maps.Where(m => m.Name.Equals(map.Name)).FirstOrDefault();
            if (gameEntity != null && mapEntity != null)
            {
                if (gameEntity.Map == null || gameEntity.Map.Name.Equals(""))
                {
                    gameEntity.Map = mapEntity;
                    db.Entry(gameEntity).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }


            }
            else
            {
                throw new Exception();
            }

        }
        public void AddQuestionSet(Game game, QuestionSet questionSet)
        {
            var gameEntity = db.Games.Where(g => g.Name.Equals(game.Name)).FirstOrDefault();
            var questionSetEntity = db.QuestionSets.Where(q => q.Title.Equals(questionSet.Title)).FirstOrDefault();
            if (gameEntity != null && questionSetEntity != null)
            {
                if (gameEntity.QuestionSet == null || gameEntity.QuestionSet.Title.Equals(""))
                {
                    gameEntity.QuestionSet = questionSetEntity;
                    db.Entry(gameEntity).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }


            }
            else
            {
                throw new Exception();
            }

        }

        public Game ChooseGame(string name, bool retrieveAssociations)
        {
            if(retrieveAssociations != true)
            {
                Game chosenGame = db.Games
                .Where(x => x.Name.Equals(name))
                .FirstOrDefault();

                return chosenGame;
            }
            else
            {
                Game chosenGame = db.Games.Include("Players")
                    .Include("QuestionSet.Questions.Answers")
                    .Include("Map")
                    .Include("Rounds.RoundActions.Question.Answers")
                .Where(x => x.Name.Equals(name))
                .FirstOrDefault();
                

                return chosenGame;
            }
            
        }

        public List<Game> ActiveGames()
        {
            List<Game> activeGames = new List<Game>();
            activeGames = db.Games.Where(g => g.GameStatus == Game.GameStatusEnum.starting).ToList();

            return activeGames;
        }

        public List<string> ActiveGamesNames()
        {
            List<Game> activeGames = new List<Game>();
            activeGames = db.Games.Where(g => g.GameStatus == Game.GameStatusEnum.starting).ToList();
            List<string> activeGamesNames = new List<string>();
            foreach(Game g in activeGames)
            {
                activeGamesNames.Add(g.Name);
            }
            return activeGamesNames;
        }

        public bool JoinGame(Game game, Player player)
        {
            var gameEntity = db.Games.Include("Players").Where(g => g.Id == game.Id).FirstOrDefault();
            var playerEntity = db.Players.Where(p => p.Name.Equals(player.Name)).FirstOrDefault();

            if (gameEntity != null && playerEntity != null)
            {
                if (gameEntity.Players.Count < 4)
                {
                    gameEntity.Players.Add(playerEntity);
                    db.Entry(gameEntity).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return true;
                }
                else if(gameEntity.Players.Contains(playerEntity))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public bool LeaveGame(Game game, Player player)
        {
            var gameEntity = db.Games.Include("Players").Where(g => g.Id == game.Id).FirstOrDefault();
            var playerEntity = db.Players.Where(p => p.Name.Equals(player.Name)).FirstOrDefault();

            if (gameEntity != null && playerEntity != null)
            {
                gameEntity.Players.Remove(playerEntity);
                db.Entry(gameEntity).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        // Returns a list of players so we can display their names on the map screen and determine what map nodes they own
        public List<Player> RetrieveAllPlayersByGameId(Game game)
        {
            List<Player> foundPlayers = new List<Player>();
            var gameEntity = db.Games.Include("Players").Where(g => g.Id == game.Id).FirstOrDefault();
            if (gameEntity != null)
            {
                if (gameEntity.Players != null)
                {
                    foundPlayers = gameEntity.Players;
                }
                else
                {
                    throw new Exception();
                }
            }
            else
            {
                throw new Exception();
            }
            return foundPlayers;
        }
        public bool StartGame(Game game, Player player)
        {
            var gameEntity = ChooseGame(game.Name, true);
            var playerEntity = db.Players.Where(p => p.Id == player.Id).FirstOrDefault();


            if (playerEntity.Name.Equals(gameEntity.Players[0].Name) && gameEntity.GameStatus.Equals(Game.GameStatusEnum.starting))
            {
                gameEntity.GameStatus = Game.GameStatusEnum.ongoing;
                roundCtr.CreateStartingRound(gameEntity); 
                db.Entry(gameEntity).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }

        }

        public List<PlayerOrder> getGamePlayerOrder(Game game)
        {
            var playerOrder = db.PlayerOrders.Include("Player").Where(g => g.GameId == game.Id).ToList();
            playerOrder = playerOrder.OrderBy(po => po.Position).ToList();
            return playerOrder;
        }
    }
}
