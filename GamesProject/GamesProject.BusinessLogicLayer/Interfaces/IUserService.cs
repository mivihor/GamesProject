using System;
using System.Collections.Generic;
using System.Text;
using GamesProject.BusinessLogicLayer.DataTransferModels;

namespace GamesProject.BusinessLogicLayer.Interfaces
{
    interface IUserService
    {
        bool ifUserExist(UserDTM userDTM);
        void CreateUser(UserDTM userDTM);
        UserDTM GetUser(int? id);
        IEnumerable<UserDTM> GetUsers();
        void Dispose();
    }
}
