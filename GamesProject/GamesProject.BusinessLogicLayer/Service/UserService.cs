using System;
using System.Collections.Generic;
using System.Text;
using GamesProject.BusinessLogicLayer.Interfaces;
using GamesProject.BusinessLogicLayer.DataTransferModels;
using GamesProject.BusinessLogicLayer.Infrastructure;
using GamesProject.DataAccessLayer.Interfaces;
using GamesProject.DataAccessLayer.Entities;
using AutoMapper;

namespace GamesProject.BusinessLogicLayer.Service
{
    public class UserService : IUserService
    {
        IUnitOfWork DataBase { get; set; }

        public UserService(IUnitOfWork UoW)
        {
            DataBase = UoW;
        }

        public bool ifUserExist(UserDTM userDTM)
        {
            IEnumerable<User> users = DataBase.Users.Find(m => m.Login == userDTM.LoginDTM);
            if (users != null) return true;
            return false;
        }

        public void CreateUser(UserDTM userDTM)
        {
            if (ifUserExist(userDTM))
                throw new ValidationException("Unable to create user, user already exist", "");
            if (userDTM == null)
                throw new ValidationException("User is null", "");

            User user = new User
            {
                Name = userDTM.NameDTM,
                Surname = userDTM.SurnameDTM,
                Login = userDTM.LoginDTM,
                Password = userDTM.PasswordDTM,
                Role = userDTM.RoleDTM
            };

            DataBase.Users.Create(user);
            DataBase.Save();
        }

        public IEnumerable<UserDTM> GetUsers()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<User, UserDTM>()).CreateMapper();
            return mapper.Map<IEnumerable<User>, List<UserDTM>>(DataBase.Users.GetAll());
        }

        public UserDTM GetUser(int? id)
        {
            if (id == null)
                throw new ValidationException("ID not setted", "");

            var user = DataBase.Users.Get(id.Value);

            if (user == null)
                throw new ValidationException("User not found", "");

            return new UserDTM
            {
                NameDTM = user.Name,
                SurnameDTM = user.Surname,
                LoginDTM = user.Login,
                PasswordDTM = user.Password,
                RoleDTM = user.Role
            };

        }
        public void Dispose()
        {
            DataBase.Dispose();
        }
    }
}
