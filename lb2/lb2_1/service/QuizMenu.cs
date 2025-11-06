using lb1.@interface;
using lb1.model;
using lb2_1.service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lb1.service
{
    internal class QuizMenu
    {
        User current;
        IUserChangeService changeService;
        IQuizRepository quizRepository = QuizRepository.GetInstance("quizzes.json");
        IResultRepository resultRepository = ResultRepository.GetInstance("results.json");
        public QuizMenu(User user, IUserRepository repository)
        {
            current = user;
            changeService = new UserChangeService(repository);
        }
        public void ShowMenu()
        {
            while (current != null)
            {
                Console.WriteLine($"Ви увійшли як {current.Login}");
                Console.WriteLine("1 - Почати нову вікторину");
                Console.WriteLine("2 - Переглянути свої результати");
                Console.WriteLine("3 - Переглянути Топ-20");
                Console.WriteLine("4 - Налаштування (змінити пароль/дату народження)");
                Console.WriteLine("5 - Режим адміністратора");
                Console.WriteLine("6 - Вийти з акаунту");
                Console.Write("Вибір: ");

                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    throw new Exception("Введено некоректне значення, спробуйте ще раз.");

                }

                switch (choice)
                {
                    case 1:
                        {
                            QuizManager quizManager = new QuizManager(resultRepository, quizRepository);
                            List<Quiz> quizzes = quizRepository.GetAll();
                            Console.WriteLine("Доступні вікторини:");
                            Console.WriteLine($"1. Мікс Вікторина");
                            for (int i = 0; i < quizzes.Count; i++)
                            {
                                Console.WriteLine($"{i + 2}. {quizzes[i].QuizTitle}");
                            }
                            Console.Write("Виберіть номер вікторини: ");

                            if (int.TryParse(Console.ReadLine(), out int quizChoice) && quizChoice >= 1 && quizChoice <= quizzes.Count + 2)
                            {
                                if (quizChoice == 1)
                                    quizManager.StartQuiz(current, quizRepository.MixQuiz());
                                else
                                    quizManager.StartQuiz(current, quizzes[quizChoice - 2]);
                            }
                            else
                            {
                                Console.WriteLine("Невірний вибір вікторини.");
                            }
                            break;
                        }
                    case 2:
                        {
                            List<Result> userResults = resultRepository.GetResultsByUser(current.Login);
                            Console.WriteLine("Ваші результати:");
                            foreach (var result in userResults)
                            {
                                Console.WriteLine($"Вікторина: {result.QuizTitle}, Результат: {result.Score}");
                            }
                            break;
                        }
                    case 3:
                        {
                            Console.Write("Виберіть номер вікторини для перегляду Топ-20: ");
                            List<string> Titles = resultRepository.GetAllResults().Select(r => r.QuizTitle).Distinct().ToList();
                            Console.WriteLine("Доступні вікторини:");
                            int index = 1;
                            foreach (var title in Titles)
                            {
                                Console.WriteLine($"{index} - {title}");
                                index++;
                            }

                            if (!int.TryParse(Console.ReadLine(), out int ResultChoice))
                            {
                                throw new Exception("Введено некоректне значення, спробуйте ще раз.");
                            }

                            List<Result> topResults = resultRepository.GetResultsByQuiz(Titles[ResultChoice - 1]);
                            Console.WriteLine($"Топ-20 для вікторини '{Titles[ResultChoice - 1]}':");
                            if (topResults.Count == 0)
                                Console.WriteLine("Результати відсутні");
                            foreach (var result in topResults)
                            {
                                Console.WriteLine($"Користувач: {result.UserName}, Результат: {result.Score}");
                            }
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("1 - Змінити пароль");
                            Console.WriteLine("2 - Змінити дату народження");
                            if (!int.TryParse(Console.ReadLine(), out int n))
                            {
                                Console.WriteLine("Введено некоректне значення, спробуйте ще раз.");
                            }

                            switch (n)
                            {
                                case 1:
                                    {
                                        Console.WriteLine("Введіть новий пароль");
                                        string newPassword = Console.ReadLine();
                                        changeService.ChangePassword(current, newPassword);
                                        break;
                                    }
                                case 2:
                                    {
                                        Console.WriteLine("Введіть нову дату народження (рррр-мм-дд)");
                                        DateTime newBirthDate = DateTime.Parse(Console.ReadLine());
                                        changeService.ChangeBirthDate(current, newBirthDate);
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
                    case 5:
                        {
                            Console.WriteLine("Введіть пароль адміністратора.");
                            string adminPassword = Console.ReadLine();
                            if (adminPassword == "admin123")
                            {
                                Console.WriteLine("Вхід в режим адміністратора");
                                AdminMenu adminMenu = new AdminMenu(quizRepository);
                                adminMenu.ShowAdminMenu();
                            }
                            else
                            {
                                Console.WriteLine("Доступ заборонено. Невірний пароль адміністратора.");
                            }
                            break;
                        }
                    case 6:
                        {
                            current = null;
                            break;
                        }
                }            
            }
        }
    }
}