using System;
using System.Collections.Generic;
using System.Text;
using GamesProject.BusinessLogicLayer.Interfaces;
using GamesProject.BusinessLogicLayer.DataTransferModels;
using GamesProject.BusinessLogicLayer.Infrastructure;
using GamesProject.DataAccessLayer.Interfaces;
using GamesProject.DataAccessLayer.Entities;
using AutoMapper;
using System.Linq;

namespace GamesProject.BusinessLogicLayer.Service
{
    public class UserService : IUserService
    {
        private IUnitOfWork _DataBase { get; set; }
        private PasswordsInfrastructure PasswordsInfrastructure;

        public UserService(IUnitOfWork DataBase)
        {
            _DataBase = DataBase;
            this.PasswordsInfrastructure = new PasswordsInfrastructure();
        }

        public bool ifUserExist(UserDTM userDTM)
        {
            IEnumerable<User> users =_DataBase.Users.Find(m => m.Login == userDTM.LoginDTM);
            var userCheck = users.ToList();
            if (userCheck.Count == 0) return false;
            return true;
        }

        public void CreateUser(UserDTM userDTM)
        {
            if (userDTM == null)
                throw new ValidationException("User is null", "");
            if (ifUserExist(userDTM))
                throw new ValidationException("Unable to create user, user already exist", "");

            User user = new User
            {
                Name = userDTM.NameDTM,
                Surname = userDTM.SurnameDTM,
                Login = userDTM.LoginDTM,
                Password = PasswordsInfrastructure.HashPassword(userDTM, userDTM.PasswordDTM),
                Role = userDTM.RoleDTM
            };

            _DataBase.Users.Create(user);
            _DataBase.Save();
        }

        public IEnumerable<UserDTM> GetUsers()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<User, UserDTM>()).CreateMapper();
            return mapper.Map<IEnumerable<User>, List<UserDTM>>(_DataBase.Users.GetAll());
        }

        public UserDTM GetUser(int? id)
        {
            if (id == null)
                throw new ValidationException("ID not setted", "");

            var user = _DataBase.Users.Get(id.Value);

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
            _DataBase.Dispose();
        }
    }
}
