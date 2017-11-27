using ConquestionGame.DataAccessLayer;
using ConquestionGame.Domain;
using System.Collections.Generic;
using System.Linq;

namespace ConquestionGame.LogicLayer
{
    public class QuestionSetController
    {
        ConquestionDBContext db = new ConquestionDBContext();

        //Definitely Keep
        public QuestionSet CreateQuestionSet(QuestionSet questionSet)   
        {
            db.QuestionSets.Add(questionSet);
            db.SaveChanges();
            return questionSet;
        }

        //Definitely Keep
        public List<QuestionSet> RetrieveAllQuestionSets()
        {
            var questionSet = db.QuestionSets.Include("Questions.Answers").ToList();
            return questionSet;
        }

        //Definitely Keep
        public QuestionSet RetrieveQuestionSet(int id)
        {
            var questionSet = db.QuestionSets.Include("Questions.Answers").Where(x => x.Id == id).FirstOrDefault();
            return questionSet;
        }

        public QuestionSet RetrieveQuestionSetByTitle(string title)
        {
            var questionSet = db.QuestionSets.Include("Questions.Answers").Where(x => x.Title.Equals(title)).FirstOrDefault();
            return questionSet;
        }

        public void DeleteQuestionSet(QuestionSet questionSet)
        {
            db.QuestionSets.Remove(questionSet);
            db.SaveChanges();
        }

        public Question AskQuestion()
        {
            QuestionSet q = RetrieveQuestionSet(2);
            Question question = q.Questions[0];

            return question;
        }

        //Not sure we need these
        public void AddQuestionsToQuestionSet(QuestionSet questionSet, List<Question> questionlist)
        {
            if(questionSet.Questions == null)
            {
                questionSet.Questions = new List<Question>();
            }

            foreach(Question q in questionlist)
            {
                questionSet.Questions.Add(q);
            }

            db.Entry(questionSet).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

        //not sure we need these
        public void AddAnswersToAQuestion(Question question, List<Answer> answerList)
        {
             if(question.Answers == null)
            {
                question.Answers = new List<Answer>();
            }

            foreach(Answer a in answerList)
            {
                question.Answers.Add(a);
            }

            db.Entry(question).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
    }
}
