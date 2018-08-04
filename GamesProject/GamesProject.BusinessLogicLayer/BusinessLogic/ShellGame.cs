using GamesProject.BusinessLogicLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GamesProject.BusinessLogicLayer.BusinessLogic
{
    class ShellGame : IShellGame
    {
        private IShellHighScoreService _shellHSService;
        public ShellGame(IShellHighScoreService shellHSService)
        {
            _shellHSService = shellHSService;
        }
        public bool CheckResult(int randRes, int userResul)
        {
            if (randRes == userResul) return true;
            return false;
        }

        public int GameRandomize()
        {
            Random rnd = new Random();
            return rnd.Next(1, 4);
        }

        public void loose(int bid, string login)
        {
            throw new NotImplementedException();
        }

        public void win(int bid, string login)
        {
            throw new NotImplementedException();
        }
    }
}
