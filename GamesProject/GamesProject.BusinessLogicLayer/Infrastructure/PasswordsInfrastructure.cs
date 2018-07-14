using GamesProject.BusinessLogicLayer.DataTransferModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace GamesProject.BusinessLogicLayer.Infrastructure
{
    class PasswordsInfrastructure : IPasswordHasher<UserDTM>
    {
        private readonly IPasswordHasher<UserDTM> passwordHasher;

        public PasswordsInfrastructure()
        {
            this.passwordHasher = new PasswordHasher<UserDTM>();
        }

        public string HashPassword(UserDTM user, string password)
        {
            return passwordHasher.HashPassword(user, user.PasswordDTM);
        }

        public PasswordVerificationResult VerifyHashedPassword(UserDTM user, string hashedPassword, string providedPassword)
        {
            PasswordVerificationResult result = this.passwordHasher.VerifyHashedPassword(user, user.PasswordDTM, providedPassword);
            return result;
        }
    }
}
