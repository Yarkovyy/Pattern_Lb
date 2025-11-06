using lb1.@interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lb2_1.service
{
    internal class Director
    {
        private IBuilder? _builder;

        public IBuilder Builder
        {
            set { _builder = value; }
        }

        public void buildNewQuestion()
        {
            Console.Write("Введіть кількість варіантів: ");
            if (!int.TryParse(Console.ReadLine(), out int ResultChoice))
            {
                throw new Exception("Введено некоректне значення, спробуйте ще раз.");
            }
            _builder.SetTitle();
            for (int i = 0; i < ResultChoice; i++)
            {
                Console.Write($"Відповідь {i + 1}: ");
                _builder.AddOption();
            }
        }    
    }
}
