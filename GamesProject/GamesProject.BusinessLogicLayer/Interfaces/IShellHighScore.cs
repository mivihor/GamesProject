using GamesProject.BusinessLogicLayer.DataTransferModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace GamesProject.BusinessLogicLayer.Interfaces
{
    public interface IShellHighScore
    {
        void CreationScoreSetUp(string Login);
        void UpdateUserScores(string Login, int score);
        HighScoreDTM getUserScore(string Login);
        List<HighScoreDTM> getHighScores();
        void Dispose();
    }
}
