using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using GamesProject.DataAccessLayer.Entities;
using GamesProject.DataAccessLayer.EntitiFramework;
using GamesProject.DataAccessLayer.Interfaces;
using System.Linq;

namespace GamesProject.DataAccessLayer.Repositories
{
    class UserRepository:IRepository<User>
    {
        private DataContext db;

        public UserRepository(DataContext context)
        {
            this.db = context;
        }

        public IEnumerable<User> GetAll()
        {
            return db.Users;
        }

        public User Get(int id)
        {
            return db.Users.Find(id);
        }

        public void Create(User user)
        {
            db.Users.Add(user);
        }

        public void Update(User user)
        {
            db.Entry(user).State = EntityState.Modified;
        }

        public IEnumerable<User> Find(Func<User, Boolean> predicate)
        {
            return db.Users.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            User user = db.Users.Find(id);
            if (user != null)
                db.Users.Remove(user);
        }

    }
}
