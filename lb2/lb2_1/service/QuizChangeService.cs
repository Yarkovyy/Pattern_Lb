using lb1.service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lb2_1.@interface;
using lb1.model;
using lb1.@interface;

namespace lb2_1.service
{
    internal class QuizChangeService : IQuizChangeService
    {
        private IQuizRepository quizRepository;
        public QuizChangeService(IQuizRepository quizRepository)
        {
            this.quizRepository = quizRepository;
        }
        public void ChangeQuizQuestions(Quiz quiz, int index)
        {
            Quiz CloneQuiz = quiz.Clone() as Quiz;
            Director director = new Director();
            QuestionBuilder questionBuilder = new QuestionBuilder();
            director.Builder = questionBuilder;
            director.buildNewQuestion();
            CloneQuiz.Questions[index] = questionBuilder.GetQuestiont();
            Console.WriteLine("Підтвердіть зміну питання (так/ні): ");
            if (Console.ReadLine().ToLower() == "так")
            {
                quiz.Questions[index] = CloneQuiz.Questions[index];
                quizRepository.Update(quiz);
                quizRepository.SaveChanges();
                Console.WriteLine("Питання змінено успішно.");
            }
            else
            {
                Console.WriteLine("Зміна питання скасована.");
            }
        }
        public void ChangeQuizTitle(Quiz quiz, string newTitle)
        {
            Quiz CloneQuiz = quiz.Clone() as Quiz;
            CloneQuiz.QuizTitle = newTitle;
            Console.WriteLine("Підтвердіть зміну назви вікторини (так/ні): ");
            if (Console.ReadLine().ToLower() == "так")
            {
                quiz.QuizTitle = CloneQuiz.QuizTitle;
                quizRepository.Update(quiz);
                quizRepository.SaveChanges();
                Console.WriteLine("Назву вікторини змінено успішно.");
            }
            else
            {
                Console.WriteLine("Зміна назви вікторини скасована.");
            }
        }
    }
}
