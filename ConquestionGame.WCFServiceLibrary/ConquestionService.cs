using ConquestionGame.Domain;
using ConquestionGame.LogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConquestionGame.WCFServiceLibrary
{
    public class ConquestionService : IConquestionService
    {
        PlayerController playerCtr = new PlayerController();
        GameController gameCtr = new GameController();
        QuestionSetController quesCtr = new QuestionSetController();
        RoundController roundCtr = new RoundController();

        public Player CreatePlayer(Player player)
        {
            return playerCtr.CreatePlayer(player);
        }

        public void CreateGame(Game game, String questionSet, int noOfRounds)
        {
            gameCtr.CreateGame(game, questionSet, noOfRounds);
        }

        public void AddPlayer(Game game, Player player)
        {
            player = playerCtr.RetrievePlayer(Thread.CurrentPrincipal.Identity.Name); 
            gameCtr.AddPlayer(game, player);
        }

        public List<Game> ActiveGames()
        {
            return gameCtr.ActiveGames();
        }

        public Game ChooseGame(string name, bool retrieveAssociation)
        {
            return gameCtr.ChooseGame(name, retrieveAssociation);
        }

        public List<QuestionSet> RetrieveAllQuestionSets()
        {
            return quesCtr.RetrieveAllQuestionSets();
        }

        public bool ValidateAnswer(Answer answer)
        {
            return roundCtr.ValidateAnswer(answer);
        }

        public bool CheckPlayerAnswers(Game game, Round round)
        {
            return roundCtr.CheckPlayerAnswers(game, round);
        }

        public QuestionSet RetrieveQuestionSet(int id)
        {
            return quesCtr.RetrieveQuestionSet(id);
        }

        public void AddQuestionSet(Game game, QuestionSet questionSet)
        {
            gameCtr.AddQuestionSet(game, questionSet);
        }

        public QuestionSet RetrieveQuestionSetByTitle(string title)
        {
            return quesCtr.RetrieveQuestionSetByTitle(title);
        }

        [PrincipalPermission(SecurityAction.Demand, Role = "Player")]
        public Player RetrievePlayer(string name)
        {
            return playerCtr.RetrievePlayer(name);
        }

        public bool JoinGame(Game game, Player player)
        {
            return gameCtr.JoinGame(game, player);
        }

        public bool LeaveGame(Game game, Player player)
        {
            return gameCtr.LeaveGame(game, player);
        }
       
        public List<Player> RetrieveAllPlayersByGameId(Game game)
        {
            return gameCtr.RetrieveAllPlayersByGameId(game);
        }
              
        public bool StartGame(Game game, Player player)
        {
            return gameCtr.StartGame(game, player);
        }

        public void SubmitAnswer(Round round, PlayerAnswer playerAnswer)
        {
            roundCtr.SubmitAnswer(round, playerAnswer);
        }

        public bool CheckIfAllPlayersAnswered(Game game, Round round)
        {
            return roundCtr.CheckIfAllPlayersAnswered(game, round);
        }

        public void CreateRound(Game game)
        {
            roundCtr.CreateRound(game);
        }

        public Player GetRoundWinner(Round round)
        {
            return roundCtr.GetRoundWinner(round);
        }

        public Question GetRandomQuestion(Game game)
        {
            return roundCtr.GetRandomQuestion(game);
        }

        public Player DetermineGameWinner(Game game)
        {
             return gameCtr.DetermineGameWinner(game);
        }

        public int DetermineNoOfCorrectAnswers(Game game, Player player)
        {
            return gameCtr.DetermineNoOfCorrectAnswers(game, player);
        }

        public bool CheckIfGameIsFinished(Game game)
        {
            return gameCtr.CheckIfGameIsFinished(game);
        }
    }
}
