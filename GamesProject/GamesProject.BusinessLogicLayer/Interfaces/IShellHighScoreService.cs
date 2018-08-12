using GamesProject.BusinessLogicLayer.DataTransferModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GamesProject.BusinessLogicLayer.Interfaces
{
    public interface IShellHighScoreService
    {
        Task CreationScoreSetUp(string Login);
        void UpdateUserScores(string Login, double score, bool win);
        void UpdateUserScores(HighScoreDTM userScore, double score);
        Task<HighScoreDTM> getUserScore(string Login);
        IEnumerable<HighScoreDTM> getHighScores();
        IEnumerable<HighScoreDTM> getZeroScores();
        void Dispose();
    }
}
