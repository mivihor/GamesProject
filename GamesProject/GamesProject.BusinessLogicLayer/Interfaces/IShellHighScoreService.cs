using GamesProject.BusinessLogicLayer.DataTransferModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace GamesProject.BusinessLogicLayer.Interfaces
{
    public interface IShellHighScoreService
    {
        void CreationScoreSetUp(string Login);
        void UpdateUserScores(string Login, double score, bool win);
        void UpdateUserScores(HighScoreDTM userScore, double score);
        HighScoreDTM getUserScore(string Login);
        IEnumerable<HighScoreDTM> getHighScores();
        IEnumerable<HighScoreDTM> getZeroScores();
        void Dispose();
    }
}
