using System;
using System.Collections.Generic;
using System.Text;
using GamesProject.DataAccessLayer.Repositories;
using GamesProject.DataAccessLayer.Interfaces;
using Unity;

namespace GamesProject.BusinessLogicLayer.Infrastructure
{
    class ServiceModule
    {
        IUnityContainer container = new UnityContainer();
        
       public void Load()
        {
            container.RegisterType<IUnitOfWork, EntityFrameworkUnitOfWork>();
        }
    }
}
