using lb1.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lb1.@interface
{
    internal interface IQuizRepository
    {
        List<Quiz> GetAll();
        Quiz MixQuiz(); 
    }
}
