using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoponEFLayer.Models
{
    [Table("CustomerAnswers")]
    public class Answer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AnswerId { get; set; }
        [MaxLength(500)]
        public string AnswerDestription { get; set; }
        public int QuestionForeignId { get; set; }
        public Question Question { get; set; }

    }
}
