using ShoponCommonLayer.Models;
using ShoponDataLayer.Contracts;
using ShoponEFLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoponEFLayer.Implementation
{
    public class QuestionRepositoryEFImpl : IQuestionRepository
    {
        private readonly db_shoponContext context;
        public QuestionRepositoryEFImpl()
        {
            this.context = new db_shoponContext();
        }

        public bool AddQuestion(ShoponCommonLayer.Models.Question question)
        {
            bool isAdded = false;
            try
            {
                var questionDb = new Models.Question()
                {
                    QuestionDescription=question.QuestionDescription,
                    DateOfQuery=question.DateOfQuery,
                    PId=question.PId,
                    Answer=new Models.Answer()
                    {
                        AnswerDestription=question.Answer.AnswerDestription,
                        QuestionForeignId=question.QuestionId,
                    },
                    AnswerId=question.Answer.AnswerId
                    
                };
                this.context.Add(questionDb);
                this.context.SaveChanges();
                isAdded = true;
            }
            catch (Exception)
            {

                throw;
            }
            return isAdded;
        }
    }
}
