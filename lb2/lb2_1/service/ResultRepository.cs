using lb1.model;
using lb1.@interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace lb1.service
{
    internal class ResultRepository: IResultRepository
    {
        private  static ResultRepository? _instance;
        private List<Result> results;
        private string _filePath;
        private ResultRepository(string filePath)
        {
            _filePath = filePath;
            results = File.Exists(_filePath)
                ? JsonSerializer.Deserialize<List<Result>>(File.ReadAllText(_filePath)) ?? new List<Result>()
                : new List<Result>();
        }
        public static ResultRepository GetInstance(string filePath)
        {
            if (_instance == null)
            {
                _instance = new ResultRepository(filePath);
            }
            return _instance;
        }
        public void AddResult(Result result)
        {
            results.Add(result);
        }
        public List<Result> GetAllResults() => new List<Result>(results);

        public List<Result> GetResultsByUser(string userName)
        {
            return results.Where(r => r.UserName == userName).ToList();
        }
        public List<Result> GetResultsByQuiz(string quizTitle)
        {
            return results.Where(r => r.QuizTitle == quizTitle).OrderBy(r=>r.Score).Take(20).ToList();
        }
        public void SaveChanges()
        {
            string json = JsonSerializer.Serialize(results, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_filePath, json);
        }
    }
}
