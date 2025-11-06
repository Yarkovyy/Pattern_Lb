using lb1.@interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lb1.model;

namespace lb2_1.service
{
    internal class QuizCreator
    {
        private IQuizRepository quizRepository;
        public QuizCreator(IQuizRepository quizRepository)
        {
            this.quizRepository = quizRepository;
        }

        public void CreateQuiz()
        {
            // Додати нову вікторину
            Quiz newQuiz = new Quiz();
            Console.Write("Введіть назву вікторини: ");
            newQuiz.QuizTitle = Console.ReadLine();
            newQuiz.Questions = new List<Question>();
            Director director = new Director();
            QuestionBuilder questionBuilder = new QuestionBuilder();
            director.Builder = questionBuilder;
            bool exit = true;
            do
            {
                Console.WriteLine("Створення запитання");
                director.buildNewQuestion();
                newQuiz.Questions.Add(questionBuilder.GetQuestiont());
                Console.WriteLine("Додати ще одне питання? (так/ні): ");
                if(Console.ReadLine().ToLower() != "так")
                    exit = false;                
            } while (exit);

            quizRepository.Add(newQuiz);
            quizRepository.SaveChanges();
            Console.WriteLine("Нова вікторина додана успішно!");
        }
    }
}
