using ConquestionGame.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ConquestionGame.WCFServiceLibrary
{
    [ServiceContract]
    public interface IConquestionService
    {

        //Player Controller
        [OperationContract]
        Player CreatePlayer(Player player);

        [OperationContract]
        Player RetrievePlayer(string name);


        //Game Controller
        [OperationContract]
        void CreateGame(Game game, String questionSet, int noOfRounds);

        [OperationContract]
        void AddPlayer(Game game, Player player);

        [OperationContract]
        List<Game> RetrieveActiveGames();

        [OperationContract]
        Game RetrieveGame(string name, bool retrieveAssociation);

        [OperationContract]
        bool JoinGame(Game game, Player player);

        [OperationContract]
        bool LeaveGame(Game game, Player player);

        [OperationContract]
        List<Player> RetrieveAllPlayersByGameId(Game game);

        [OperationContract]
        bool StartGame(Game game, Player player);

        [OperationContract]
        void AddQuestionSet(Game game, QuestionSet questionSet);

        [OperationContract]
        bool CheckIfGameIsFinished(Game game);

        [OperationContract]
        Player DetermineGameWinner(Game game);

        [OperationContract]
        int DetermineNoOfCorrectAnswers(Game game, Player player);

        //QuestionSetController
        [OperationContract]
        List<QuestionSet> RetrieveAllQuestionSets();

        [OperationContract]
        QuestionSet RetrieveQuestionSet(int id);

        [OperationContract]
        QuestionSet RetrieveQuestionSetByTitle(string title);

        //RoundController
        [OperationContract]
        bool ValidateAnswer(Answer answer);

        [OperationContract]
        bool CheckPlayerAnswers(Game game, Round round);

        [OperationContract]
        void SubmitAnswer(Round round, PlayerAnswer playerAnswer);

        [OperationContract]
        bool CheckIfAllPlayersAnswered(Game game, Round round);

        [OperationContract]
        void CreateRound(Game game);

        [OperationContract]
        Player RetrieveRoundWinner(Round round);

        [OperationContract]
        Question RetrieveRandomQuestion(Game game);
        
    }
}