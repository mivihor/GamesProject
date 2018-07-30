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
    class HighScoreShellGameRepository:IRepository<HighScoreShellGame>
    {
        private DataContext db;

        public HighScoreShellGameRepository(DataContext context)
        {
            this.db = context;
        }

        public IEnumerable<HighScoreShellGame> GetAll()
        {
            return db.HScoresShellGame;
        }

        public HighScoreShellGame Get(int id)
        {
            return db.HScoresShellGame.Find(id);
        }

        public void Create(HighScoreShellGame highScore)
        {
            db.HScoresShellGame.Add(highScore);
        }

        public void Update(HighScoreShellGame highScore)
        {
            db.Entry(highScore).State = EntityState.Modified;
        }

        public IEnumerable<HighScoreShellGame> Find(Func<HighScoreShellGame, Boolean> predicate)
        {
            return db.HScoresShellGame.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            HighScoreShellGame highScore = db.HScoresShellGame.Find(id);
            if (highScore != null)
                db.HScoresShellGame.Remove(highScore);
        }
    }
}
