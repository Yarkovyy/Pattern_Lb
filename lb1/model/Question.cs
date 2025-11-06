using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lb1.model
{
    internal class Question
    {
        public Question() { }
        public string Text { get; set; }
        public List<string> Options { get; set; }
        public List<int> CorrectOptionIndex { get; set; }

        public bool IsCorrect(List<int> userAnswers)
        {
            return CorrectOptionIndex.OrderBy(n=>n).SequenceEqual(userAnswers.OrderBy(x=>x));
        }
    }
}
