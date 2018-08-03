using GamesProject.BusinessLogicLayer.DataTransferModels;
using GamesProject.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamesProject.Utils
{
    public class UserCreationNormalization
    {
        private IPasswordHasher<UserDTM> _hasher;
        public UserCreationNormalization(IPasswordHasher<UserDTM> hasher)
        {
            _hasher = hasher;
        }

        public async Task<UserDTM> Normalize(UserCreationModel userCM)
        {
            return await Task.Run(() =>
        {
            if (userCM == null)
                throw new Exception("User can't be created");

            UserDTM user = new UserDTM();
            user.LoginDTM = LoginNormalization(userCM.LoginUCM);
            user.NameDTM = NameSurnameNormalization(userCM.NameUCM);
            user.SurnameDTM = NameSurnameNormalization(userCM.SurnameUCM);
            user.PasswordDTM = _hasher.HashPassword(user, userCM.PasswordUCM);
            user.RoleDTM = "User";

            return user;
        });
        }

        public string NameSurnameNormalization(string s)
        {
            var charsToRemove = new string[] { " ", "*", ".", "<", ">", "\\", "/", "\"", "\"", "@", "(", ")", "?" };
            foreach (var c in charsToRemove)
            {
                s = s.Replace(c, string.Empty);
            }

            if (s.Length > 30) s = s.Substring(0, 30);
            return s;
        }

        public string LoginNormalization(string s)
        {
            var charsToRemove = new string[] { " ", "*", ".", "<", ">", "\\", "/", "(", ")", "?" };
            foreach (var c in charsToRemove)
            {
                s = s.Replace(c, string.Empty);
            }

            if (s.Length > 30) s = s.Substring(0, 30);
            return s;
        }

    }
}
