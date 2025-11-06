using lb1.@interface;
using lb1.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lb1.service
{
    internal class QuizManager
    {
        private IQuizRepository _quizRepository;
        private IResultRepository _resultRepository;
        public QuizManager(IResultRepository resultRepository, IQuizRepository quizRepository) 
        {
            _quizRepository = quizRepository;
            _resultRepository = resultRepository;
        }
        
        public void StartQuiz(User user, Quiz quiz)
        {

            int n, i, score = 0;
            Random random = new Random();
            //foreach (Question question in quiz.Questions)
            for (i = 0; i < 20 && i<quiz.Questions.Count; i++)
            {
                n = random.Next(0, quiz.Questions.Count);
                Console.WriteLine(quiz.Questions[n].Text);
                for (int j = 0; j < quiz.Questions[n].Options.Count; j++)
                {
                    Console.WriteLine($"{j + 1}. {quiz.Questions[n].Options[j]}");
                }
                Console.Write("Введіть номери відповідей через пробіл: ");
                try
                {
                    string input = Console.ReadLine();
                    List<int> userAnswers = input.Split(' ').Select(int.Parse).Select(x => x - 1).ToList();
                    if (quiz.Questions[n].IsCorrect(userAnswers))
                    {
                        score++;
                        Console.WriteLine("Відповідь правильна");
                    }
                    else
                    {
                        Console.WriteLine("Відповідь не правильна");
                    }

                }
                catch { Console.WriteLine("Некоректний ввід"); }
            }
            Console.WriteLine($"Вікторину завершено! Ваш результат: {score}/20");
            Result result = new Result
            {
                UserName = user.Login,
                QuizTitle = quiz.QuizTitle,
                Score = score,
                //Date = DateTime.Now
            };
            _resultRepository.AddResult(result);
            _resultRepository.SaveChanges();
        }

    }
}
