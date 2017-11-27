using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ConquestionGame.Domain
{
    [DataContract]
    public class Question
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Text { get; set; }
        [DataMember]
        public List<Answer> Answers { get; set; }

        public int QuestionSetId { get; set; }
        public QuestionSet QuestionSet { get; set; }
        

        public override string ToString()
        {
            string toString = this.Text + "\n";
            if (Answers != null)
            {
                int i = 1;
                foreach (Answer a in Answers)
                {
                    toString += string.Format("Answer {0}: {1}", i, a.ToString());
                    i++;
                }
            }
            return toString;
        }
    }
}