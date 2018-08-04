using GamesProject.BusinessLogicLayer.DataTransferModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace GamesProject.BusinessLogicLayer.Interfaces
{
    public interface IShellHighScoreService
    {
        void CreationScoreSetUp(string Login);
        void UpdateUserScores(string Login, int score, bool win);
        HighScoreDTM getUserScore(string Login);
        List<HighScoreDTM> getHighScores();
        void Dispose();
    }
}
