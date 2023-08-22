using ShoponBusinessLayer.Contracts;
using ShoponCommonLayer.Models;
using ShoponDataLayer.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoponBusinessLayer.Implementation
{
    public class QuestionManager:IQuestionManager
    {
        private readonly IQuestionRepository questionRepository;
        public QuestionManager(IQuestionRepository questionRepository)
        {
            this.questionRepository = questionRepository;
        }

        public bool AddQuestion(Question question)
            => questionRepository.AddQuestion(question);
        
    }
}
