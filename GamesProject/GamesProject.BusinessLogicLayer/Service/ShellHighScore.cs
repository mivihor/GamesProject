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
    public class ShellHighScore : IShellHighScore
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
                Score = 100
            };

            _db.HighScores.Create(hs);
            _db.Save();
        }

        public void UpdateUserScores(string Login, int score)
        {
            var result = _db.HighScores.Find(userHighScore => userHighScore.UserLogin == Login).SingleOrDefault<HighScoreShellGame>();
            if (result != null)
            {
                result.Score = score;
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
                    ScoreDTM = result.Score
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
