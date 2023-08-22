using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoponEFLayer.Models
{
    [Table("CustomerQueries")]
    public class Question
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int QuestionId { get; set; }
        [MaxLength(250)]
        public string QuestionDescription { get; set; }
        public DateTime DateOfQuery { get; set; }
        public int PId { get; set; }
        public Product Product { get; set; }
        public int AnswerId { get; set; }
        public Answer Answer { get; set; }
    }
}
