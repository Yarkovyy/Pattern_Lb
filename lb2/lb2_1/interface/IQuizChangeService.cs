using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lb1.model;
using lb1.service;

namespace lb2_1.@interface
{
    internal interface IQuizChangeService
    {        
        void ChangeQuizTitle(Quiz quiz, string newTitle);
        void ChangeQuizQuestions(Quiz quiz, int index);
    }
}
