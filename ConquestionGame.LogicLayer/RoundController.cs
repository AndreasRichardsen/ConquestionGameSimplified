using ConquestionGame.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConquestionGame.Domain;

namespace ConquestionGame.LogicLayer
{
    public class RoundController
    {
        ConquestionDBContext db = new ConquestionDBContext();

        public bool CheckPlayerAnswers(Game game, Round round)
        {
            bool ready = false;

            var gameEntity = db.Games.Include("Players").Where(g => g.Name.Equals(game.Name)).FirstOrDefault();

            var roundActionEntity = db.Rounds.Include("PlayerAnswers").Where(p => p.Id == (round.Id)).FirstOrDefault();

            while (gameEntity.Players.Count != roundActionEntity.PlayerAnswers.Count)
            {
                Console.WriteLine("waiting");
            }
            ready = true;
            return ready;
        }

        public void CreateRound(Game game)
        {
            // Should be ok
            var gameEntity = db.Games.Include("Players").Include("QuestionSet.Questions.Answers").Include("Rounds.Question.Answers")
                .Where(x => x.Id.Equals(game.Id))
                .FirstOrDefault();

            //Check if rounds list has been initialised
            if (gameEntity.Rounds == null)
            {
                gameEntity.Rounds = new List<Round>();
            }

            // if there are rounds get the count and set the round number to the count + 1
            int? noOfRounds = gameEntity.Rounds.Count();
            var newRound = new Round();

            if (noOfRounds == null || noOfRounds == 0)
            {
                newRound.RoundNo = 1;
                
            }
            else
            {
                newRound.RoundNo = (int) noOfRounds + 1;
            }

            newRound.QuestionStartTime = DateTime.Now;
            newRound.Question = gameEntity.QuestionSet.Questions.Where(q => q.Id == newRound.RoundNo).FirstOrDefault();
            gameEntity.Rounds.Add(newRound);

            db.Entry(gameEntity).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

        public void SubmitAnswer(Round round, PlayerAnswer playerAnswer)
        {
            //This is important to compare to the question start time to see if the player answered in time.
            playerAnswer.PlayerAnswerTime = DateTime.Now;
            var playerEntity = db.Players.Where(p => p.Name.Equals(playerAnswer.Player.Name)).FirstOrDefault();
            playerAnswer.Player = playerEntity;
            var answerEntity = db.Answers.Where(a => a.Id == playerAnswer.AnswerGiven.Id).FirstOrDefault();
            playerAnswer.AnswerGiven = answerEntity; 
            Round rEntity = db.Rounds.Include("PlayerAnswers.Player").Include("RoundWinner").Where(r => r.Id == round.Id).FirstOrDefault();

            // Check is the list has been initialised, if not intialise it
            if (rEntity.PlayerAnswers == null)
            {
                rEntity.PlayerAnswers = new List<PlayerAnswer>();
            }

            //Checking if the player answers in time and that they haven't already submitted an answer
            int elapsedSeconds = (int)(playerAnswer.PlayerAnswerTime - rEntity.QuestionStartTime).TotalSeconds;
            bool playerHasntAnswered = true;
            if (rEntity.PlayerAnswers.Where(pa => pa.Player.Id == playerAnswer.Player.Id).FirstOrDefault() != null)
            {
                playerHasntAnswered = false;
            }

            //Saves the player's answer to the database  
            if (elapsedSeconds <= 35 && playerHasntAnswered)
            {
                rEntity.PlayerAnswers.Add(playerAnswer);
                if (ValidateAnswer(playerAnswer.AnswerGiven) && rEntity.RoundWinner == null)
                {
                    rEntity.RoundWinner = playerAnswer.Player;
                }
                db.Entry(rEntity).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public bool ValidateAnswer(Answer answer)
        {
            bool success = db.Answers.AsNoTracking().Where(a => a.Id == answer.Id).FirstOrDefault().IsValid;
            return success;
        }

        //To see if everyone has answered in this round
        public bool CheckIfAllPlayersAnswered(Game game, Round round)
        {
            bool allPlayersAnswered = false;
            int noOfPlayers = game.Players.Count;
            var raEntity = db.Rounds.Include("PlayerAnswers").Where(ra => ra.Id == round.Id).FirstOrDefault();
            int? noOfAnswers = raEntity.PlayerAnswers?.Count;
            if (noOfPlayers == noOfAnswers)
            {
                allPlayersAnswered = true;
            }
            return allPlayersAnswered;
        }

        public Player GetRoundWinner(Round round)
        {
            var rEntity = db.Rounds.Include("RoundWinner").Where(r => r.Id == round.Id).FirstOrDefault();
            return rEntity.RoundWinner;
        }
    }
}
