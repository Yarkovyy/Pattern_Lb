using lb1.model;
using lb1.@interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lb1.service
{
    internal class QuizRepository : IQuizRepository
    {
        private string _filePath;
        private List<Quiz> quizzes;
        public QuizRepository(string filePath)
        {
            _filePath = filePath;
            quizzes = File.Exists(_filePath)
                ? System.Text.Json.JsonSerializer.Deserialize<List<Quiz>>(File.ReadAllText(_filePath)) ?? new List<Quiz>()
                : new List<Quiz>();
        }
        public List<Quiz> GetAll() => new List<Quiz>(quizzes);

        public Quiz MixQuiz() //Повернути мікс квіз
        {
            List<Question> allQuestions = quizzes.SelectMany(q => q.Questions).ToList();
            Random random = new Random();
            List<Question> selectedQuestions = new List<Question>();

            while (selectedQuestions.Count < 20)
            {
                int index = random.Next(0, allQuestions.Count);
                if (!selectedQuestions.Contains(allQuestions[index]))
                {
                    selectedQuestions.Add(allQuestions[index]);
                }
            }

            return new Quiz { QuizTitle = "Мікс Вікторина", Questions = selectedQuestions };
        }

    }
}
