using GamesProject.BusinessLogicLayer.Infrastructure;
using GamesProject.BusinessLogicLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GamesProject.BusinessLogicLayer.BusinessLogic
{
    public class ShellGame : IShellGame
    {
        private IShellHighScoreService _shellHSService;

        public ShellGame(IShellHighScoreService shellHSService)
        {
            _shellHSService = shellHSService;
        }

        public bool CheckResult(int randResult, int userResult)
        {
            if (userResult > 0 && userResult < 4)
            {
                if (randResult == userResult) return true;
                return false;
            }
            else
                throw new ValidationException("User result incorect", "");
            
        }

        public int GameRandomize()
        {
            Random rnd = new Random();
            return rnd.Next(1, 4);
        }

        public  void loose(double bid, string login)
        {
            double currentScore = _shellHSService.getUserScore(login).ScoreDTM;
            if (currentScore >= bid && bid >0)
            {
                _shellHSService.UpdateUserScores(login, currentScore - bid, false);
            }
            else
                throw new ValidationException("Insufficient bid", "");
        }

        public void win(double bid, string login)
        {
            double currentScore = _shellHSService.getUserScore(login).ScoreDTM;
            int winStatus = _shellHSService.getUserScore(login).WinDTM;
            if (currentScore >= bid && bid > 0)
            {
                _shellHSService.UpdateUserScores(login, (currentScore+(bid*bid*winStatus)), true);
            }
            else
                throw new ValidationException("Insufficient bid", "");
        }

    }
}
