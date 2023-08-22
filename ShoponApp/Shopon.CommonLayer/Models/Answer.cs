using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoponCommonLayer.Models
{
    public class Answer
    {
        
        public int AnswerId { get; set; }
       
        public string AnswerDestription { get; set; }
        public int QuestionForeignId { get; set; }
        public Question Question { get; set; }
    }
}
