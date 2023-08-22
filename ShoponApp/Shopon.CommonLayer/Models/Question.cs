using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoponCommonLayer.Models
{
    public class Question
    {
        public int QuestionId { get; set; }
       
        public string QuestionDescription { get; set; }
        public DateTime DateOfQuery { get; set; }
        public int PId { get; set; }
        public Product Product { get; set; }
        public int AnswerId { get; set; }
        public Answer Answer { get; set; }
    }
}
