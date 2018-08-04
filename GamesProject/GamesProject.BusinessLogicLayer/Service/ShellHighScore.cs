using GamesProject.BusinessLogicLayer.DataTransferModels;
using GamesProject.BusinessLogicLayer.Interfaces;
using GamesProject.DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using GamesProject.BusinessLogicLayer.Infrastructure;
using System.Text;
using GamesProject.DataAccessLayer.Entities;
using System.Linq;
using AutoMapper;

namespace GamesProject.BusinessLogicLayer.Service
{
    public class ShellHighScore : IShellHighScoreService
    {
        private IUnitOfWork _db { get; set; }

        public ShellHighScore(IUnitOfWork db)
        {
            _db = db;
        }

        public void CreationScoreSetUp(string Login)
        {
            if (Login == string.Empty)
                throw new ValidationException("Login is required", "");

            HighScoreShellGame hs = new HighScoreShellGame
            {
                UserLogin = Login,
                Score = 100,
                Win = 1
            };

            _db.HighScores.Create(hs);
            _db.Save();
        }

        public void UpdateUserScores(string Login, int score, bool win)
        {
            var result = _db.HighScores.Find(userHighScore => userHighScore.UserLogin == Login).SingleOrDefault<HighScoreShellGame>();
            if (result != null)
            {
                result.Score = score;
                if (win) result.Win++;
                else result.Win = 1;
                _db.HighScores.Update(result);
                _db.Save();
            }
        }

        public HighScoreDTM getUserScore(string Login)
        {
            var result = _db.HighScores.Find(userHighScore => userHighScore.UserLogin == Login).SingleOrDefault<HighScoreShellGame>();
            if (result != null)
            {
                return new HighScoreDTM
                {
                    IdDTM = result.Id,
                    UserLogindDTM = result.UserLogin,
                    ScoreDTM = result.Score,
                    WinDTM = result.Win
                };
            }
            return null;
        }

        public List<HighScoreDTM> getHighScores()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<HighScoreShellGame, HighScoreDTM>()).CreateMapper();
            return mapper.Map<IEnumerable<HighScoreShellGame>, List<HighScoreDTM>>(_db.HighScores.GetAll());
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
