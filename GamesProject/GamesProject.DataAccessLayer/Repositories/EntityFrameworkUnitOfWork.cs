using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using GamesProject.DataAccessLayer.Entities;
using GamesProject.DataAccessLayer.Interfaces;
using GamesProject.DataAccessLayer.EntitiFramework;


namespace GamesProject.DataAccessLayer.Repositories
{
    public class EntityFrameworkUnitOfWork:IUnitOfWork
    {
        private DataContext db = new DataContext();
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
