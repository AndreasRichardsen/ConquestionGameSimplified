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
        MapController mapCtr = new MapController();
        RoundController rndActCtr = new RoundController();
        NodeController nodeCtr = new NodeController();
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

        public List<Map> RetrieveAllMaps()
        {
            return mapCtr.RetrieveAllMaps();
        }

        public Question AskQuestion()
        {
            return quesCtr.AskQuestion();
        }

        public bool ValidateAnswer(Answer answer)
        {
            return roundCtr.ValidateAnswer(answer);
        }

        public bool CheckPlayerAnswers(Game game, RoundAction roundAction)
        {
            return roundCtr.CheckPlayerAnswers(game, roundAction);
        }

        public Map ChooseMap(string name)
        {
            return mapCtr.ChooseMap(name);
        }

        public QuestionSet RetrieveQuestionSet(int id)
        {
            return quesCtr.RetrieveQuestionSet(id);
        }

        public void AddMap(Game game, Map map)
        {

            gameCtr.AddMap(game, map);
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


        public bool CheckIfNodeIsFree(Game game, int mapNodeId)
        {
            return nodeCtr.CheckIfNodeIsFree(game, mapNodeId);
        }

        public List<Player> RetrieveAllPlayersByGameId(Game game)
        {
            return gameCtr.RetrieveAllPlayersByGameId(game);
        }

        public Player ReturnNodeOwner(Game game, int mapNodeId)
        {
            return nodeCtr.ReturnNodeOwner(game, mapNodeId);
        }

        public bool StartGame(Game game, Player player)
        {
            return gameCtr.StartGame(game, player);
        }

        public void SubmitAnswer(RoundAction roundAction, PlayerAnswer playerAnswer)
        {
            roundCtr.SubmitAnswer(roundAction, playerAnswer);
        }

        public bool CheckIfAllPlayersAnswered(Game game, RoundAction roundAction)
        {
            return roundCtr.CheckIfAllPlayersAnswered(game, roundAction);
        }

        public List<Player> GetPlayerOrder(Game game, RoundAction roundAction)
        {
            return roundCtr.GetPlayerOrder(game, roundAction);
        }

        public List<PlayerOrder> getGamePlayerOrder(Game game)
        {
            return gameCtr.getGamePlayerOrder(game);
        }

        public void SetMapStartTime(RoundAction roundAction)
        {
            roundCtr.SetMapStartTime(roundAction);
        }

        public Player CheckPlayerTurn(RoundAction roundAction, Game game)
        {
            return roundCtr.CheckPlayerTurn(roundAction, game);
        }

        public bool SelectMapNode(RoundAction roundAction, Game game, Player player, int MapNodeIndex)
        {
            return roundCtr.SelectMapNode(roundAction, game, player, MapNodeIndex);
        }
    }
}
