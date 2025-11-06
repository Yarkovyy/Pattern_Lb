using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Calculator
{
    internal class MenuCalculator
    {
        ICalculator calculator;
        public MenuCalculator(ICalculator calc)
        {
            calculator = calc;
        }
        public void Menu()
        {
            bool f = true;
            do
            {
                try
                {
                    WriteLine("Введіть перше число:");
                    if (!double.TryParse(ReadLine(), out double a))
                    {
                        throw new Exception("Некоректне введення першого числа.");
                    }
                    WriteLine("Оберіть операцію: +, -, *, /");
                    string operation = ReadLine();
                    WriteLine("Введіть друге число:");
                    if (!double.TryParse(ReadLine(), out double b))
                    {
                        throw new Exception("Некоректне введення другого числа.");
                    }
                    switch (operation)
                    {
                        case "+":
                            {
                                double result = calculator.Add(a, b);
                                WriteLine($"Результат: {result:f3}");
                                break;
                            }
                        case "-":
                            {
                                double result = calculator.Subtract(a, b);
                                WriteLine($"Результат: {result:f3}");
                                break;
                            }
                        case "*":
                            {
                                double result = calculator.Multiply(a, b);
                                WriteLine($"Результат: {result:f3}");
                                break;
                            }
                        case "/":
                            {
                                try
                                {
                                    double result = calculator.Divide(a, b);
                                    WriteLine($"Результат: {result:f3}");
                                }
                                catch (DivideByZeroException)
                                {
                                    WriteLine("Помилка: Ділення на нуль.");
                                }
                                break;
                            }
                        default:
                            {
                                WriteLine("Некоректна операція.");
                                break;
                            }
                    }
                }
                catch(Exception ex)
                {
                    WriteLine($"Помилка: {ex.Message}");
                }

                WriteLine("Продовжити роботу калькулятора? (y/n):");
                string? c = ReadLine();
                if(c.ToLower() != "y")
                {
                    f = false;
                };
            } while (f);
            WriteLine("Завершення роботи.");
        }
    }
}
