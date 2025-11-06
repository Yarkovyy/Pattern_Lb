using lb1.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lb1.@interface
{
    internal interface IAuthenticationService
    {        
            void Register(string login, string password, DateTime birthDate);
            User? Login(string login, string password);        
    }
}
