using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GamesProject.BusinessLogicLayer.Interfaces
{
    public interface IShellGame
    {
        int GameRandomize();
        Task<bool> CheckResult(int randResult, int userResult);
        Task win(double bid, string login);
        Task loose(double bid, string login);
        Task<double> winScore(double bid, string login);
    }
}
