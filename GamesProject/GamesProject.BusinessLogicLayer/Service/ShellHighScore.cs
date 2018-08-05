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

            HighScore hs = new HighScore
            {
                UserLogin = Login,
                Score = 100,
                Win = 1
            };

            _db.HighScores.Create(hs);
            _db.Save();
        }

        public void UpdateUserScores(string Login, double score, bool win)
        {
            var result = _db.HighScores.Find(userHighScore => userHighScore.UserLogin == Login).SingleOrDefault<HighScore>();
            if (result != null)
            {
                result.Score = score;
                if (win) result.Win++;
                else result.Win = 1;
                _db.HighScores.Update(result);
                _db.Save();
            }
        }

        public void UpdateUserScores(HighScoreDTM userScore, double score)
        {
            var result = _db.HighScores.Get(userScore.IdDTM);
                result.Score = score;
                result.Win = 1;
                _db.HighScores.Update(result);
                _db.Save();
        }

        public HighScoreDTM getUserScore(string Login)
        {
            var result = _db.HighScores.Find(userHighScore => userHighScore.UserLogin == Login).SingleOrDefault<HighScore>();
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

        public IEnumerable<HighScoreDTM> getHighScores()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<HighScore, HighScoreDTM>()
            .ForMember(dest => dest.IdDTM, source => source.MapFrom(m => m.Id))
            .ForMember(dest => dest.UserLogindDTM, source => source.MapFrom(m => m.UserLogin))
            .ForMember(dest => dest.ScoreDTM, source => source.MapFrom(m => m.Score))
            .ForMember(dest => dest.WinDTM, source => source.MapFrom(m => m.Win))
            ).CreateMapper();
            return mapper.Map<IEnumerable<HighScore>, List<HighScoreDTM>>(_db.HighScores.GetAll());
        }
        public IEnumerable<HighScoreDTM> getZeroScores()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<HighScore, HighScoreDTM>()
            .ForMember(dest => dest.IdDTM, source => source.MapFrom(m => m.Id))
            .ForMember(dest => dest.UserLogindDTM, source => source.MapFrom(m => m.UserLogin))
            .ForMember(dest => dest.ScoreDTM, source => source.MapFrom(m => m.Score))
            .ForMember(dest => dest.WinDTM, source => source.MapFrom(m => m.Win))
            ).CreateMapper();
            return mapper.Map<List<HighScoreDTM>>(_db.HighScores.Find(hs => hs.Score == 0));
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
