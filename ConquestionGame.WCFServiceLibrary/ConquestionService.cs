using ConquestionGame.Domain;
using ConquestionGame.LogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public void CreateGame(Game game)
        {
            gameCtr.CreateGame(game);
        }

        public void AddPlayer(Game game, Player player)
        {
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

        public Question AskQuestion()
        {
            return quesCtr.AskQuestion();
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
    }
}
