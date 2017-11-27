using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ConquestionGame.Domain
{
    [DataContract]
    public class Round
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public RoundTypeEnum RoundType { get; set; }
        [DataMember]
        public List<RoundAction> RoundActions { get; set; }
        public Game Game { get; set; }

        
     
        public enum RoundTypeEnum
        {
            starting = 0,
            expansion = 1,
            conquest = 2,
        };
    }
}
