using lb1.@interface;
using lb1.service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lb1.model;
using lb2_1.@interface;

namespace lb2_1.service
{
    internal class AdminMenu
    {
        IQuizRepository quizRepository;
        IQuizChangeService changeService;

        public AdminMenu(IQuizRepository quizRepository)
        {
            this.quizRepository = quizRepository;
            changeService = new QuizChangeService(quizRepository);
        }

        public void ShowAdminMenu()
        {
            bool adminM = true;
            while (adminM)
            {
                Console.WriteLine("Режим адміністратора:");
                Console.WriteLine("1 - Додати нову вікторину");
                Console.WriteLine("2 - Видалити вікторину");
                Console.WriteLine("3 - Змінити вікторину");
                Console.WriteLine("4 - Повернутися до головного меню");
                Console.Write("Вибір: ");
                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    throw new Exception("Введено некоректне значення, спробуйте ще раз.");
                }

                switch (choice)
                {
                    case 1:
                        {
                            QuizCreator quizCreator = new QuizCreator(quizRepository);
                            quizCreator.CreateQuiz();
                            break;
                        }
                    case 2:
                        {
                            // Видалити вікторину
                            Console.WriteLine("Доступні вікторини:");
                            var quizzes = quizRepository.GetAll();
                            for (int i = 0; i < quizzes.Count; i++)
                            {
                                Console.WriteLine($"{i + 1}. {quizzes[i].QuizTitle}");
                            }
                            Console.Write("Введіть номер вікторини для видалення: ");
                            if (!int.TryParse(Console.ReadLine(), out int choiceDel) || choiceDel > quizzes.Count + 1)
                            {
                                throw new Exception("Введено некоректне значення, спробуйте ще раз.");
                            }
                            quizRepository.Delete(quizzes[choiceDel - 1]);
                            quizRepository.SaveChanges();
                            break;
                        }
                    case 3:
                        {
                            // Змінити вікторину
                            Console.WriteLine("Доступні вікторини:");
                            var quizzes = quizRepository.GetAll();
                            for (int i = 0; i < quizzes.Count; i++)
                            {
                                Console.WriteLine($"{i + 1}. {quizzes[i].QuizTitle}");
                            }
                            Console.Write("Введіть номер вікторини для зміни: ");
                            if (!int.TryParse(Console.ReadLine(), out int choiceCh) || choiceCh > quizzes.Count + 1)
                            {
                                throw new Exception("Введено некоректне значення, спробуйте ще раз.");
                            }
                            Console.WriteLine("Оберіть дію:");
                            Console.WriteLine("1 - Змінити назву");
                            Console.WriteLine("2 - Змінити питання");
                            if (!int.TryParse(Console.ReadLine(), out int n))
                            {
                                Console.WriteLine("Введено некоректне значення, спробуйте ще раз.");
                            }

                            switch (n)
                            {
                                case 1:
                                    {
                                        Console.WriteLine("Введіть нову назву");
                                        string newTitle = Console.ReadLine();
                                        changeService.ChangeQuizTitle(quizzes[choiceCh-1], newTitle);
                                        break;
                                    }
                                case 2:
                                    {
                                        Console.WriteLine("Доступні питання:");
                                        for (int i = 0; i < quizzes[choiceCh - 1].Questions.Count; i++)
                                        {
                                            Console.WriteLine($"{i + 1}. {quizzes[choiceCh - 1].Questions[i].Text}");
                                        }
                                        Console.Write("Введіть номер вікторини для зміни: ");
                                        if (!int.TryParse(Console.ReadLine(), out int choiceQuest) || choiceQuest > quizzes.Count + 1)
                                        {
                                            throw new Exception("Введено некоректне значення, спробуйте ще раз.");
                                        }
                                        changeService.ChangeQuizQuestions(quizzes[choiceCh - 1], choiceQuest);

                                        break;
                                    }
                                default:
                                    {
                                        Console.WriteLine("Невірний вибір");
                                        break;
                                    }
                            }
                            break;
                        }
                    default:
                        {
                            // Повернутися до головного меню
                            Console.WriteLine("Повернення до головного меню...");                            
                            adminM = false;
                            break;
                        }
                }
            }
        }
    }
}
