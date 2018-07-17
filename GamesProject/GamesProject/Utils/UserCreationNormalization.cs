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

        public UserDTM Normalize(UserCreationModel userCM)
        {
            if (userCM == null)
                throw new Exception("User can't be created");

            UserDTM user = new UserDTM();
            user.LoginDTM = userCM.LoginUCM;
            user.NameDTM = userCM.NameUCM;
            user.SurnameDTM = userCM.SurnameUCM;
            user.PasswordDTM = _hasher.HashPassword(user, userCM.PasswordUCM);
            user.RoleDTM = "User";

            return user;
        }
    }
}
