using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GamesProject.DataAccessLayer.Entities;
using GamesProject.BusinessLogicLayer.DataTransferModels;

namespace GamesProject
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDTM>();
            CreateMap<UserDTM, User>();
        }
    }
}
