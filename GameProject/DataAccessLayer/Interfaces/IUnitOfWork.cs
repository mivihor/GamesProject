using System;
using System.Collections.Generic;
using System.Text;
using Z_DataAccessLayer.Entities;

namespace Z_DataAccessLayer.Interfaces
{
    public interface IUnitOfWork:IDisposable
    {
        IRepository<User> Users { get; }
        IRepository<HighScore> HighScores { get; }
        void Save();
    }
}
