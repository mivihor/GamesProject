using System;
using System.Collections.Generic;
using System.Text;

namespace GamesProject.BusinessLogicLayer.Interfaces
{
    public interface IShellGame
    {
        int GameRandomize();
        bool CheckResult(int randResult, int userResult);
        void win(int bid, string login);
        void loose(int bid, string login);
    }
}
