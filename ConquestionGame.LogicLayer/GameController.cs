﻿using ConquestionGame.DataAccessLayer;
using ConquestionGame.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConquestionGame.LogicLayer
{
    public class GameController
    {
        RoundController roundCtr = new RoundController();

        public Game CreateGame(Game game)
        {
            using (var db = new ConquestionDBContext())
            {
                if (!ActiveGamesNames().Contains(game.Name))
                {
                    game.GameStatus = Game.GameStatusEnum.starting;
                    var qs = db.QuestionSets.Where(q => q.Id == game.QuestionSet.Id).FirstOrDefault();
                    game.QuestionSet = qs;
                    db.Games.Add(game);
                    db.SaveChanges();

                    var askedQuestionEntity = db.AskedQuestions.Where(q => q.GameId == game.Id).ToList();
                    var allQuestionsEntity = db.Questions.Include("Answers").Where(q => q.QuestionSetId == game.QuestionSet.Id).ToList();
                    if (askedQuestionEntity.Count == 0)
                    {
                        foreach (Question q in allQuestionsEntity)
                        {
                            // askedQuestionEntity.Add(new AskedQuestion { GameId = game.Id, QuestionId = q.Id, HasBeenAsked = false });
                            db.AskedQuestions.Add(new AskedQuestion { GameId = game.Id, QuestionId = q.Id, HasBeenAsked = false });
                            db.SaveChanges();

                        }

                    }

                    return game;
                }
                else
                {
                    throw new Exception("Game name is already taken, please select an unique name.");
                }
            }

        }

        public Game CreateGame(Game game, String questionSet, int noOfRounds)
        {

            using (var db = new ConquestionDBContext())
            {
                if (!ActiveGamesNames().Contains(game.Name))
                {
                    game.GameStatus = Game.GameStatusEnum.starting;
                    game.QuestionSet = db.QuestionSets.Include("Questions").Include("Questions.Answers").Where(q => q.Title == questionSet).FirstOrDefault();
                    game.NoOfRounds = noOfRounds;
                    db.Games.Add(game);
                    db.SaveChanges();

                    var askedQuestionEntity = db.AskedQuestions.Where(q => q.GameId == game.Id).ToList();
                    var allQuestionsEntity = db.Questions.Include("Answers").Where(q => q.QuestionSetId == game.QuestionSet.Id).ToList();
                    if (askedQuestionEntity.Count == 0)
                    {
                        foreach (Question q in allQuestionsEntity)
                        {
                            db.AskedQuestions.Add(new AskedQuestion { GameId = game.Id, QuestionId = q.Id, HasBeenAsked = false });
                            db.SaveChanges();

                        }

                    }



                    return game;
                }
                else
                {
                    throw new Exception("Game name is already taken, please select an unique name.");
                }
            }
        }

        public void AddPlayer(Game game, Player player)
        {
            using (var db = new ConquestionDBContext())
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
        }


        public void AddQuestionSet(Game game, QuestionSet questionSet)
        {
            using (var db = new ConquestionDBContext())
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

        }

        public Game RetrieveGame(string name, bool retrieveAssociations)
        {
            using (var db = new ConquestionDBContext())
            {
                if (retrieveAssociations != true)
                {
                    Game chosenGame = db.Games.AsNoTracking()
                    .Where(x => x.Name.Equals(name))
                    .FirstOrDefault();

                    return chosenGame;
                }
                else
                {
                    Game chosenGame = db.Games.AsNoTracking()
                        .Include("Players")
                        .Include("QuestionSet.Questions.Answers")
                        .Include("Rounds.Question.Answers")
                        .Include("Rounds.PlayerAnswers")
                    .Where(x => x.Name.Equals(name))
                    .FirstOrDefault();


                    return chosenGame;
                }
            }

        }

        public List<Game> RetrieveActiveGames()
        {
            using (var db = new ConquestionDBContext())
            {
                List<Game> activeGames = new List<Game>();
                activeGames = db.Games.Where(g => g.GameStatus == Game.GameStatusEnum.starting).ToList();

                return activeGames;
            }
        }

        public List<string> ActiveGamesNames()
        {
            using (var db = new ConquestionDBContext())
            {
                List<Game> activeGames = new List<Game>();
                activeGames = db.Games.Where(g => g.GameStatus == Game.GameStatusEnum.starting).ToList();
                List<string> activeGamesNames = new List<string>();
                foreach (Game g in activeGames)
                {
                    activeGamesNames.Add(g.Name);
                }
                return activeGamesNames;
            }
        }

        public bool JoinGame(Game game, Player player)
        {

            using (var db = new ConquestionDBContext())
            {
                bool success = false;
                var playerEntity = db.Players.Where(p => p.Name.Equals(player.Name)).FirstOrDefault();
                using (var transaction = db.Database.BeginTransaction(System.Data.IsolationLevel.Serializable))
                {
                    try
                    {
                        var gameEntity = db.Games.Include("Players").Where(g => g.Id == game.Id).FirstOrDefault();
                        if (gameEntity != null && playerEntity != null)
                        {
                            if (gameEntity.Players.Count < 4)
                            {

                                gameEntity.Players.Add(playerEntity);
                                db.Entry(gameEntity).State = System.Data.Entity.EntityState.Modified;
                                db.SaveChanges();
                                //System.Threading.Thread.Sleep(5000);
                                transaction.Commit();
                                success = true;
                            }
                            else if (gameEntity.Players.Contains(playerEntity))
                            {
                                success = true;
                            }
                        }
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                    }
                }
                return success;
            }
        }

        public bool LeaveGame(Game game, Player player)
        {
            using (var db = new ConquestionDBContext())
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
        }

        // Returns a list of players so we can display their names on the map screen and determine what map nodes they own
        public List<Player> RetrieveAllPlayersByGameId(Game game)
        {
            using (var db = new ConquestionDBContext())
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
        }
        public bool StartGame(Game game, Player player)
        {
            using (var db = new ConquestionDBContext())
            {
                var gameEntity = db.Games.Include("Players").Where(g => g.Id == game.Id).FirstOrDefault();
                var playerEntity = db.Players.Where(p => p.Name.Equals(player.Name)).FirstOrDefault();

                if (playerEntity.Name.Equals(gameEntity.Players[0].Name) && gameEntity.GameStatus.Equals(Game.GameStatusEnum.starting))
                {
                    gameEntity.GameStatus = Game.GameStatusEnum.ongoing;
                    gameEntity.Rounds = new List<Round>();
                    Round firstRound = new Round { RoundNo = 1, QuestionStartTime = DateTime.Now };
                    var randQuestion = roundCtr.RetrieveRandomQuestion(gameEntity);
                    var questionEntity = db.Questions.Include("Answers").Where(r => r.Id == randQuestion.Id).FirstOrDefault();
                    firstRound.Question = questionEntity;
                    gameEntity.Rounds.Add(firstRound);
                    db.Entry(gameEntity).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                } 
            }

        }

        public Player DetermineGameWinner(Game game)
        {
            using (var db = new ConquestionDBContext())
            {
                var roundsEntity = db.Games.Include("Rounds").Include("Players").Where(g => g.Id == game.Id).FirstOrDefault().Rounds.ToList();

                try
                {
                    var winner = roundsEntity.Where(r => r.RoundWinner != null).GroupBy(r => r.RoundWinner).OrderByDescending(r => r.Count()).ToList()
                    .First().Key;
                    return winner;
                }
                catch (InvalidOperationException)
                {
                    return null;
                } 
            }
        }

        public int DetermineNoOfCorrectAnswers(Game game, Player player)
        {
            using (var db = new ConquestionDBContext())
            {
                int noOfCorrectAnswers = 0;
                int correctAnswers = 0;

                var playerAnwsersEntity = db.PlayerAnswers.Include("Round.Game").Include("Player").Include("AnswerGiven").ToList();

                correctAnswers = 0;
                foreach (PlayerAnswer pA in playerAnwsersEntity)
                {
                    if (pA.Player.Id == player.Id && pA.AnswerGiven.IsValid == true && pA.Round.Game.Id == game.Id)
                    {
                        correctAnswers++;
                    }
                }
                noOfCorrectAnswers = correctAnswers;

                return noOfCorrectAnswers; 
            }
        }

        public bool CheckIfGameIsFinished(Game game)
        {
            using (var db = new ConquestionDBContext())
            {
                bool finished = false;
                Game gameEntity = db.Games.Include("Rounds").Include("Players").AsNoTracking().Where(g => g.Id == game.Id).FirstOrDefault();
                int elapsedSeconds = (int)(DateTime.Now - gameEntity.Rounds.Last().QuestionStartTime).TotalSeconds;
                if(gameEntity.Rounds.Count() == gameEntity.NoOfRounds)
                {
                    if(roundCtr.CheckIfAllPlayersAnswered(gameEntity, gameEntity.Rounds.Last()) || elapsedSeconds == 30)
                    {
                        gameEntity.GameStatus = Game.GameStatusEnum.finished;
                        db.Entry(gameEntity).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                        finished = true;
                    }

                }
                return finished; 
            }
        }

    }
}
