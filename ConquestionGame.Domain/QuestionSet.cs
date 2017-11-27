using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ConquestionGame.Domain
{
    [DataContract]
    public class QuestionSet
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public List<Question> Questions { get; set; }


        public override string ToString()
        {
            string toString = this.Title + "\n"
                + this.Description + "\n";
            if (Questions != null)
            {
                int i = 1;
                foreach (Question q in Questions)
                {
                    toString += String.Format("Question {0}: {1}", i, q.ToString());
                    i++;
                }
            }
            return toString;
        }
    }
}
