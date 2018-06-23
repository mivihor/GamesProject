using System;
using System.Collections.Generic;
using System.Text;
using Z_DataAccessLayer.Interfaces;
using Z_DataAccessLayer.EntitiFramework;
using Z_DataAccessLayer.Entities;

namespace Z_DataAccessLayer.Repositories
{
    public class EntityFrameworkUnitOfWork : IUnitOfWork
    {
        private DataContext db;
        private UserRepository userRepository;
        private HighScoreRepository highScoreRepository;


        public IRepository<User> Users
        {
            get
            {
                if (userRepository == null)
                    userRepository = new UserRepository(db);
                return userRepository;
            }
        }

        public IRepository<HighScore> HighScores
        {
            get
            {
                if (highScoreRepository == null)
                    highScoreRepository = new HighScoreRepository(db);
                return highScoreRepository;
            }
        }

        public DataContext Db { get => db; set => db = value; }

        public void Save()
        {
            Db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    Db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
