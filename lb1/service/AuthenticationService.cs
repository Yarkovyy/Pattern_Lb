using lb1.@interface;
using lb1.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lb1.service
{
    internal class AuthenticationService: IAuthenticationService
    {
        private IUserRepository _userRepository;

        public AuthenticationService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public void Register(string login, string password, DateTime birthDate)
        {
            if (_userRepository.FindByLogin(login) != null)
                throw new Exception("Користувач з таким логіном вже існує.");

            User user = new User { Login = login, Password = password, BirthDate = birthDate };
            _userRepository.Add(user);
            _userRepository.SaveChanges();
        }

        public User? Login(string login, string password)
        {
            User user = _userRepository.FindByLogin(login);
            if (user != null && user.Password == password)
                return user;
            return null;
        }
    }
}
