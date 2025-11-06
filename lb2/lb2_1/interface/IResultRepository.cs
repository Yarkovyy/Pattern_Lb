using lb1.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lb1.@interface
{
    internal interface IResultRepository
    {
        void AddResult(Result result);
        List<Result> GetResultsByUser(string userName);
        List<Result> GetResultsByQuiz(string quizTitle);
        List<Result> GetAllResults();
        void SaveChanges();

    }
}
