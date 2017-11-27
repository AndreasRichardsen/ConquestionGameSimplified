using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ConquestionGame.Domain
{
    [DataContract]
    public class Player
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        [StringLength(20, ErrorMessage ="Name must be between 1 and 20 characters", MinimumLength = 1)]
        [Required]
        public string Name { get; set; }

        public List<Game> Games { get; set; }


        

    }
}
