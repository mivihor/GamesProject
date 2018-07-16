using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using GamesProject.BusinessLogicLayer.DataTransferModels;

namespace GamesProject.BusinessLogicLayer.Interfaces
{
    public interface IUserService
    {
        bool ifUserExist(UserDTM userDTM);
        void CreateUser(UserDTM userDTM);
        Task<UserDTM> GetUserByLogin(string login);
        UserDTM GetUser(int? id);
        IEnumerable<UserDTM> GetUsers();
        void Dispose();
    }
}
