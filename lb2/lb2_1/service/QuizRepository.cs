using lb1.@interface;
using lb1.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace lb1.service
{
    internal class QuizRepository :  IQuizRepository
    {
        private static QuizRepository? _instance;

        private string _filePath;
        private List<Quiz> quizzes;
        private QuizRepository(string filePath)
        {
            _filePath = filePath;
            quizzes = File.Exists(_filePath)
                ? System.Text.Json.JsonSerializer.Deserialize<List<Quiz>>(File.ReadAllText(_filePath)) ?? new List<Quiz>()
                : new List<Quiz>();
        }

        public static QuizRepository GetInstance(string filePath)
        {
            if (_instance == null)
            {
                _instance = new QuizRepository(filePath);
            }
            return _instance;
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
        public void Delete(Quiz quiz)
        {
            quizzes.Remove(quiz);
        }
        //public Quiz? FindByTitle(string title)
        //{
        //    return quizzes.FirstOrDefault(u => u.QuizTitle == title);
        //}
        public void Update(Quiz quiz)
        {
            var existingQuiz = quizzes.FirstOrDefault(q => q.QuizTitle == quiz.QuizTitle);
            if (existingQuiz != null)
            {
                existingQuiz.Questions = quiz.Questions;
            }
        }
        public void Add(Quiz quiz)
        {
            quizzes.Add(quiz);
        }
        public void SaveChanges()
        {
            string json = JsonSerializer.Serialize(quizzes, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_filePath, json);
        }
    }
}
