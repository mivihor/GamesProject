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
    class HighScoreShellGameRepository:IRepository<HighScore>
    {
        private DataContext db;

        public HighScoreShellGameRepository(DataContext context)
        {
            this.db = context;
        }

        public IEnumerable<HighScore> GetAll()
        {
            return db.HScoresShellGame.ToList();
        }

        public HighScore Get(int id)
        {
            return db.HScoresShellGame.Find(id);
        }

        public void Create(HighScore highScore)
        {
            db.HScoresShellGame.Add(highScore);
        }

        public void Update(HighScore highScore)
        {
            db.Entry(highScore).State = EntityState.Modified;
        }

        public IEnumerable<HighScore> Find(Func<HighScore, Boolean> predicate)
        {
            return db.HScoresShellGame.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            HighScore highScore = db.HScoresShellGame.Find(id);
            if (highScore != null)
                db.HScoresShellGame.Remove(highScore);
        }
    }
}
