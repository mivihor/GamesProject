using System;
using System.Collections.Generic;
using System.Text;
using GamesProject.BusinessLogicLayer.DataTransferModels;
using Microsoft.AspNetCore.Identity;

namespace GamesProject.BusinessLogicLayer.Interfaces
{
    public interface IUserService
    {
        bool ifUserExist(UserDTM userDTM);
        void CreateUser(UserDTM userDTM);
        UserDTM GetUser(int? id);
        IEnumerable<UserDTM> GetUsers();
        void Dispose();
    }
}
