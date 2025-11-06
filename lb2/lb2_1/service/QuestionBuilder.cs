using lb1.@interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lb1.model;

namespace lb2_1.service
{
    internal class QuestionBuilder : IBuilder
    {
        private Question question = new Question();
        public void Reset()
        {
            this.question = new Question();
        }
        public void SetTitle()
        {
            Console.Write("Введіть текст питання: ");
            string questionText = Console.ReadLine();
            question.Text = questionText;
        }
        public void AddOption()
        {
            Console.Write($"Введіть текст відповіді: ");
            string optionText = Console.ReadLine() ?? "";
            question.Options.Add(optionText);
            Console.WriteLine("Чи є ця відповідь правильною? (так/ні): ");
            string isCorrect = Console.ReadLine() ?? "";
            if (isCorrect.ToLower() == "так")
            {
                question.CorrectOptionIndex.Add(question.Options.Count - 1);
            }
        }
        public Question GetQuestiont()
        {
            Question result = this.question;
            this.Reset();
            return result;
        }
    }
}
