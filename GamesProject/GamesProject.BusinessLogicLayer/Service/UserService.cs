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
using System.Threading.Tasks;

namespace GamesProject.BusinessLogicLayer.Service
{
    public class UserService : IUserService
    {
        private IUnitOfWork _DataBase { get; set; }

        public UserService(IUnitOfWork DataBase)
        {
            _DataBase = DataBase;
        }

        public bool ifUserExist(UserDTM userDTM)
        {
                IEnumerable<User> users = _DataBase.Users.Find(m => m.Login == userDTM.LoginDTM);
                var userCheck = users.ToList();
                if (userCheck.Count == 0) return false;
                return true;
        }

        public bool ifUserExist(string login)
        {            
                IEnumerable<User> users = _DataBase.Users.Find(m => m.Login == login);
                var userCheck = users.ToList();
                if (userCheck.Count == 0) return false;
                return true;
        }

        public async void CreateUser(UserDTM userDTM)
        {
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

            _DataBase.Users.Create(user);
            _DataBase.Save();
        }

        public IEnumerable<UserDTM> GetUsers()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<User, UserDTM>()
            .ForMember(dest => dest.IdDTM, source => source.MapFrom(m => m.Id))
            .ForMember(dest => dest.LoginDTM, source => source.MapFrom(m => m.Login))
            .ForMember(dest => dest.NameDTM, source => source.MapFrom(m => m.Name))
            .ForMember(dest => dest.SurnameDTM, source => source.MapFrom(m => m.Surname))
            .ForMember(dest => dest.PasswordDTM, source => source.MapFrom(m => m.Password))
            .ForMember(dest => dest.RoleDTM, source => source.MapFrom(m => m.Role))
            ).CreateMapper();
            return mapper.Map<IEnumerable<User>, List<UserDTM>>(_DataBase.Users.GetAll());
        }

        public async Task<UserDTM> GetUserByLogin(string login)
        {
            return await Task.Run(() =>
            {
                if (login == string.Empty)
                    throw new ValidationException("Login not provided", "");

                IEnumerable<User> userEnum = _DataBase.Users.Find(userfromDB => userfromDB.Login == login);
                var user = userEnum.First<User>();

                if (user == null)
                    throw new ValidationException($"User with login {login} not exist", "");


                return new UserDTM
                {
                    NameDTM = user.Name,
                    SurnameDTM = user.Surname,
                    LoginDTM = user.Login,
                    PasswordDTM = user.Password,
                    RoleDTM = user.Role
                };
            });
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
