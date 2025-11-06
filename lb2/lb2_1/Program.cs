using System.Data;
using System.Security.Principal;
using System.Text;
using lb1;
using lb1.@interface;
using lb1.model;
using lb1.service;

Console.OutputEncoding = Encoding.Unicode;
IUserRepository repository = UserRepository.GetInstance("users.json");
IAuthenticationService authService = new AuthenticationService(repository);
User current = null;

while (true)
{
    try
    {
            Console.WriteLine("Вітаємо у вікторині!");
            Console.WriteLine("Будь ласка, зареєструйтесь (1) або увійдіть (2).");
            if (!int.TryParse(Console.ReadLine(), out int choice))
            {
                throw new Exception("Введено некоректне значення, спробуйте ще раз.");
            }
            switch (choice)
            {
                case 1:
                    Console.Write("Введіть логін: ");
                    string regLogin = Console.ReadLine();
                    Console.Write("Введіть пароль: ");
                    string regPassword = Console.ReadLine();
                    Console.Write("Введіть дату народження (рррр-мм-дд): ");
                    if (!DateTime.TryParse(Console.ReadLine(), out DateTime regBirthDate))
                    {
                        throw new Exception("Введено некоректну дату, спробуйте ще раз.");
                    }
                    authService.Register(regLogin, regPassword, regBirthDate);
                    Console.WriteLine("Реєстрація успішна!");
                    break;
                case 2:
                    Console.Write("Введіть логін: ");
                    string logLogin = Console.ReadLine();

                    Console.Write("Введіть пароль: ");
                    string logPassword = Console.ReadLine();

                    User user = authService.Login(logLogin, logPassword);
                    if (user != null)
                    {
                        Console.WriteLine("Тепер ви можете користуватись програмою.");
                        QuizMenu quizMenu = new QuizMenu(user, repository);
                        quizMenu.ShowMenu();
                    }
                    else
                        Console.WriteLine("Невірний логін або пароль.");
                    break;

                default:
                    Console.WriteLine("Обрано інше значення, вихід з застосунку");
                    return;
            }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Помилка: {ex.Message}");
    }
}