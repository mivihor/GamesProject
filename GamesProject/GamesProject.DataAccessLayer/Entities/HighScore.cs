using System;
using System.Collections.Generic;
using System.Text;

namespace GamesProject.DataAccessLayer.Entities
{
    public class HighScoreShellGame
    {
        public int Id { get; set; }
        public string UserLogin { get; set; }
        public int Score { get; set; }
    }
}
