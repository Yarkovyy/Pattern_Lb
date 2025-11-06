using lb1.model;
using lb1.@interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace lb1.service
{
    internal class UserRepository: IUserRepository
    {
        private static UserRepository? _instance;


        private string _filePath;
        private List<User> _users;

        private UserRepository(string filePath)
        {
            _filePath = filePath;
            _users = File.Exists(_filePath)
                ? JsonSerializer.Deserialize<List<User>>(File.ReadAllText(_filePath)) ?? new List<User>()
                : new List<User>();
        }

        public static UserRepository GetInstance(string filePath)
        {
            if (_instance == null)
            {
                _instance = new UserRepository(filePath);
            }
            return _instance;
        }

        public List<User> GetAll() => new List<User>(_users);

        public void Add(User user)
        {
            _users.Add(user);
        }

        public User? FindByLogin(string login)
        {
            return _users.FirstOrDefault(u => u.Login == login);
        }

        public void Update(User user)
        {
            User existingUser = _users.FirstOrDefault(u => u.Login == user.Login);
            if (existingUser != null)
            {
                existingUser.Password = user.Password;
                existingUser.BirthDate = user.BirthDate;
            }
        }

        public void SaveChanges()
        {
            string json = JsonSerializer.Serialize(_users, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_filePath, json);
        }
    }
}
