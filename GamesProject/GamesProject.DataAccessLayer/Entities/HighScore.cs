using System;
using System.Collections.Generic;
using System.Text;

namespace GamesProject.DataAccessLayer.Entities
{
    public class HighScore
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int Score { get; set; }
    }
}
