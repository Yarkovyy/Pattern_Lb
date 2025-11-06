using lb1.@interface;
using lb1.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lb1.service
{
    internal class UserChangeService: IUserChangeService
    {
        private IUserRepository _userRepository;
        public UserChangeService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public void ChangePassword(User user, string newPassword)
        {
            user.Password = newPassword;
            _userRepository.Update(user);
            _userRepository.SaveChanges();
        }
        public void ChangeBirthDate(User user, DateTime newBirthDate)
        {
            user.BirthDate = newBirthDate;
            _userRepository.Update(user);
            _userRepository.SaveChanges();
        }
    }
}
