using lb1.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lb1.@interface
{
    internal interface IUserChangeService
    {
        //void ChangeLogin(User user, string newLogin);
        void ChangePassword(User user, string newPassword);
        void ChangeBirthDate(User user, DateTime newBirthDate);
        
    }
}
