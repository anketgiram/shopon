using ShoponBusinessLayer.Contracts;
using ShoponBusinessLayer.Implementation;
using ShoponCommonLayer.Models;
using ShoponDataLayer.Contracts;
using ShoponEFLayer.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoponConsoleApp
{
    public class QuestionMenu
    {
        public void QuestionMainMenu()
        {
            IQuestionRepository questionRepository = new QuestionRepositoryEFImpl();
            IQuestionManager questionManager = new QuestionManager(questionRepository);
            AddQuestion(questionManager);
        }

        private void AddQuestion(IQuestionManager questionManager)
        {
            Question question = new Question()
            {
                QuestionDescription = "Is it Support 5G",
                DateOfQuery = DateTime.UtcNow,
                PId = 103,
                Answer = new Answer()
                {
                    AnswerDestription = "Yes it is",
                }
            };
            if(questionManager.AddQuestion(question))
            {
                Console.WriteLine("Question Added");
            }
            else
            {
                Console.WriteLine("Question Not Added");
            }
        }
    }
}
