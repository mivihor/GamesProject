using System;
using System.Collections.Generic;
using System.Text;
using GamesProject.DataAccessLayer.Entities;

namespace GamesProject.DataAccessLayer.Interfaces
{
    public interface IUnitOfWork:IDisposable
    {
        IRepository<User> Users { get; }
        IRepository<HighScore> HighScores { get; }
        void Save();
    }
}
