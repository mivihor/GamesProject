using GamesProject.BusinessLogicLayer.DataTransferModels;
using GamesProject.BusinessLogicLayer.Infrastructure;
using GamesProject.BusinessLogicLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GamesProject.BusinessLogicLayer.BusinessLogic
{
    public class ShellGame : IShellGame
    {
        private IShellHighScoreService _shellHSService;

        public ShellGame(IShellHighScoreService shellHSService)
        {
            _shellHSService = shellHSService;
        }


        public async Task<bool> CheckResult(int randResult, int userResult)
        {
            return await Task.Run(()=>
            {
                if (userResult > 0 && userResult < 4)
                {
                    if (randResult == userResult) return true;
                    return false;
                }
                else
                    throw new ValidationException("User result incorect", "");

            });
        }

        public int GameRandomize()
        {
            Random rnd = new Random();
            return rnd.Next(1, 4);
        }

        public async Task loose(double bid, string login)
        {
            await Task.Run(() =>
        {
            double currentScore = _shellHSService.getUserScore(login).Result.ScoreDTM;
            
            if (currentScore >= bid && bid > 0)
            {
                _shellHSService.UpdateUserScores(login, currentScore - bid, false);
            }
            else
                throw new ValidationException("Insufficient bid", "");
        });
        }

        public async Task win(double bid, string login)
        {
            await Task.Run(() =>
            {
                double currentScore = _shellHSService.getUserScore(login).Result.ScoreDTM;
                int winStatus = _shellHSService.getUserScore(login).Result.WinDTM;
                if (currentScore >= bid && bid > 0)
                {
                    _shellHSService.UpdateUserScores(login, (currentScore + (bid * 2 * winStatus)), true);
                }
                else
                    throw new ValidationException("Insufficient bid", "");
            });
        }

    }
}
