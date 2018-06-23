using System;
using System.Collections.Generic;
using System.Text;
using Z_DataAccessLayer.EntitiFramework;
using Z_DataAccessLayer.Interfaces;
using Z_DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Z_DataAccessLayer.Repositories
{
    class HighScoreRepository : IRepository<HighScore>
    {
        private DataContext db;

        public HighScoreRepository(DataContext context)
        {
            this.db = context;
        }

        public IEnumerable<HighScore> GetAll()
        {
            return db.HScores;
        }

        public HighScore Get(int id)
        {
            return db.HScores.Find(id);
        }

        public void Create(HighScore highScore)
        {
            db.HScores.Add(highScore);
        }

        public void Update(HighScore highScore)
        {
            db.Entry(highScore).State = EntityState.Modified;
        }

        public IEnumerable<HighScore> Find(Func<HighScore, Boolean> predicate)
        {
            return db.HScores.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            HighScore highScore = db.HScores.Find(id);
            if (highScore != null)
                db.HScores.Remove(highScore);
        }
    }
}
