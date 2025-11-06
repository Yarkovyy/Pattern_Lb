using lb1.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lb1.@interface
{
    internal interface IUserRepository
    {
        List<User> GetAll();
        void Add(User user);
        void Update(User user);
        User? FindByLogin(string login);
        void SaveChanges();
    }
}

